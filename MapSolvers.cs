using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class MapSolver
    {
        public int[] ConnectionSolver(string path)
        {
            string[] split = path.Split(' ');
            int[] result = new int[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                result[i] = Convert.ToInt32(split[i]);
            }
            return result;
        }
        public char[,] mapSplitter(string[] a, int sy, int[,] t, int[] tr, bool[,] pass)
        {
            char[,] result = new char[a.Length, sy];
            string numbers = "0123456789";
            string unpassable = "# ~";
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (numbers.IndexOf(a[i][j]) >= 0)
                    {
                        t[i, j] = tr[Convert.ToInt32(a[i][j]) - 48];
                        result[i, j] = 'E';
                    }
                    else
                    {
                        result[i, j] = a[i][j];
                    }
                    if (unpassable.IndexOf(a[i][j]) >= 0)
                    {
                        pass[i, j] = false;
                    }
                    else
                    {
                        pass[i, j] = true;
                    }
                }
            }
            return result;
        }
        public void TransitionSolver(List<Map> maps)
        {
            int writeToMap;
            for (int i = 0; i < maps.Count; i++)
            {
                for (int j = 0; j < maps[i].transitionTo.GetLength(0); j++)
                {
                    for (int k = 0; k < maps[i].transitionTo.GetLength(1); k++)
                    {
                        if (maps[i].transitionTo[j, k] != -1)
                        {
                            writeToMap = maps[i].transitionTo[j, k];
                            maps[writeToMap].transitionCoords[i].x = j;
                            maps[writeToMap].transitionCoords[i].y = k;
                        }
                    }
                }
            }
        }
    }
}
