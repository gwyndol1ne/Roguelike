using System;
using System.IO;
using System.Collections.Generic;


namespace Roguelike
{

    public class MapCollector
    {
        private List<Map> allMaps = new List<Map>();
        private string[] paths = { "../../../main.map", "../../../boss.map", "../../../map3.map" };

        public MapCollector()
        {
            for (int i = 0; i < paths.Length; i++)
            {
                string[] collectedMap = File.ReadAllLines(paths[i]);
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

        public int CanMove(int x, int y, int mapId)
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
        
        public void AddChest(int mapId, Chest chest, int x, int y)
        {
            allMaps[mapId].chests[x, y] = chest;
            allMaps[mapId].passable[x, y] = false;
            allMaps[mapId].drawnMap[x, y] = 'C';
        }
        
        public bool CheckChest(int mapId, int x, int y)
        {
            if (allMaps[mapId].chests[y,x] != null)
            {
                return true;
            }
            return false;
        }
        
        public string[] GetChestItems(int mapId, int x, int y)
        {
            Chest chest = allMaps[mapId].chests[y, x];
            string[] chestItems = chest.GetItemNames();
            string[] result = new string[chestItems.Length + 1];
            for(int i = 0; i < chestItems.Length; i++)
            {
                result[i] = chestItems[i];
            }
            result[result.Length - 1] = "Вернуться в игру";
            return result;

        }
        public Chest GetChest(int mapId, int x, int y)
        {
            return allMaps[mapId].chests[y, x];
        }
    }

    public struct Map
    {
        public string name;
        public Chest [,] chests;
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
            name = a[a.Length - 1];
            drawnMap = MapSolver.mapSplitter(a, sizey,transitionTo , connections, passable);
        }
    }
}
