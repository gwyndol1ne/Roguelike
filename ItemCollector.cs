using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class ItemCollector
    {
        string[] lines;
        private int readFrom;
        public List<Item> allItems;
        public ItemCollector()
        {
            allItems = new List<Item>();
            lines = System.IO.File.ReadAllLines("../../../items.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == ";;")
                {
                    readFrom = i + 1;
                    break;
                }
            }
            for(int i = readFrom; i < lines.Length; i++)
            {
                string[] identificators = lines[i].Split(':');
                int id = Convert.ToInt32(identificators[0]);
                string name = identificators[1];
                if(identificators[2] == "w")
                {
                    allItems.Add(WeaponResolver(identificators,id,name));
                }
                else if(identificators[2] == "a")
                {
                    allItems.Add(ArmorResolver(identificators, id, name));
                }
            }
        }
        protected Weapon WeaponResolver(string[] identificators, int id, string name)
        {
            int dmg = Convert.ToInt32(identificators[3]);
            bool oneHanded = identificators[4] == "t" ? true : false;
            char scale = Convert.ToChar(identificators[5]);
            Weapon result = new Weapon(id, name, dmg, oneHanded, scale);
            return result;
        }
        protected Armor ArmorResolver(string[] identificators, int id, string name)
        {
            int def = Convert.ToInt32(identificators[3]);
            char slot = Convert.ToChar(identificators[4]);
            int s = Convert.ToInt32(identificators[5]);
            int a = Convert.ToInt32(identificators[6]);
            int i = Convert.ToInt32(identificators[7]);
            Armor result = new Armor(id, name, def, slot, s, a, i);
            return result;
        }
        protected Consumable ConsumableResolver(string[] identificators, int id, string name)
        {
            Consumable result = new Consumable(id, name);
            return result;
        }
        public List<Item> GetItemList
        {
            get { return allItems; }
        }
    }
}
