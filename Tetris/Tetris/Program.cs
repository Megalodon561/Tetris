using Tetris;
Console.SetWindowSize(30, 40);
Console.SetBufferSize(30, 40);
FigureGenerator generator = new FigureGenerator(28, 0, '*');
Figure currentFigure = generator.GetNewFigure();
while (true)
{
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey();
        HandleKey(currentFigure, key);

    }
}

void HandleKey(Figure currentFigure, ConsoleKeyInfo key)
{
    switch (key.Key)
    {
        case ConsoleKey.LeftArrow:
            currentFigure.TryMove(Direction.LEFT);
            break;
        case ConsoleKey.RightArrow:
            currentFigure.TryMove(Direction.RIGHT);
            break;
        case ConsoleKey.DownArrow:
            currentFigure.TryMove(Direction.DOWN);
            break;
    }
}

