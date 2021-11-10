using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class Maps
    {
        public enum CantGoBecause
        {
            Wall = 0,
            Chest = 1,
            Entity = 2,
        }

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
            if (allMaps[mapId].passable[y, x]) return 1;
            return 0;
        }
        static public int CantMoveBecause(int mapId, int x, int y)
        {
            if (allMaps[mapId].chests[y, x] != null) return (int)CantGoBecause.Chest;
            else if (allMaps[mapId].entities[y, x] != null) return (int)CantGoBecause.Entity;
            return (int)CantGoBecause.Wall;
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
            if (allMaps[mapId].chests[y, x] != null) return true;
            return false;
        }
        static public bool checkNpc(int mapId, int x, int y)
        {
            if (allMaps[mapId].npcs[y, x] != null) return true;
            return false;
        }
        public static string[] GetChestItems(int mapId, int x, int y)
        {
            string[] chestItems = allMaps[mapId].chests[y, x].GetItemNames();
            int emptyChest = chestItems.Length == 0 ? 0 : 1;
            string[] result = new string[chestItems.Length + 1 + emptyChest];
            for(int i = 0; i < chestItems.Length; i++) result[i] = chestItems[i];
            if (emptyChest == 1) result[result.Length - 2] = "Забрать все";
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
        public static Item[] GetAllItemsFromChest(int mapId,int x, int y)
        {
            Chest chest = allMaps[mapId].chests[y, x];
            Item[] result = new Item[chest.ChestItemsAmount()];
            for(int i = 0; i < result.Length; i++) result[i] = GetItemFromChest(mapId, x, y, 0);
            return result;
        }
        public static void SetEntity(int mapId, int x, int y , Entity entity)
        {
            allMaps[mapId].entities[y,x] = entity;
            allMaps[mapId].passable[y,x] = false;
        }
        public static void MoveEntity(int mapId, int x, int y, int moveX, int moveY , Entity entity)
        {
            allMaps[mapId].entities[y,x] = null;
            allMaps[mapId].passable[y,x] = true;
            SetEntity(mapId, x+moveX, y+moveY, entity);
        }
        public static List<Entity> GetEntities(int mapId)
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity entity in allMaps[mapId].entities) if (entity != null) result.Add(entity);
            return result;
        }
    }
}
