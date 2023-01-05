using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Reversi
{
    class Position
    {
        private Board board; //This position's board.
        private Tile.Sides player; //This position's player side.
        private static int thinkMovesForward = 2;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////Properties/////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Board Board
        {
            get { return (board); }
            set { board = value; }
        }

        public Tile.Sides Player
        {
            get { return (player); }
            set { player = value; }
        }

        public static int ThinkMovesForward
        {
            get { return (thinkMovesForward); }
            set { thinkMovesForward = value; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////Base Methods///////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Constructor
        public Position(Board board, Tile.Sides player)
        {
            this.Board = board;
            this.Player = player;
        }

        //Clone this object by making new instance of it.
        public Position Clone()
        {
            Position retVal = new Position(this.Board.Clone(), Player);
            return (retVal);
        }

        //Set four tiles in center and Human side. Human always begins.
        public void SetInitialPosition()
        {
            Board.SetInitialBoard();
            Player = Tile.Sides.HumanSide;
        }

        //Change player for this position to opposite player.
        public void Opposite()
        {
            switch (Player)
            {
                case Tile.Sides.ComputerSide:
                    Player = Tile.Sides.HumanSide;
                    break;
                case Tile.Sides.HumanSide:
                    Player = Tile.Sides.ComputerSide;
                    break;
            }
        }

        //Get a list of the coordinates of all possible moves from the current position.
        public ArrayList GetCoordinatesOfAllPossibleMoves()
        {
            ArrayList retVal = new ArrayList(0);
            int[] pair;
            for (int i = 0; i < board.SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < board.SquaresInRowAndColomn; j++)
                {
                    Position position = this.Clone();
                    if (position.Board.UpdateBoard(i, j, Player))
                    {
                        pair = new int[2];
                        pair[0] = i;
                        pair[1] = j;
                        retVal.Add(pair);
                    }
                    else position = null;
                }
            }
            return (retVal);
        }

        //Get a list of all the positions after all possible moves from the current position.
        public ArrayList GetPositionsAfterAllPossibleMoves()
        {
            ArrayList retVal = new ArrayList(0);
            for (int i = 0; i < board.SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < board.SquaresInRowAndColomn; j++)
                {
                    Position position = this.Clone();
                    if (position.Board.UpdateBoard(i, j, Player))
                    {
                        position.Opposite();
                        position.Board.GameBoard[i, j].Tile.State = Tile.States.LastMove;
                        retVal.Add(position);
                    }
                    else position = null;
                }
            }
            return (retVal);
        }

        //Are There Possible Computer Moves?
        public bool AreTherePossibleComputerMoves()
        {
            bool retVal = false;
            for (int i = 0; i < board.SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < board.SquaresInRowAndColomn; j++)
                {
                    Position position = this.Clone();
                    if (position.Board.UpdateBoard(i, j, Tile.Sides.ComputerSide)) retVal = true;
                    position = null;
                }
            }
            return (retVal);
        }

        //Are There Possible Human Moves?
        public bool AreTherePossibleHumanMoves()
        {
            bool retVal = false;
            for (int i = 0; i < board.SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < board.SquaresInRowAndColomn; j++)
                {
                    Position position = this.Clone();
                    if (position.Board.UpdateBoard(i, j, Tile.Sides.HumanSide)) retVal = true;
                    position = null;
                }
            }
            return (retVal);
        }

        //Is end of game reached?
        public bool IsEndOfGame()
        {
            return (!(AreTherePossibleComputerMoves() || AreTherePossibleHumanMoves()));
        }

        //Human move succeed.
        public bool HumanMoveSucceed(int x, int y)
        {
            bool retVal = false;
            if ((Player == Tile.Sides.HumanSide) && (Board.UpdateBoard(x, y, Tile.Sides.HumanSide)))
            {
                Opposite();
                retVal = true;
            }
            return (retVal);
        }

        //Computer move succeed.
        public void ComputerBestMove()
        {
            Position pos;
            int val;
            AlfaBeta(this, int.MinValue, int.MaxValue, out pos, out val, ThinkMovesForward);
            if ((Player == Tile.Sides.ComputerSide) && (pos != null))
            {
                this.Board = pos.Board;
                this.Player = pos.Player;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////Alfa-Beta Algorithm///////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AlfaBeta(Position pos, int alfa, int beta, out Position goodPos, out int val, int depth)
        {
            goodPos = null;
            val = 0;
            Application.DoEvents();
            ArrayList posList = pos.GetPositionsAfterAllPossibleMoves();
            if ((depth > 0) && (posList.Count > 0)) BoundedBest(posList, alfa, beta, out goodPos, out val, depth - 1);
            else val = pos.Board.EvaluationFunction();
        }

        public void BoundedBest(ArrayList posList, int alfa, int beta, out Position goodPos, out int goodVal, int depth)
        {
            int val;
            Position tempPos;
            Position pos = (Position)posList[0];
            posList.RemoveAt(0);
            AlfaBeta(pos, alfa, beta, out tempPos, out val, depth);
            GoodEnough(posList, alfa, beta, pos, val, out goodPos, out goodVal, depth);
        }

        public void GoodEnough(ArrayList posList, int alfa, int beta, Position pos, int val, out Position goodPos, out int goodVal, int depth)
        {
            int newAlfa;
            int newBeta;
            Position pos1;
            int val1;

            if ((posList.Count == 0) || ((pos.Player == Tile.Sides.HumanSide) && (val > beta)) || ((pos.Player == Tile.Sides.ComputerSide) && (val < alfa)))
            {
                goodPos = pos;
                goodVal = val;
            }
            else
            {
                NewBounds(alfa, beta, pos, val, out newAlfa, out newBeta);
                BoundedBest(posList, newAlfa, newBeta, out pos1, out val1, depth);
                BetterOf(pos, val, pos1, val1, out goodPos, out goodVal);
            }
        }

        public void NewBounds(int alfa, int beta, Position pos, int val, out int newAlfa, out int newBeta)
        {
            newAlfa = alfa;
            newBeta = beta;
            if ((pos.Player == Tile.Sides.HumanSide) && (val > alfa)) newAlfa = val;
            else if ((pos.Player == Tile.Sides.ComputerSide) && (val < beta)) newBeta = val;
        }

        public void BetterOf(Position pos1, int val1, Position pos2, int val2, out Position pos, out int val)
        {
            if (((pos1.Player == Tile.Sides.HumanSide) && (val1 > val2)) || ((pos1.Player == Tile.Sides.ComputerSide) && (val1 < val2)))
            {
                pos = pos1;
                val = val1;
            }
            else
            {
                pos = pos2;
                val = val2;
            }
        }
    }
}
