using System;
using System.IO;
using System.Collections.Generic;


namespace Roguelike
{

    class MapCollector
    {
        private List<Map> allMaps = new List<Map>();
        private string[] paths = { "../../../main.map", "../../../boss.map", "../../../map3.map" };

        public MapCollector()
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string[] collectedMap = System.IO.File.ReadAllLines(paths[i]);
                allMaps.Add(new Map(collectedMap, paths.Length));
            }
            MapSolver.TransitionSolver(allMaps);
        }

        public char[,] GetDrawnMapById(int id)
        {
            return allMaps[id].drawnMap;
        }

        public Map GetMapById(int id)
        {
            return allMaps[id];
        }

        public int CanMove(int y, int x, int mapId)
        {
            if (allMaps[mapId].passable[x, y])
            {
                return 1;
            }
            return 0;
        }

        public bool Transition(Player player)
        {
            if (allMaps[player.MapId].transitionTo[player.Y, player.X] != -1)
            {
                int transitionTo = allMaps[player.MapId].transitionTo[player.Y, player.X];
                int cx = allMaps[transitionTo].transitionCoords[player.MapId].x;
                int cy = allMaps[transitionTo].transitionCoords[player.MapId].y;
                player.X = cy;
                player.Y = cx;
                player.MapId = transitionTo;
                return true;
            }
            return false;
        }
    }

    /*struct Map //вынес структуру из класса
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
        public Map getMapById(int id)
=======
        public char[,] getDrawnMapById(int id)
>>>>>>> bb48c6f35853beecc54fcc7474eec9a67eb7bbb5
        {
            return allMaps[id].drawnMap;
        }
    }*/
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
