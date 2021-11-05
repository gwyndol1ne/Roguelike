using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Draw
    {
        public void draw(char[,] screen)
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.Write(screen[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
