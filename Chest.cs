using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Roguelike
{
    [Serializable]
    public class Chest
    {
        public List<Item> Items { get; }
        public int MapId{get;}
        public int X { get; }
        public int Y { get; }
        public Chest(int mapId, int x , int y)
        {
            Items = new List<Item>();
            MapId = mapId;
            X = x;
            Y = y;
            Maps.SetChest(mapId,x,y,this); 
        }
        public void GenerateContents(List<Item> source)
        {
            Random rng = new Random();
            int value;
            for(int i = 0; i < 3; i++)
            {
                value = rng.Next(source.Count);
                Items.Add(source[value]);
            }
        }
        public string[] GetItemNames()
        {
            string[] result = new string[Items.Count];
            for(int i = 0; i < Items.Count; i++)
            {
                result[i] = Items[i].Name;
            }
            return result;
        }

        public void DeleteItem(int index)
        {
            Items.RemoveAt(index);
        }
        public Item GetItemByIndex(int i)
        {
            return Items[i];
        }
        public int ChestItemsAmount()
        {
            return Items.Count;
        }
    }
}
