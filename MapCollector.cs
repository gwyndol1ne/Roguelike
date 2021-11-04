using System;
using System.IO;
using System.Collections.Generic;

namespace Roguelike
{

    class MapCollector
    {
        private List<Map> allMaps = new List<Map>();
        private string[] paths = { "../../../main.map", "../../../boss.map" };

        public MapCollector()
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string[] collectedMap = File.ReadAllLines(paths[i]);
                allMaps.Add(new Map(collectedMap));
            }
        }

        public char[,] GetDrawnMapById(int id)
        {
            return allMaps[id].DrawnMap;
        }
    }

    struct Map //вынес структуру из класса
    {
        private Entity[,] entities;
        private int[,] transitionTo;
        private char[,] drawnMap;
        private bool[,] passable;

        public char[,] DrawnMap { get { return drawnMap; } } //сделал доступ к drawnMap через св-во

        public Map(string[] a) //переименуй массив строк как-нибудь понятно :)
        {
            int[] connections = MapSolver.ConnectionSolver(a[a.Length - 1]);
            int sizex = a.Length - 1;
            int sizey = 0;
            for (int i = 0; i < sizex - 1; i++) sizey = sizey < a[i].Length ? a[i].Length : sizey;
            entities = new Entity[sizex, sizey];
            transitionTo = new int[sizex, sizey];
            passable = new bool[sizex, sizey];
            drawnMap = MapSolver.mapSplitter(a, sizey, transitionTo, connections, passable);
        }
    }
}
