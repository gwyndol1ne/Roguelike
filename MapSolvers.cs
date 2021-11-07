using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class MapSolver //сделал класс и его методы статичными, чтобы не создавать лишний объект класса
    {
        static public int[] ConnectionSolver(string path)
        {
            string[] split = path.Split(' ');
            int[] result = new int[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                result[i] = Convert.ToInt32(split[i]);
            }
            return result;
        }
        static public char[,] mapSplitter(string[] a, int sy, int[,] t, int[] tr, bool[,] pass) //переименуй как-нибудь понятно аргументы 
        {                                                                                       //мне понятно //мне нет
            char[,] result = new char[a.Length, sy];
            string numbers = "0123456789";
            string unpassable = "# ~";
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (numbers.Contains(a[i][j])) //я поменял IndexOf на Contains :) -молодец соси конец
                    {
                        t[i, j] = tr[Convert.ToInt32(a[i][j]) - 48];
                        result[i, j] = 'E';
                    }
                    else
                    {
                        result[i, j] = a[i][j];
                    }
                    pass[i, j] = unpassable.Contains(a[i][j]) ? false : true; // да.
                }
            }
            return result;
        }
        public static void TransitionSolver(List<Map> maps)
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
                            maps[i].transitionCoords[writeToMap].x = j;
                            maps[i].transitionCoords[writeToMap].y = k;
                        }
                    }
                }
            }
        }
    }
}
