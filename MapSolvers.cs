using System;
using System.Collections.Generic;
using System.Text;
using connections;

namespace mapsolvers
{
    class MapSolver
    {
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
            string[] result = map;
            string numbers = "1234567890";
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (numbers.IndexOf(map[i][j]) >= 0)
                    {
                        map[i].ToCharArray()[j] = '#';
                    }
                }
            }
            return result;
        }
        public bool[,] SolverStandable(string[] map, string unstandable)
        {
            bool[,] result = new bool[map.Length, map[0].Length];
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
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
