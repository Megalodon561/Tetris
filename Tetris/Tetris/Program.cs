using Tetris;
Console.SetWindowSize(Field.Width, Field.Height);
Console.SetBufferSize(Field.Width, Field.Height);
FigureGenerator generator = new FigureGenerator(20, 0, '*');
Figure currentFigure = generator.GetNewFigure();
while (true)
{
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey();
        var result =HandleKey(currentFigure, key);
        ProcessResult(result, ref currentFigure);


    }
}

bool ProcessResult(Result result, ref Figure currentFigure)
{
    if(result==Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
    {
        Field.AddFigure(currentFigure);
        currentFigure = generator.GetNewFigure();
        return true;
    }
    else
        return false;
}

static Result HandleKey(Figure f, ConsoleKeyInfo key)
{
    switch (key.Key)
    {
        case ConsoleKey.LeftArrow:
            return f.TryMove(Direction.LEFT);
            break;
        case ConsoleKey.RightArrow:
            return f.TryMove(Direction.RIGHT);
            break;
        case ConsoleKey.DownArrow:
            return f.TryMove(Direction.DOWN);
            break;
        case ConsoleKey.Spacebar:
            return f.TryRotate();
            break;
    }
    return Result.SUCCESS;
}

