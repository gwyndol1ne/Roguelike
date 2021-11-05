using System;
using System.IO;
using System.Collections.Generic;


namespace Roguelike
{

    class MapCollector
    {
        public List<Map> allMaps = new List<Map>();
        string[] paths = { "../../../main.map", "../../../boss.map", "../../../map3.map" };
        public MapCollector()
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string[] collectedMap = System.IO.File.ReadAllLines(paths[i]);
                allMaps.Add(new Map(collectedMap, paths.Length));
            }
            MapSolver.TransitionSolver(allMaps);
        }
        public char[,] getDrawnMapById(int id)
        {
            return allMaps[id].drawnMap;
        }
    }
    public struct Map
    {
        public transition[] transitionCoords;
        public int[,] transitionTo;
        public char[,] drawnMap;
        public bool[,] passable;
        public Map(string[] a, int b)
        {
            int[] connections = MapSolver.ConnectionSolver(a[a.Length - 1]);
            int sizex = a.Length - 1;
            int sizey = 0;
            for (int i = 0; i < sizex - 1; i++) sizey = sizey < a[i].Length ? a[i].Length : sizey;
            transitionCoords = new transition[b];
            transitionTo = new int[sizex, sizey];
            for(int i = 0; i < sizex; i++)
            {
                for(int j = 0; j < sizey; j++)
                {
                    transitionTo[i, j] = -1;
                }
            }
            drawnMap = new char[sizex, sizey];
            passable = new bool[sizex, sizey];
            drawnMap = MapSolver.mapSplitter(a, sizey,transitionTo , connections, passable);
        }
    }
}
