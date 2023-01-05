using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Reversi
{
    public partial class MainFrm : Form
    {
        private Position currentPosition; //Current position.

        //Constructor.
        public MainFrm()
        {
            InitializeComponent();
            this.Location = Settings.Location;
            Position.ThinkMovesForward = Settings.ThinkMovesForward;
            SetThinkMovesForward(Position.ThinkMovesForward);
            BeginNewGame();
        }

        //Begin new game.
        private void BeginNewGame()
        {
            currentPosition = new Position(new Board(ClientRectangle.Left, ClientRectangle.Top + menuBar.Height, 380, 10, Color.Aqua, Color.Black), Tile.Sides.HumanSide);
            currentPosition.SetInitialPosition();
            currentPosition.Board.DrawAllPossibleMoves(currentPosition.GetCoordinatesOfAllPossibleMoves());
            ShowStatus("It is your move now.");
            this.Refresh();
        }

        //Set number of moves to think forward.
        private void SetThinkMovesForward(int moves)
        {
            switch (moves)
            {
                case 1:
                    think1MoveForwardToolStripMenuItem.Checked = true;
                    think2MovesForwardToolStripMenuItem.Checked = false;
                    think3MovesForwardToolStripMenuItem.Checked = false;
                    think4MovesForwardToolStripMenuItem.Checked = false;
                    think5MovesForwardToolStripMenuItem.Checked = false;
                    Position.ThinkMovesForward = 1;
                    Settings.ThinkMovesForward = 1;
                    break;
                case 2:
                    think1MoveForwardToolStripMenuItem.Checked = false;
                    think2MovesForwardToolStripMenuItem.Checked = true;
                    think3MovesForwardToolStripMenuItem.Checked = false;
                    think4MovesForwardToolStripMenuItem.Checked = false;
                    think5MovesForwardToolStripMenuItem.Checked = false;
                    Position.ThinkMovesForward = 2;
                    Settings.ThinkMovesForward = 2;
                    break;
                case 3:
                    think1MoveForwardToolStripMenuItem.Checked = false;
                    think2MovesForwardToolStripMenuItem.Checked = false;
                    think3MovesForwardToolStripMenuItem.Checked = true;
                    think4MovesForwardToolStripMenuItem.Checked = false;
                    think5MovesForwardToolStripMenuItem.Checked = false;
                    Position.ThinkMovesForward = 3;
                    Settings.ThinkMovesForward = 3;
                    break;
                case 4:
                    think1MoveForwardToolStripMenuItem.Checked = false;
                    think2MovesForwardToolStripMenuItem.Checked = false;
                    think3MovesForwardToolStripMenuItem.Checked = false;
                    think4MovesForwardToolStripMenuItem.Checked = true;
                    think5MovesForwardToolStripMenuItem.Checked = false;
                    Position.ThinkMovesForward = 4;
                    Settings.ThinkMovesForward = 4;
                    break;
                case 5:
                    think1MoveForwardToolStripMenuItem.Checked = false;
                    think2MovesForwardToolStripMenuItem.Checked = false;
                    think3MovesForwardToolStripMenuItem.Checked = false;
                    think4MovesForwardToolStripMenuItem.Checked = false;
                    think5MovesForwardToolStripMenuItem.Checked = true;
                    Position.ThinkMovesForward = 5;
                    Settings.ThinkMovesForward = 5;
                    break;
            }
        }

        //Show status.
        private void ShowStatus(string status)
        {
            statusBarLabel2.Text = status + " ";
            statusBarLabel4.Text = currentPosition.Board.CountTiles(Tile.Sides.ComputerSide).ToString() + " ";
            statusBarLabel6.Text = currentPosition.Board.CountTiles(Tile.Sides.HumanSide).ToString();
        }

        //Show winner.
        private void ShowWinner()
        {
            if (currentPosition.Board.CountTiles(Tile.Sides.ComputerSide) == currentPosition.Board.CountTiles(Tile.Sides.HumanSide))
            {
                ShowStatus("Draw!");
            }
            if (currentPosition.Board.CountTiles(Tile.Sides.ComputerSide) < currentPosition.Board.CountTiles(Tile.Sides.HumanSide))
            {
                ShowStatus("Congratulations! You Win!");
            }
            if (currentPosition.Board.CountTiles(Tile.Sides.ComputerSide) > currentPosition.Board.CountTiles(Tile.Sides.HumanSide))
            {
                ShowStatus("Sorry! Computer Win!");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////Human Move / Computer Move///////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Perform human move.
        private void HumanMove(int x ,int y)
        {
            if (currentPosition.HumanMoveSucceed(x, y)) //If human has performed a move.
            {
                currentPosition.Board.ClearLastMove(); //Clear border of the last tile added by computer.
                currentPosition.Board.ClearAllPossibleMoves(); //Clear squares for all possible moves.
                this.Refresh();
                ComputerMove(); //Perform computer move.
            }
        }

        //Perform computer move.
        private void ComputerMove()
        {
            if (!currentPosition.IsEndOfGame()) //If NOT end of game.
            {
                if (!currentPosition.AreTherePossibleComputerMoves()) //If there are NO computer moves.
                {
                    currentPosition.Opposite(); //Board remains unchanged, player has been changed to human.
                }
                else //If there are computer moves.
                {
                    this.Cursor = Cursors.WaitCursor;
                    ShowStatus("Computer is thinking...");
                    currentPosition.ComputerBestMove(); //Perform computer move.
                    this.Cursor = Cursors.Hand;
                    ShowStatus("It is your move now.");
                    if (!currentPosition.IsEndOfGame()) //If NOT end of game.
                    {
                        if (!currentPosition.AreTherePossibleHumanMoves()) //If there are NO human moves.
                        {
                            currentPosition.Opposite(); //Board remains unchanged, player has been changed to computer.
                            ComputerMove(); //Perform computer move.
                        }
                    }
                    else //If end of game is reached.
                    {
                        ShowWinner();
                    }
                }
                currentPosition.Board.DrawAllPossibleMoves(currentPosition.GetCoordinatesOfAllPossibleMoves());
                this.Refresh();
            }
            else //If end of game is reached.
            {
                ShowWinner();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////MainFrm Events///////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainFrm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int[] squareUnderMousePointer = currentPosition.Board.GetSquareUnderMousePointer(e.X, e.Y);
                if (squareUnderMousePointer != null)
                {
                    HumanMove(squareUnderMousePointer[0], squareUnderMousePointer[1]);
                }
            }
        }

        private void MainFrm_Paint(object sender, PaintEventArgs e)
        {
            if (currentPosition != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                currentPosition.Board.Draw(e.Graphics);
            }
        }

        private void MainFrm_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) Settings.Location = this.Location;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////Menu Events////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginNewGame();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void visitWebSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.soft-collection.com");
        }

        private void helpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\SoftCollectionReversi.chm");
        }

        private void think1MoveForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetThinkMovesForward(1);
        }

        private void think2MovesForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetThinkMovesForward(2);
        }

        private void think3MovesForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetThinkMovesForward(3);
        }

        private void think4MovesForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetThinkMovesForward(4);
        }

        private void think5MovesForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetThinkMovesForward(5);
        }
    }
}