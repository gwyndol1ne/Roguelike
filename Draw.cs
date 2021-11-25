using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class Draw
    {
        public static int xoffset = 5;
        public static int yoffset = 2;
        public static int currentMapId;
        public static void draw(char[,] screen)
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                Console.SetCursorPosition(xoffset, yoffset + i);
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.Write("{0} ",screen[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void DrawAtPos(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x*2 + xoffset, y + yoffset);
            Console.WriteLine(symbol);
        }
        public static void ReDrawMap(char[,] drawnMap, int mapId)
        {
            Console.Clear();
            Draw.draw(drawnMap);
            foreach(Entity entity in Maps.GetEntities(currentMapId))
            {
                DrawAtPos(entity.X, entity.Y, entity.Symbol); //why not work
            }
        }
    }
}
