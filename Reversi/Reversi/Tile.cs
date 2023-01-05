using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Reversi
{
    class Tile
    {
        public enum Sides { ComputerSide, HumanSide } //Possible tile sides (Computer Side or Human Side).
        public enum States { Ordinary, LastMove } //Possible tile states (ordinary tile or tile after last move).

        private int left; //Left side of the tile.
        private int top; //Top of the tile.
        private int size; //Size of the container rectangle.
        private Sides side; //Computer Side or Human Side.
        private States state; //Ordinary tile or tile after last move.
        private Color computerSideColor; //Computer side color.
        private Color humanSideColor; //Human side color.
        private Color lastMoveColor; //Computer last move color (Dark computer side color).

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

        //Side property.
        public Sides Side
        {
            get { return (side); }
            set { side = value; }
        }

        //State property.
        public States State
        {
            get { return (state); }
            set { state = value; }
        }

        //Computer Side Color property.
        public Color ComputerSideColor
        {
            get { return (computerSideColor); }
            set { computerSideColor = value; }
        }

        //Human Side Color property.
        public Color HumanSideColor
        {
            get { return (humanSideColor); }
            set { humanSideColor = value; }
        }

        //Last Move Color property.
        public Color LastMoveColor
        {
            get { return (lastMoveColor); }
            set { lastMoveColor = value; }
        }

        //Constructor.
        public Tile(int left, int top, int size, Sides side, Color computerSideColor, Color humanSideColor, Color lastMoveColor)
        {
            this.Left = left;
            this.Top = top;
            this.Size = size;
            this.Side = side;
            this.ComputerSideColor = computerSideColor;
            this.HumanSideColor = humanSideColor;
            this.LastMoveColor = lastMoveColor;
        }

        //Clone this object to new assigned object.
        public Tile Clone()
        {
            Tile retVal = new Tile(Left, Top, Size, Side, ComputerSideColor, HumanSideColor, LastMoveColor);
            return (retVal);
        }

        //Draw Tile.
        public void Draw(Graphics g)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(Left, Top, Size, Size);
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
            pathGradientBrush.CenterPoint = new Point(Left + (Size / 3), Top + (Size / 3)); //Glare center.
            pathGradientBrush.CenterColor = Color.White; //Glare color.
            if (Side == Sides.HumanSide) pathGradientBrush.SurroundColors = new Color[] { HumanSideColor };
            else
            {
                if (State == States.Ordinary) pathGradientBrush.SurroundColors = new Color[] { ComputerSideColor };
                if (State == States.LastMove) pathGradientBrush.SurroundColors = new Color[] { LastMoveColor };
            }
            g.FillRectangle(pathGradientBrush, Left, Top, Size, Size);
            g.DrawEllipse(new Pen(Color.Black), Left, Top, Size, Size);
        }
    }
}
