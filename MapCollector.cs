using System;
using System.IO;
using System.Collections.Generic;

namespace Roguelike
{
    public class MapCollector
    {
        List<Map> allMaps = new List<Map>();
        string[] paths = { "../../../main.map", "../../../boss.map" };
        public struct Map
        {
            Entity[,] entities;
            int[,] transitionTo;
            public char[,] drawnMap;
            bool[,] passable;
            public Map(string[] a)
            {
                MapSolver solver = new MapSolver();
                int[] connections = solver.ConnectionSolver(a[a.Length-1]);
                int sizex = a.Length-1;
                int sizey = 0;
                for(int i = 0; i < sizex-1; i++) sizey = sizey < a[i].Length ? a[i].Length : sizey;
                entities = new Entity[sizex,sizey];
                transitionTo = new int[sizex, sizey];
                drawnMap = new char[sizex, sizey];
                passable = new bool[sizex, sizey];
                drawnMap = solver.mapSplitter(a,sizey,transitionTo,connections,passable);
            }
        }
        public MapCollector()
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string[] collectedMap = System.IO.File.ReadAllLines(paths[i]);
                allMaps.Add(new Map(collectedMap));
            }
        }
        public char[,] GetDrawnMapById(int id)
        {
            return allMaps[id].drawnMap;
        }
    }
}
