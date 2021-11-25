using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public struct Map
    {
        public Entity[,] entities;
        public string name;
        public Chest[,] chests;
        public point[] transitionCoords;
        public int[,] transitionTo;
        public char[,] drawnMap;
        public bool[,] passable;
        public Map(string[] map, int numberOfMaps)
        {
            int[] connections = MapSolver.ConnectionSolver(map[map.Length - 2]);
            int sizex = map.Length - 1;
            int sizey = 0;
            for (int i = 0; i < sizex - 1; i++) sizey = sizey < map[i].Length ? map[i].Length : sizey;
            transitionCoords = new point[numberOfMaps+1];
            chests = new Chest[sizex, sizey];
            entities = new Entity[sizex, sizey];
            transitionTo = new int[sizex, sizey];
            for (int i = 0; i < sizex; i++)
            {
                for (int j = 0; j < sizey; j++)
                {
                    transitionTo[i, j] = -1;
                }
            }
            drawnMap = new char[sizex, sizey];
            passable = new bool[sizex, sizey];
            name = map[map.Length - 1];
            drawnMap = MapSolver.mapSplitter(map, sizey, transitionTo, connections, passable);
        }
    }
}
