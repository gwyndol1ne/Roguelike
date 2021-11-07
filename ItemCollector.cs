using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class ItemCollector
    {
        string[] lines;
        private int readFrom;
        List<Item> allItems;
        ItemCollector()
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
                if(identificators[2] == "w")
                {
                    allItems.Add(WeaponResolver(identificators,id,identificators[1]));
                }
                else if(identificators[2] == "a")
                {

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
        protected void ArmorResolver(string[] identificators, int id, string name)
        {
            
        }
    }
}
