using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class Maps
    {
        static private bool initialised = false;
        static private List<Map> allMaps;
        static public void Initialise()
        {
            if (!initialised)
            {
                allMaps = MapSolver.MapCollector();
                initialised = true;
            }
        }
        static public char [,] GetDrawnMap(int mapId)
        {
            return allMaps[mapId].drawnMap;
        }
        static public string GetMapName(int mapId)
        {
            return allMaps[mapId].name;
        }
        static public int CanMoveTo(int mapId, int x, int y)
        {
            if (allMaps[mapId].passable[y, x])
            {
                return 1;
            }
            return 0;
        }
        static public int[,] GetTransitionsTo(int mapId)
        {
            return allMaps[mapId].transitionTo;
        }
        static public transition GetTransitionCoords(int fromMapId, int toMapId)
        {
            return allMaps[fromMapId].transitionCoords[toMapId];
        }
        static public void SetChest(int mapId ,int x, int y, Chest chest)
        {
            if (allMaps[mapId].chests[x, y] == null)
            {
                allMaps[mapId].chests[x, y] = chest;
                allMaps[mapId].passable[x, y] = false;
                allMaps[mapId].drawnMap[x, y] = 'C';
            }
        }
        static public bool ChestHere(int mapId, int x,int y)
        {
            if (allMaps[mapId].chests[y, x] != null)
            {
                return true;
            }
            return false;
        }
        public static string[] GetChestItems(int mapId, int x, int y)
        {
            string[] chestItems = allMaps[mapId].chests[y, x].GetItemNames();
            string[] result = new string[chestItems.Length + 1];
            for(int i = 0; i < chestItems.Length; i++)
            {
                result[i] = chestItems[i];
            }
            result[result.Length - 1] = "Вернуться в игру";
            return result;
        }
        public static Item GetItemFromChest(int mapId, int x, int y, int index)
        {
            Chest chest = allMaps[mapId].chests[y, x];
            Item result = chest.GetItemByIndex(index);
            chest.DeleteItem(index);
            return result;
        }
    }
}
