using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Roguelike
{
    class ItemCollector
    {
        string[] lines;
        private int readFrom;
        private List<Item> allItems;
        public ItemCollector()
        {
            allItems = new List<Item>();
            lines = File.ReadAllLines("../../../items.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == ";;")
                {
                    readFrom = i + 1;
                    break;
                }
            }
            for (int i = readFrom; i < lines.Length; i++)
            {
                string[] identificators = lines[i].Split(':');
                int id = Convert.ToInt32(identificators[0]);
                string name = identificators[1];
                Item.Slot slot = (Item.Slot)Convert.ToInt32(identificators[2]);
                if (identificators[3] == "w")
                {
                    allItems.Add(WeaponResolver(identificators, id, name, slot));
                }
                else if (identificators[3] == "a")
                {
                    allItems.Add(ArmorResolver(identificators, id, name, slot));
                }
            }
        }
        private Weapon WeaponResolver(string[] identificators, int id, string name, Item.Slot slot) //
        {
            int dmg = Convert.ToInt32(identificators[4]);
            char scale = Convert.ToChar(identificators[5]);
            Weapon result = new Weapon(id, name, dmg, slot, scale);
            return result;
        }
        private Armor ArmorResolver(string[] identificators, int id, string name, Item.Slot slot)
        {
            int def = Convert.ToInt32(identificators[3]);
            int s = Convert.ToInt32(identificators[4]);
            int a = Convert.ToInt32(identificators[5]);
            int i = Convert.ToInt32(identificators[6]);
            Armor result = new Armor(id, name, def, slot, s, a, i);
            return result;
        }
    }
}
