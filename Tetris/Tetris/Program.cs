using Tetris;
Console.SetWindowSize(30, 40);
Console.SetBufferSize(30, 40);
Stick s2 = new Stick(3,3,'*');
s2.Draw();
Thread.Sleep(500);
s2.Hide();
s2.Rotate();
s2.Draw();
Thread.Sleep(500);
s2.Hide();
s2.Rotate();
s2.Draw();



















Console.ReadLine();