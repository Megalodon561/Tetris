using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Stick : Figure
    {
        public Stick(int x, int y, char sym)
        {
            Points[0] = new Point(x, y, sym);
            Points[1] = new Point(x, y + 1, sym);
            Points[2] = new Point(x, y + 2, sym);
            Points[3] = new Point(x, y + 3, sym);
            Draw();
        }
        public override void Rotate(Point[] PList)
        {
            if (PList[0].X == PList[1].X)
            {
                SetHorizontal(PList);
            }
            else
            {
                SetVertical(PList);
            }

        }

        private void SetHorizontal(Point[] PList)
        {
            for (int i = 0; i < PList.Length; i++)
            {
                PList[i].Y = PList[0].Y;
                PList[i].X = PList[0].X+i;
            }
        }

        private void SetVertical(Point[] PList)
        {
            for (int i = 0; i < PList.Length; i++)
            {
                PList[i].X = PList[0].X;
                PList[i].Y = PList[0].Y + i;
            }
        }
    }
}
