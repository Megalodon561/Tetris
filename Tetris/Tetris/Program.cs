Console.SetWindowSize(30, 40);
Console.SetBufferSize(30, 40);
static void Draw(int x, int y, char c)
{
    Console.SetCursorPosition(x, y);
    Console.Write(c);
    Console.ReadLine();
}
