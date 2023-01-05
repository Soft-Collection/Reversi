using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Reversi
{
    class Board
    {
        private int left; //Left of this board.
        private int top; //Top of this board.
        private int size; //Height or Width of this board.
        private int borderSize; //Distance between board border and squares.
        private Color color; //Board Color.
        private Color borderColor; //Board border color.
        private const int squaresInRowAndColomn = 8; //How many squares in the board row or colomn.
        private Square[,] gameBoard; //(8x8) 64-squares on this board.

        //Left property.
        public int Left
        {
            get { return (left); }
            set { left = value; }
        }

        //Top property.
        public int Top
        {
            get { return (top); }
            set { top = value; }
        }

        //Size property.
        public int Size
        {
            get { return (size); }
            set { size = value; }
        }

        //Border Size property.
        public int BorderSize
        {
            get { return (borderSize); }
            set { borderSize = value; }
        }
        
        //All squares property.
        public Square[,] GameBoard
        {
            get { return (gameBoard); }
            set { gameBoard = value; }
        }

        //Color property.
        public Color Color
        {
            get { return (color); }
            set { color = value; }
        }

        //Border Color property.
        public Color BorderColor
        {
            get { return (borderColor); }
            set { borderColor = value; }
        }

        //Squares In Row And Colomn property.
        public int SquaresInRowAndColomn
        {
            get { return (squaresInRowAndColomn); }
        }

        //Constructor.
        public Board(int left, int top, int size, int borderSize, Color color, Color borderColor)
        {
            this.GameBoard = new Square[SquaresInRowAndColomn, SquaresInRowAndColomn];
            this.Left = left;
            this.Top = top;
            this.Size = size;
            this.BorderSize = borderSize;
            this.Color = color;
            this.BorderColor = borderColor;
            for (int i = 0; i < SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < SquaresInRowAndColomn; j++)
                {
                    int tempSize = (Size - (2 * BorderSize)) / SquaresInRowAndColomn;
                    int tempLeft = Left + BorderSize + i * tempSize;
                    int tempTop = Top + BorderSize + j * tempSize;
                    GameBoard[i, j] = new Square(tempLeft, tempTop, tempSize, Square.States.Ordinary, Color.White, Color.Yellow, Color.Black);
                }
            }
        }

        //Clone this object to new assigned object.
        public Board Clone()
        {
            Board retVal = new Board(Left, Top, Size, BorderSize, Color, BorderColor);
            for (int i = 0; i < SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < SquaresInRowAndColomn; j++)
                {
                    retVal.GameBoard[i, j] = GameBoard[i, j].Clone();
                }
            }
            return (retVal);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////Update Board Methods///////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        private Square[] GetEast(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if ((ubx - x) > 0)
                {
                    retVal = new Square[ubx - x];
                    for (int i = 0; i < (ubx - x); i++) retVal[i] = GameBoard[x + i + 1, y];
                }
            }
            return (retVal);
        }

        private Square[] GetWest(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if ((x - lbx) > 0)
                {
                    retVal = new Square[x - lbx];
                    for (int i = 0; i < (x - lbx); i++) retVal[i] = GameBoard[x - i - 1, y];
                }
            }
            return (retVal);
        }

        private Square[] GetSouth(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if ((uby - y) > 0)
                {
                    retVal = new Square[uby - y];
                    for (int i = 0; i < (uby - y); i++) retVal[i] = GameBoard[x, y + i + 1];
                }
            }
            return (retVal);
        }

        private Square[] GetNorth(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if ((y - lby) > 0)
                {
                    retVal = new Square[y - lby];
                    for (int i = 0; i < (y - lby); i++) retVal[i] = GameBoard[x, y - i - 1];
                }
            }
            return (retVal);
        }

        private Square[] GetSouthEast(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            int min = Math.Min((ubx - x), (uby - y));
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if (min > 0)
                {
                    retVal = new Square[min];
                    for (int i = 0; i < min; i++) retVal[i] = GameBoard[x + i + 1, y + i + 1];
                }
            }
            return (retVal);
        }

        private Square[] GetNorthWest(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            int min = Math.Min((x - lbx), (y - lby));
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if (min > 0)
                {
                    retVal = new Square[min];
                    for (int i = 0; i < min; i++) retVal[i] = GameBoard[x - i - 1, y - i - 1];
                }
            }
            return (retVal);
        }

        private Square[] GetNorthEast(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            int min = Math.Min((ubx - x), (y - lby));
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if (min > 0)
                {
                    retVal = new Square[min];
                    for (int i = 0; i < min; i++) retVal[i] = GameBoard[x + i + 1, y - i - 1];
                }
            }
            return (retVal);
        }

        private Square[] GetSouthWest(int x, int y)
        {
            Square[] retVal = null;
            int lbx = GameBoard.GetLowerBound(0);
            int ubx = GameBoard.GetUpperBound(0);
            int lby = GameBoard.GetLowerBound(1);
            int uby = GameBoard.GetUpperBound(1);
            int min = Math.Min((x - lbx), (uby - y));
            if ((x >= lbx) && (x <= ubx) && (y >= lby) && (y <= uby))
            {
                if (min > 0)
                {
                    retVal = new Square[min];
                    for (int i = 0; i < min; i++) retVal[i] = GameBoard[x - i - 1, y + i + 1];
                }
            }
            return (retVal);
        }

        private bool UpdateHalfLine(Tile.Sides side, Square[] squares)
        {
            bool retVal = false;
            if (squares != null)
            {
                if (squares.Length > 1)
                {
                    int[] tilesOnSquares = new int[squares.Length];
                    int attachedTile = 0;
                    if (side == Tile.Sides.ComputerSide) { attachedTile = 1; }
                    if (side == Tile.Sides.HumanSide) { attachedTile = 2; }
                    for (int i = 0; i < squares.Length; i++)
                    {
                        if (squares[i].IsEmpty()) tilesOnSquares[i] = 0;
                        else
                        {
                            if (squares[i].GetTileSide() == Tile.Sides.ComputerSide) tilesOnSquares[i] = 1;
                            if (squares[i].GetTileSide() == Tile.Sides.HumanSide) tilesOnSquares[i] = 2;
                        }
                    }
                    int reversedTiles = 0;
                    bool allIsOk = true;
                    for (int i = 0; i < squares.Length; i++)
                    {
                        if ((i == 0) && (tilesOnSquares[i] == attachedTile)) { allIsOk = false; break; }
                        if (tilesOnSquares[i] == 0) { allIsOk = false; break; }
                        if (tilesOnSquares[i] == attachedTile) { reversedTiles = i; break; }
                        if (i == (squares.Length - 1)) { allIsOk = false; break; }
                    }
                    retVal = allIsOk;
                    if (allIsOk)
                    {
                        for (int i = 0; i < reversedTiles; i++)
                        {
                            squares[i].ReverseTile();
                        }
                    }
                }
            }
            return (retVal);
        }

        public bool UpdateBoard(int x, int y, Tile.Sides side)
        {
            bool retVal = false;
            if (GameBoard[x, y].IsEmpty())
            {
                bool tempEast = UpdateHalfLine(side, GetEast(x, y));
                bool tempWest = UpdateHalfLine(side, GetWest(x, y));
                bool tempSouth = UpdateHalfLine(side, GetSouth(x, y));
                bool tempNorth = UpdateHalfLine(side, GetNorth(x, y));
                bool tempSouthEast = UpdateHalfLine(side, GetSouthEast(x, y));
                bool tempNorthWest = UpdateHalfLine(side, GetNorthWest(x, y));
                bool tempNorthEast = UpdateHalfLine(side, GetNorthEast(x, y));
                bool tempSouthWest = UpdateHalfLine(side, GetSouthWest(x, y));
                if (tempEast || tempWest || tempSouth || tempNorth || tempSouthEast || tempNorthWest || tempNorthEast || tempSouthWest)
                {
                    GameBoard[x, y].AddTile(side);
                    retVal = true;
                }
            }
            return (retVal);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////Evaluation Function Methods////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int EvaluationFunction()
        {
            int retVal = 0;
            for (int i = 2; i < (squaresInRowAndColomn - 2); i++)
            {
                retVal += TwoSideRowsTable(GameBoard[i, 0], GameBoard[i, 1]);
                retVal += TwoSideRowsTable(GameBoard[0, i], GameBoard[1, i]);
                retVal += TwoSideRowsTable(GameBoard[i, (squaresInRowAndColomn - 1)], GameBoard[i, (squaresInRowAndColomn - 2)]);
                retVal += TwoSideRowsTable(GameBoard[(squaresInRowAndColomn - 1), i], GameBoard[(squaresInRowAndColomn - 2), i]);
            }
            retVal += FourCornerSquaresTable(GameBoard[0, 0], GameBoard[1, 0], GameBoard[1, 1], GameBoard[0, 1]);
            retVal += FourCornerSquaresTable(GameBoard[(squaresInRowAndColomn - 1), 0], GameBoard[(squaresInRowAndColomn - 2), 0], GameBoard[(squaresInRowAndColomn - 2), 1], GameBoard[(squaresInRowAndColomn - 1), 1]);
            retVal += FourCornerSquaresTable(GameBoard[0, (squaresInRowAndColomn - 1)], GameBoard[0, (squaresInRowAndColomn - 2)], GameBoard[1, (squaresInRowAndColomn - 2)], GameBoard[1, (squaresInRowAndColomn - 1)]);
            retVal += FourCornerSquaresTable(GameBoard[(squaresInRowAndColomn - 1), (squaresInRowAndColomn - 1)], GameBoard[(squaresInRowAndColomn - 2), (squaresInRowAndColomn - 1)], GameBoard[(squaresInRowAndColomn - 2), (squaresInRowAndColomn - 2)], GameBoard[(squaresInRowAndColomn - 1), (squaresInRowAndColomn - 2)]);
            for (int i = 2; i < (squaresInRowAndColomn - 2); i++)
            {
                for (int j = 2; j < (squaresInRowAndColomn - 2); j++)
                {
                    if (!GameBoard[i, j].IsEmpty())
                    {
                        if (GameBoard[i, j].GetTileSide() == Tile.Sides.ComputerSide) retVal++;
                        if (GameBoard[i, j].GetTileSide() == Tile.Sides.HumanSide) retVal--;
                    }
                }
            }
            return (retVal);
        }

        private int FourCornerSquaresTable(Square square1, Square square2, Square square3, Square square4)
        {
            int retVal = 0;
            if ((!square1.IsEmpty()) && (!square2.IsEmpty()))
            {
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square2.GetTileSide() == Tile.Sides.ComputerSide)) retVal = 96;
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square2.GetTileSide() == Tile.Sides.HumanSide)) retVal = 72;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square2.GetTileSide() == Tile.Sides.HumanSide)) retVal = -96;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square2.GetTileSide() == Tile.Sides.ComputerSide)) retVal = -72;
            }
            if ((!square1.IsEmpty()) && (!square3.IsEmpty()))
            {
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square3.GetTileSide() == Tile.Sides.ComputerSide)) retVal = 192;
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square3.GetTileSide() == Tile.Sides.HumanSide)) retVal = 144;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square3.GetTileSide() == Tile.Sides.HumanSide)) retVal = -192;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square3.GetTileSide() == Tile.Sides.ComputerSide)) retVal = -144;
            }
            if ((!square1.IsEmpty()) && (!square4.IsEmpty()))
            {
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square4.GetTileSide() == Tile.Sides.ComputerSide)) retVal = 96;
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square4.GetTileSide() == Tile.Sides.HumanSide)) retVal = 72;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square4.GetTileSide() == Tile.Sides.HumanSide)) retVal = -96;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square4.GetTileSide() == Tile.Sides.ComputerSide)) retVal = -72;
            }
            if (!square1.IsEmpty())
            {
                if (square1.GetTileSide() == Tile.Sides.ComputerSide) retVal += 256;
                if (square1.GetTileSide() == Tile.Sides.HumanSide) retVal -= 256;
            }
            if (!square2.IsEmpty())
            {
                if (square2.GetTileSide() == Tile.Sides.ComputerSide) retVal -= 64;
                if (square2.GetTileSide() == Tile.Sides.HumanSide) retVal += 64;
            }
            if (!square3.IsEmpty())
            {
                if (square3.GetTileSide() == Tile.Sides.ComputerSide) retVal -= 128;
                if (square3.GetTileSide() == Tile.Sides.HumanSide) retVal += 128;
            }
            if (!square4.IsEmpty())
            {
                if (square4.GetTileSide() == Tile.Sides.ComputerSide) retVal -= 64;
                if (square4.GetTileSide() == Tile.Sides.HumanSide) retVal += 64;
            }
            return (retVal);
        }

        private int TwoSideRowsTable(Square square1, Square square2)
        {
            int retVal = 0;
            if ((!square1.IsEmpty()) && (!square2.IsEmpty()))
            {
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square2.GetTileSide() == Tile.Sides.ComputerSide)) retVal = 32;
                if ((square1.GetTileSide() == Tile.Sides.ComputerSide) && (square2.GetTileSide() == Tile.Sides.HumanSide)) retVal = 24;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square2.GetTileSide() == Tile.Sides.HumanSide)) retVal = -32;
                if ((square1.GetTileSide() == Tile.Sides.HumanSide) && (square2.GetTileSide() == Tile.Sides.ComputerSide)) retVal = -24;
            }
            if (!square1.IsEmpty())
            {
                if (square1.GetTileSide() == Tile.Sides.ComputerSide) retVal += 32;
                if (square1.GetTileSide() == Tile.Sides.HumanSide) retVal -= 32;
            }
            if (!square2.IsEmpty())
            {
                if (square2.GetTileSide() == Tile.Sides.ComputerSide) retVal -= 16;
                if (square2.GetTileSide() == Tile.Sides.HumanSide) retVal += 16;
            }
            return (retVal);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////Other Methods//////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Translate mouse coordinates x,y to appropriate square on the board.
        public int[] GetSquareUnderMousePointer(int x, int y)
        {
            int[] retVal = null;
            Rectangle squareUnderMousePointer;
            for (int i = 0; i < SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < SquaresInRowAndColomn; j++)
                {
                    squareUnderMousePointer = new Rectangle(GameBoard[i, j].Left, GameBoard[i, j].Top, GameBoard[i, j].Size, GameBoard[i, j].Size);
                    if (squareUnderMousePointer.Contains(x, y))
                    {
                        retVal = new int[2];
                        retVal[0] = i;
                        retVal[1] = j;
                    }
                }
            }
            return (retVal);
        }

        //Count tiles of specified side on the board.
        public int CountTiles(Tile.Sides side)
        {
            int retVal = 0;
            for (int i = 0; i < SquaresInRowAndColomn; i++)
                for (int j = 0; j < SquaresInRowAndColomn; j++)
                    if (!GameBoard[i, j].IsEmpty())
                        if (GameBoard[i, j].GetTileSide() == side) retVal++;
            return (retVal);
        }

        //Set initial board position.
        public void SetInitialBoard()
        {
            GameBoard[3, 3].AddTile(Tile.Sides.ComputerSide);
            GameBoard[4, 4].AddTile(Tile.Sides.ComputerSide);
            GameBoard[4, 3].AddTile(Tile.Sides.HumanSide);
            GameBoard[3, 4].AddTile(Tile.Sides.HumanSide);
        }

        //Draw squares of all possible moves.
        public void DrawAllPossibleMoves(ArrayList possibleMoves)
        {
            foreach (int[] pair in possibleMoves) GameBoard[pair[0], pair[1]].State = Square.States.PossibleMove;
        }

        //Clear all the squares mentioned above.
        public void ClearAllPossibleMoves()
        {
            for (int i = 0; i < SquaresInRowAndColomn; i++)
                for (int j = 0; j < SquaresInRowAndColomn; j++)
                    GameBoard[i, j].State = Square.States.Ordinary;
        }

        //Clear last moved tile unique color to ordinary color.
        public void ClearLastMove()
        {
            for (int i = 0; i < SquaresInRowAndColomn; i++)
                for (int j = 0; j < SquaresInRowAndColomn; j++)
                    if (!GameBoard[i, j].IsEmpty()) GameBoard[i, j].Tile.State = Tile.States.Ordinary;
        }

        //Draw whole board.
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color), Left, Top, Size, Size);
            g.DrawRectangle(new Pen(BorderColor), Left, Top, Size, Size);
            for (int i = 0; i < SquaresInRowAndColomn; i++)
            {
                for (int j = 0; j < SquaresInRowAndColomn; j++)
                {
                    GameBoard[i, j].Draw(g);
                }
            }
        }
    }
}