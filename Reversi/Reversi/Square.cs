using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Reversi
{
    class Square
    {
        public enum States { Ordinary, PossibleMove } //Possible square states (Ordinary colored or colored to color of possible move).

        private int left; //Square left.
        private int top; //Square top.
        private int size; //Square height or width.
        private States state; //Ordinary colored or colored to color of possible move.
        private Color ordinaryColor; //Ordinary Color.
        private Color possibleMoveColor; //Possible Move Color.
        private Color borderColor; //Border Color.
        private Tile tile = null; //Tile on this square.

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

        //State property.
        public States State
        {
            get { return (state); }
            set { state = value; }
        }

        //Ordinary Color property.
        public Color OrdinaryColor
        {
            get { return (ordinaryColor); }
            set { ordinaryColor = value; }
        }

        //Possible Move Color property.
        public Color PossibleMoveColor
        {
            get { return (possibleMoveColor); }
            set { possibleMoveColor = value; }
        }

        //Border Color property.
        public Color BorderColor
        {
            get { return (borderColor); }
            set { borderColor = value; }
        }

        //Tile property.
        public Tile Tile
        {
            get { return (tile); }
            set { tile = value; }
        }

        //Constructor.
        public Square(int left, int top, int size, States state, Color ordinaryColor, Color possibleMoveColor, Color borderColor)
        {
            this.Left = left;
            this.Top = top;
            this.Size = size;
            this.State = state;
            this.OrdinaryColor = ordinaryColor;
            this.PossibleMoveColor = possibleMoveColor;
            this.BorderColor = borderColor;
        }

        //Clone this object to new assigned object.
        public Square Clone()
        {
            Square retVal = new Square(Left, Top, Size, State, OrdinaryColor, PossibleMoveColor, BorderColor);
            if (!IsEmpty()) retVal.Tile = this.Tile.Clone();
            return (retVal);
        }

        //Is square empty?
        public bool IsEmpty()
        {
            return (Tile == null);
        }

        //Add tile of specified side.
        public void AddTile(Tile.Sides side)
        {
            Tile = new Tile(Left + 5, Top + 5, Size - 10, side, Color.Blue, Color.Green, Color.DarkBlue);
        }

        //Reverse side of this tile.
        public void ReverseTile()
        {
            switch (Tile.Side)
            {
                case Tile.Sides.ComputerSide:
                    Tile.Side = Tile.Sides.HumanSide;
                    break;
                case Tile.Sides.HumanSide:
                    Tile.Side = Tile.Sides.ComputerSide;
                    break;
            }
        }

        //Get side of this tile.
        public Tile.Sides GetTileSide()
        {
            return (Tile.Side);
        }

        //Draw square.
        public void Draw(Graphics g)
        {
            switch (State)
            {
                case States.Ordinary:
                    g.FillRectangle(new SolidBrush(OrdinaryColor), Left, Top, Size, Size);
                    break;
                case States.PossibleMove:
                    g.FillRectangle(new SolidBrush(PossibleMoveColor), Left, Top, Size, Size);
                    break;
            }
            g.DrawRectangle(new Pen(BorderColor), Left, Top, Size, Size);
            if (!this.IsEmpty()) this.tile.Draw(g); //If there is a tile on this square - draw it.
        }
    }
}
