using System;
using System.IO;
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
        static public char[,] mapSplitter(string[] baseMap, int sizeY, int[,] transitionToMap, int[] transitionsText, bool[,] passable) //переименуй как-нибудь понятно аргументы //готово
        {                                                                                      
            char[,] result = new char[baseMap.Length, sizeY];
            string numbers = "0123456789";
            string unpassable = "#";
            for (int i = 0; i < baseMap.Length - 2; i++)
            {
                for (int j = 0; j < baseMap[i].Length; j++)
                {
                    if (numbers.Contains(baseMap[i][j])) //я поменял IndexOf на Contains :) -молодец
                    {
                        transitionToMap[i, j] = transitionsText[Convert.ToInt32(baseMap[i][j]) - 48];
                        result[i, j] = 'E';
                    }
                    else
                    {
                        result[i, j] = baseMap[i][j];
                    }
                    passable[i, j] = unpassable.Contains(baseMap[i][j]) ? false : true; // да.
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
        static public List<Map> MapCollector()
        {
            List<Map> allMaps = new List<Map>();
            string[] paths = { "../../../map1.map", "../../../map2.map", "../../../map3.map" };
            for (int i = 0; i < paths.Length; i++)
            {
                string[] collectedMap = File.ReadAllLines(paths[i]);
                allMaps.Add(new Map(collectedMap, paths.Length));
            }
            MapSolver.TransitionSolver(allMaps);
            return allMaps;
        }
    }
}
