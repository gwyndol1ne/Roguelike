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
        public static void drawBool(bool[,] screen)
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                Console.SetCursorPosition(xoffset, yoffset + i);
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.Write("{0} ", screen[i, j]?".":"#");
                }
                Console.WriteLine();
            }
        }
        public static void draw(char[,] screen)
        {
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                Console.SetCursorPosition(xoffset, yoffset + i);
                for (int j = 0; j < screen.GetLength(1); j++)
                {switch (screen[i, j])
                    {
                        case '#':
                        Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case '.':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '$':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'C':
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        
                    }    
                    Console.Write("{0} ",screen[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        public static void DrawAtPos(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x*2 + xoffset, y + yoffset);
            if (symbol=='@')
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            if (symbol == 'N')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (symbol == '$')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (symbol == 'E')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(symbol);
            Console.ResetColor();
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
