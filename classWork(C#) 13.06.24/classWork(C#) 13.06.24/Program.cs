using System;

namespace classWork_C___13._06._24
{
    public enum MazeObject { HALL, WALL, COIN, ENEMY, BORDER };
    
    internal class Program
    {
        static Random random = new Random();

        static void Walls(int x, int y, int width, int height, int[,] arr, MazeObject obj)
        {
            if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
            {
                arr[y, x] = (int)obj;
            }
        }

        static void Reduction(int x, int y, int[,] arr, MazeObject ob, MazeObject obj, int probability)
        {
            if (arr[y, x] == (int)ob)
            {
                int r = random.Next(probability);
                if (r != 0)
                {
                    arr[y, x] = (int)obj;
                }
            }
        }

        static void SetCursor(int x, int y, ConsoleColor color, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            int width = 60;
            int height = 20;
            int X = 2;
            int Y = 2;
            int[,] maze = new int[height, width];

            Console.CursorVisible = false;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    maze[y, x] = random.Next(5);
                    Walls(x, y, width, height, maze, MazeObject.WALL);
                    Reduction(x, y, maze, MazeObject.ENEMY, MazeObject.HALL, 10);
                    Reduction(x, y, maze, MazeObject.BORDER, MazeObject.HALL, 20);

                    if (maze[y, x] == (int)MazeObject.HALL)
                    {
                        SetCursor(x, y, ConsoleColor.Black, "");
                    }
                    else if (maze[y, x] == (int)MazeObject.WALL)
                    {
                        SetCursor(x, y, ConsoleColor.DarkBlue, Convert.ToChar(0x2593).ToString());
                    }
                    else if (maze[y, x] == (int)MazeObject.COIN)
                    {
                        SetCursor(x, y, ConsoleColor.Yellow, ".");
                    }
                    else if (maze[y, x] == (int)MazeObject.ENEMY)
                    {
                        SetCursor(x, y, ConsoleColor.Red, Convert.ToChar(0x1).ToString());                      
                    }
                    else if (maze[y, x] == (int)MazeObject.BORDER)
                    {
                        SetCursor(x, y, ConsoleColor.Red, "");
                    }
                }
            }

            Console.SetCursorPosition(X, Y);
            Console.Write((char)1);

            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);

                Console.SetCursorPosition(X, Y);
                Console.Write(" ");

                if (k.Key == ConsoleKey.LeftArrow && X > 0 && maze[Y, X - 1] != (int)MazeObject.WALL)
                {
                    X--;
                }
                else if (k.Key == ConsoleKey.RightArrow && X < width - 1 && maze[Y, X + 1] != (int)MazeObject.WALL)
                {
                    X++;
                }
                else if (k.Key == ConsoleKey.UpArrow && Y > 0 && maze[Y - 1, X] != (int)MazeObject.WALL)
                {
                    Y--;
                }
                else if (k.Key == ConsoleKey.DownArrow && Y < height - 1 && maze[Y + 1, X] != (int)MazeObject.WALL)
                {
                    Y++;
                }

                Console.SetCursorPosition(X,Y);
                Console.Write((char)1);
            }
        }
    }
}