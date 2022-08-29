using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract public class Figure
    {
        const int LENGTH = 4;
        public Point[] Points = new Point[LENGTH];
        public void Draw()

        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }
        public void Move(Point[] PList, Direction dir)
        {
            foreach(Point p in PList)
            {
                p.Move(dir);
            }
        }
        /*      public void Move(Direction dir)
                {
                    Hide();
                    foreach (Point p in points)
                    {
                        p.Move(dir);
                    }
                    Draw();
                }*/
        internal void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
                Points = clone;
            Draw();
        }
        internal void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone))
                Points = clone;
            Draw();
        }

        private bool VerifyPosition(Point[] PList)
        {
            foreach(Point p in PList)
            {
                if(p.X<0 || p.X>=Field.Width || p.Y>=Field.Height || p.Y<0)
                    return false;
            }
            return true;
        }

        private Point[] Clone()
        {
            var NewPoints = new Point[LENGTH];
            for (int i = 0; i < LENGTH; i++)
            {
                NewPoints[i] = new Point(Points[i]);
            }
            return NewPoints;
        }

        public void Hide()
        {
            foreach(Point p in Points)
            {
                p.Hide();
            }
        }
        public abstract void Rotate(Point[] PList);
    }
}
