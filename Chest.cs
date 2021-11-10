using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Chest
    {
        public List<Item> Items { get; }

        public Chest(int mapId, int x , int y, MapCollector collector)
        {
            Items = new List<Item>();
            collector.AddChest(mapId, this, x, y); 
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
    }
}
