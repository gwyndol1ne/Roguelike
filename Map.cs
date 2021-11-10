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
        public NPC[,] npcs;
        public transition[] transitionCoords;
        public int[,] transitionTo;
        public char[,] drawnMap;
        public bool[,] passable;
        public Map(string[] a, int b)
        {
            int[] connections = MapSolver.ConnectionSolver(a[a.Length - 2]);
            int sizex = a.Length - 1;
            int sizey = 0;
            for (int i = 0; i < sizex - 1; i++) sizey = sizey < a[i].Length ? a[i].Length : sizey;
            transitionCoords = new transition[b];
            chests = new Chest[sizex, sizey];
            npcs = new NPC[sizex, sizey];
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
            name = a[a.Length - 1];
            drawnMap = MapSolver.mapSplitter(a, sizey, transitionTo, connections, passable);
        }
    }
}
