using Tetris;
Console.SetWindowSize(30, 40);
Console.SetBufferSize(30, 40);
FigureGenerator generator = new FigureGenerator(20, 0, '*');
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
            currentFigure.Move(Direction.LEFT);
            break;
        case ConsoleKey.RightArrow:
            currentFigure.Move(Direction.RIGHT);
            break;
        case ConsoleKey.DownArrow:
            currentFigure.Move(Direction.DOWN);
            break;
    }
}

