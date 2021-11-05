using System;
using System.IO;
using System.Collections.Generic;


namespace Roguelike
{
    public class MapCollector
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
            MapSolver solver = new MapSolver();
            solver.TransitionSolver(allMaps);
        }
        public char[,] getDrawnMapById(int id)
        {
            return allMaps[id].drawnMap;
        }
        public Map getMapById(int id)
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
                int transitionTo = allMaps[player.MapId].transitionTo[player.Y,player.X];
                int cx = allMaps[player.MapId].transitionCoords[transitionTo].x;
                int cy = allMaps[player.MapId].transitionCoords[transitionTo].y;
                player.X = cy;
                player.Y = cx;
                player.MapId = transitionTo;
                return true;
            }
            return false;
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
            MapSolver solver = new MapSolver();
            int[] connections = solver.ConnectionSolver(a[a.Length - 1]);
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
            drawnMap = solver.mapSplitter(a, sizey,transitionTo , connections, passable);
        }
    }
}
