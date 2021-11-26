using System;
using System.Collections.Generic;
using System.Text;
//Класс для создания карт и использования информации с них, включая некоторые обработчики
namespace Roguelike
{
    static class Maps
    {
        public enum CantGoBecause //Причина невозможности движения
        {
            Wall = 0,
            Chest = 1,
            Enemy = 2,
            Friend = 3,
            Player = 4,
        }
        static private List<Map> allMaps; //Список всех карт в порядке, в котором их пути идут в string[] paths из MapSolver.MapCollector
        static public void Initialise() //Запись всех карт в allMaps (!!! стирает всю информацию с них, которая была записана во время выполнения)
        {
            allMaps = MapSolver.MapCollector();
            allMaps[0].transitionCoords[3] = new point(1, 1);
            allMaps[0].transitionTo[1, 1] = 3;
            allMaps[0].drawnMap[1, 1] = 'E';
            allMaps.Add(Generation.GenerateMap());
        }
        static public char [,] GetDrawnMap(int mapId) //Возвращает карту в удобном для отображения в консоли формате
        {
            return allMaps[mapId].drawnMap;
        }
        static public string GetMapName(int mapId) //Возвращает название карты (пишется в оригинальном файле с расширением .map последней строчкой)
        {
            return allMaps[mapId].name;
        }
        static public int CanMoveTo(int mapId, int x, int y) //Проверяет возможность Entity передвинуться в какую-либо клетку (клетка может быть занята другим Entity)
        {
            if (allMaps[mapId].passable[y, x]) return 1;
            return 0;
        }
        static public int CantMoveBecause(int mapId, int x, int y) //Возвращает причину, по которой Entity не может передвинуться в клетку
        {
            if (allMaps[mapId].chests[y, x] != null) return (int)CantGoBecause.Chest; //Так как Chest не является Entity, сначала проверяется он
            else if (allMaps[mapId].entities[y, x] != null)                           //Потом идут проверки самих Entity
            {
                if(allMaps[mapId].entities[y, x] is Enemy) return (int)Maps.CantGoBecause.Enemy;
                else if (allMaps[mapId].entities[y, x] is NPC) return (int)Maps.CantGoBecause.Friend;
                else if (allMaps[mapId].entities[y, x] is Player) return (int)Maps.CantGoBecause.Player;
            }
            return (int)CantGoBecause.Wall;                                           //Иначе причиной становится стена
        }
                                                        
        static public int[,] GetTransitionsTo(int mapId)//Возвращает массив с номерами карт, на которые осуществляется переход в каждой клетке
        {                                               //Если в какой-то клетке нет перехода, ее значение будет равно -1
            return allMaps[mapId].transitionTo;
        }
        static public point GetTransitionCoords(int fromMapId, int toMapId) //Возвращает точку перехода
        {
            return allMaps[fromMapId].transitionCoords[toMapId];
        }
        static public void SetChest(int mapId ,int x, int y, Chest chest) //Ставит сундук по координатам, если они еще не заняты
        {
            if (!Maps.ChestHere(mapId,x,y))
            {
                allMaps[mapId].chests[x, y] = chest;
                allMaps[mapId].passable[x, y] = false;
                allMaps[mapId].drawnMap[x, y] = 'C';
            }
        }
        static public bool ChestHere(int mapId, int x,int y) //Возвращает true, если по указанным координатам находится сундук
        {
            if (allMaps[mapId].chests[y, x] != null) return true;
            return false;
        }
        public static string[] GetChestItems(int mapId, int x, int y) //Возвращает имена всех предметов в сундуке и некоторые дополнительные строки
        {
            string[] chestItems = allMaps[mapId].chests[y, x].GetItemNames();
            int emptyChest = chestItems.Length == 0 ? 0 : 1;                      //Если в сундуке нет предметов, то emptyChest = 0 (не логично, но удобней для следующей строки)
            string[] result = new string[chestItems.Length + 1 + emptyChest];     //Длина возвращаемого массива на 1 больше количества предметов в сундуке и еще на 1 больше, если в сундуке есть предметы
            for(int i = 0; i < chestItems.Length; i++) result[i] = chestItems[i];   
            if (emptyChest == 1) result[result.Length - 2] = "Забрать все";       //Если в сундуке есть предметы, предпоследняя строка будет "Забрать все"
            result[result.Length - 1] = "Вернуться в игру";                       //В любом случае последняя строка - "Вернуться в игру"
            return result;
        }
        public static Item GetItemFromChest(int mapId, int x, int y, int index) //Получить предмет по индексу из сундука
        {
            Chest chest = allMaps[mapId].chests[y, x];
            Item result = chest.GetItemByIndex(index);
            chest.DeleteItem(index);
            return result;
        }
        public static Item GetItemFromNPC(int mapId, int x, int y, int index) //Получить предмет NPC по индексу, желательно совместить с GetItemFromChest(GetItemFromInventory?)
        {
            NPC  Npc = (NPC)allMaps[mapId].entities[y, x];
            Item result = Npc.NPCInventory[index];
            Npc.NPCInventory.RemoveAt(index);
            return result;
        }
        public static Item[] GetAllItemsFromChest(int mapId,int x, int y) //Получить все предметы из сундука
        {
            Chest chest = allMaps[mapId].chests[y, x];
            Item[] result = new Item[chest.ChestItemsAmount()];
            for(int i = 0; i < result.Length; i++) result[i] = GetItemFromChest(mapId, x, y, 0);
            return result;
        }
        public static Item[] GetAllItemsFromNPC(int mapId, int x, int y) //Получить все предметы NPC, также желательно совместить с GetAllItemsFromChest
        {
            NPC  Npc = (NPC)allMaps[mapId].entities[y, x];
            Item[] result =new Item[Npc.NPCInventory.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GetItemFromNPC(mapId, x, y, 0);
            }
            Npc.GetTiefsItemNames().RemoveAt(0);
            return result;
        }
        public static void SetEntity(int mapId, int x, int y , Entity entity)
        {
            allMaps[mapId].entities[y,x] = entity;
            allMaps[mapId].passable[y, x] = false;
        }
        public static void DelEntity(int mapId, int x, int y)
        {
            allMaps[mapId].entities[y, x] = null;
            allMaps[mapId].passable[y, x] = true;
        }
        public static void MoveEntity(int mapId, int x, int y, int moveX, int moveY , Entity entity)
        {
            DelEntity(mapId, x, y);
            SetEntity(mapId, x + moveX, y + moveY, entity);
        }
        public static List<Entity> GetEntities(int mapId)
        {
            List<Entity> result = new List<Entity>();
            foreach(Entity entity in allMaps[mapId].entities) if(entity != null) result.Add(entity);
            return result;
        }
        public static Entity GetEntity(int mapId, int x, int y)
        {
            return allMaps[mapId].entities[y, x];
        }
        public static Entity[] GetNearEntities(int mapId, int x, int y)
        {
            List<Entity> pResult = new List<Entity>();
            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    if (allMaps[mapId].entities[y + i , x + j] is /* я индус everybody wants to be my*/ Enemy )
                    {
                        pResult.Add(allMaps[mapId].entities[y + i, x + j]);
                    }
                }
            }
            Entity[] result = new Entity[pResult.Count];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = pResult[i];
            }
            return result;
        }
        public static bool[,] GetPassable(int mapId)
        {
            return allMaps[mapId].passable;
        }
        public static void EnemyMovement(int mapId, int x, int y)
        {
            Entity[,] currentMapEntities = allMaps[mapId].entities;
            List<Entity> entitiesToMove = new List<Entity>();
            for (int i = 0; i < currentMapEntities.GetLength(0); i++) for (int j = 0; j < currentMapEntities.GetLength(1); j++) if (currentMapEntities[i, j] is Enemy) entitiesToMove.Add(currentMapEntities[i, j]);
            foreach(Entity entity in entitiesToMove) entity.MoveTowards(x, y);
        }
    }
}