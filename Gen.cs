using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Gen
    {
        static point size;
        static bool Inside(point point)
        {
            if (point.x >= size.x - 1 || point.x <= 0 || point.y >= size.y - 1 || point.y <= 0) return false;
            return true;
        }

        static point Dir(int choice)
        {
            switch (choice)
            {
                case 0:
                    return new point(1, 0);
                case 1:
                    return new point(-1, 0);
                case 2:
                    return new point(0, 1);
                default:
                    return new point(0, -1);
            }      
        }
        public static bool[,] Generate(int sizeX, int sizeY)
        {
            bool[,] passable = new bool[sizeX, sizeY];
            size = new point(sizeX, sizeY);
            Random rnd = new Random();
            point current = new point(1,1);
            point move;
            for(int i = 0; i < 888; i++)
            {
                passable[current.x, current.y] = true;
                move = Dir(rnd.Next(0, 4));
                while (!Inside(new point(current.x+move.x,current.y+move.y)))
                {
                    move = Dir(rnd.Next(0, 4));
                }
                current = new point(current.x + move.x, current.y + move.y);
            }
            return passable;
        }
    }
}
