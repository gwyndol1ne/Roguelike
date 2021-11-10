using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Chest
    {
        List<Item> items;
        public Chest(int mapId, int x , int y)
        {
            items = new List<Item>();
            Maps.SetChest(mapId,x,y,this); 
        }
        public void GenerateContents(List<Item> source)
        {
            Random rng = new Random();
            int value;
            for(int i = 0; i < 3; i++)
            {
                value = rng.Next(source.Count);
                items.Add(source[value]);
            }
        }
        public string[] GetItemNames()
        {
            string[] result = new string[items.Count];
            for(int i = 0; i < items.Count; i++)
            {
                result[i] = items[i].Name;
            }
            return result;
        }
        public void DeleteItem(int index)
        {
            items.RemoveAt(index);
        }
        public Item GetItemByIndex(int i)
        {
            return items[i];
        }
    }
}
