using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Generation
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
        public static int[,] Generate(int sizeX, int sizeY)
        {
            int[,] passable = new int[sizeX, sizeY];
            size = new point(sizeX, sizeY);
            Random rnd = new Random();
            point current = new point(1,1);
            point move;
            for (int i = 0; i < sizeX; i++) for (int j = 0; j < sizeY; j++) passable[i, j] = 1;
            for(int i = 0; i < 888; i++)
            {
                passable[current.x, current.y] = (i == 444) || (passable[current.x, current.y] == 2) ? 2 : 0;
                move = Dir(rnd.Next(0, 4));
                while (!Inside(new point(current.x+move.x,current.y+move.y))) move = Dir(rnd.Next(0, 4));
                current = new point(current.x + move.x, current.y + move.y);
            }
            return passable;
        }
        static bool[,] ToDeleteWalls(int[,] map)
        {
            bool[,] result = new bool[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++) for (int j = 0; j < result.GetLength(1); j++) if (CountAdjasentWalls(i, j, map) == 0) result[i, j] = true;
            return result;
        }
        static int CountAdjasentWalls(int x, int y, int[,] map)
        {
            List<point> move = new List<point> { new point(0, 1), new point(0, -1), new point(1, 0), new point(-1, 0) };
            if (x == 0) move.Remove(new point(-1, 0));
            else if (x == map.GetLength(0) - 1) move.Remove(new point(1, 0));
            if (y == 0) move.Remove(new point(0,-1));
            else if (y == map.GetLength(1) - 1) move.Remove(new point(0,1));
            int result = 0;
            for (int i = 0; i < move.Count; i++) if (map[x + move[i].x, y + move[i].y] != 1) result++;
            //List<point> additionalMoves = new List<point>();
            //for (int i = 0; i < move.Count; i++) for (int j = i + 1; j < move.Count; j++) if (move[i].x != move[j].x) additionalMoves.Add(new point(move[i].x + move[j].x, move[i].y+ move[j].y));
            //for (int i = 0; i < additionalMoves.Count; i++) if (map[x + additionalMoves[i].x, y + additionalMoves[i].y] == 0) result++;
            return result;
        }
        public static int[,] CleanInt(int[,] map)
        {
            bool[,] ToDelete = ToDeleteWalls(map);
            for (int i = 0; i < ToDelete.GetLength(0); i++) for (int j = 0; j < ToDelete.GetLength(1); j++) if (ToDelete[i, j]) map[i, j] = -1;
            return map;
        }
        static char IntToChar(int n)
        {
            switch (n)
            {
                case 0:
                    return '.';
                case 1:
                    return '#';
                case 2:
                    return 'C';
                case 3:
                    return '$';
                default:
                    return ' ';
            }
        }
        static public char[,] IntToCharMap(int[,] map)
        {
            char[,] result = new char[map.GetLength(0), map.GetLength(1)];
            for (int i = 0; i < map.GetLength(0); i++) for (int j = 0; j < map.GetLength(1); j++) result[i, j] = IntToChar(map[i, j]);
            return result;
        }
        static int[,] PlaceEnemies(int[,] map, int amount)
        {
            int[,] result = map;
            List<point> pointsToConsider = new List<point>();
            point set;
            for (int i = 0; i < map.GetLength(0); i++) for (int j = 0; j < map.GetLength(1); j++) if (map[i, j] == 0) pointsToConsider.Add(new point(i, j));
            for(int i = 1; i <= amount; i++)
            {
                set = pointsToConsider[(pointsToConsider.Count-1) / (amount+1)*i];
                result[set.x, set.y] = 3;
            }
            return result;
        }
        public static char[,] GenerateCharMap(int sizeX, int sizeY)
        {
            return IntToCharMap(PlaceEnemies(CleanInt(Generate(sizeX, sizeY)),5));
        }
        public static Map GenerateMap()
        {
            return new Map(IntToCharMap(CleanInt(Generate(20, 23))),4);
        }
    }
}
