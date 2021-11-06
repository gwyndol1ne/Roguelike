using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class Draw
    {
        public static int xoffset = 3;
        public static int yoffset = 3;
        public static void draw(char[,] screen)
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                Console.SetCursorPosition(xoffset,yoffset + i);
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.Write(screen[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
