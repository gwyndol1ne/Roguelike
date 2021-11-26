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
        public Map(char[,] tiles, int numberOfMaps)
        {
            int sizeX = tiles.GetLength(0);
            int sizeY = tiles.GetLength(1);
            passable = new bool[sizeX, sizeY];
            for(int i = 0;i<sizeX;i++) for(int j = 0; j < sizeY; j++)
                {
                    if (tiles[i, j] == '#' || tiles[i, j] == ' ') passable[i, j] = false;
                    else passable[i, j] = true;
                }
            transitionCoords = new point[numberOfMaps + 1];
            drawnMap = tiles;
            drawnMap[1, 1] = 'E';
            chests = new Chest[sizeX, sizeY];
            entities = new Entity[sizeX, sizeY];
            transitionTo = new int[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++) for (int j = 0; j < sizeY; j++) transitionTo[i, j] = -1;
            transitionTo[1, 1] = 0;
            transitionCoords[0] = new point(1, 1);
            name = "Данж";
        }
    }
}
