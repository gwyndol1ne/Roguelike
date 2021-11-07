using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class Draw
    {
        public static int xoffset = 5;
        public static int yoffset = 2;
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
        public static void DrawAtPos(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x + xoffset, y + yoffset);
            Console.WriteLine(symbol);
        }
        public static void ReDrawMap(Map map, int x, int y, char symbol)
        {
            Console.Clear();
            Draw.draw(map.drawnMap);
            Draw.DrawAtPos(x, y, symbol);
        }
    }
}
