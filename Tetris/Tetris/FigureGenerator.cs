namespace Tetris
{
    internal class FigureGenerator
    {
        private int _x;
        private int _y;
        private char _c;
        private Random _random= new Random();
        public FigureGenerator(int x, int y, char c)
        {
            _x=x; _y=y; _c=c;
        }

        public Figure GetNewFigure()
        {
            if (_random.Next(0, 2) == 0)
            {
                return new Squares(_x, _y, _c);
            }
            else
            {
                return new Stick(_x, _y, _c);
            }

        }
    }
}