using System;
using System.Collections.Generic;
using System.Text;
using Connections;
using Mapcollector;

namespace Mapsolvers
{
    class MapSolver
    {
        public int DecideLength(string[] input)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result = input[i].Length > result ? input[i].Length : result;
            }
            return result;
        }
        public List<Connection> ConnectionSolver(string[] map)
        {
            int index = 0;
            string numbers = "0123456789";
            List<Connection> result = new List<Connection>();
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    index = numbers.IndexOf(map[i][j]);
                    if (index >= 0)
                    {
                        result.Add(new Connection(i, j, index));
                    }
                }
            }
            return result;
        }
        public string[] SolverDrawnMap(string[] map)
        {
            int maxLength = DecideLength(map);
            char[][] result = new char[map.Length][];
            for(int i = 0; i < map.Length; i++)
            {
                result[i] = new char[maxLength];
            }
            string numbers = "0123456789";
            for (int i = 0; i < map.Length; i++)
            {
                for(int j = 0; j < map[i].Length; j++)
                {
                    result[i][j] = numbers.IndexOf(map[i][j]) >= 0 ? 'O' : map[i][j];
                }
            }
            string[] actualResult = new string[result.Length];
            for(int i = 0; i < result.Length; i++)
            {
                actualResult[i] = new string(result[i]);
            }
            return actualResult;
        }
        public bool[,] SolverStandable(string[] map, string unstandable)
        {
            int maxLength = DecideLength(map);
            bool[,] result = new bool[map.Length, maxLength];
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < maxLength; j++)
                {
                    if (unstandable.IndexOf(map[i][j]) >= 0)
                    {
                        result[i, j] = false;
                    }
                }
            }
            return result;
        }
        
    }
}
