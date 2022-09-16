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

        public static void TryDeleteLines()
        {
            for(int j=0; j < Field.Height; j++)
            {
                int counter=0;
                for(int i=0; i< Field.Width; i++)
                {
                    if (Field._heap[j][i])
                        counter++;
                }
                if (counter == Field.Width)
                {
                    Field.DeleteLine(j);
                    Field.Redraw();
                }
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
        internal Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            var result = VerifyPosition(clone);
            if (result == Result.SUCCESS)
                Points = clone;
            Draw();
            return result;
        }
        internal Result TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            var result = VerifyPosition(clone);
            if (result==Result.SUCCESS)
                Points = clone;
            Draw();
            return result;
        }

        private Result VerifyPosition(Point[] PList)
        {
            foreach(Point p in PList)
            {
                if(p.Y>=Field.Height)
                    return Result.DOWN_BORDER_STRIKE;
                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;
                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
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
