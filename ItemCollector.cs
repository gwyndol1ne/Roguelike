using System;
using System.Collections.Generic;
using System.IO;

namespace Roguelike
{
    class ItemCollector
    {
        private static string[] lines;
        private static int readFrom;
        private static List<Item> allItems;
        public static List<Item> GetAllItems()
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
                PutOnItem.Slot slot = (PutOnItem.Slot)Convert.ToInt32(identificators[2]);
                int agility = Convert.ToInt32(identificators[3]);
                int strength = Convert.ToInt32(identificators[4]);
                int intelligence = Convert.ToInt32(identificators[5]);
                int laststat = Convert.ToInt32(identificators[7]);
                if (identificators[6] == "w") allItems.Add(new Weapon(id, name, slot, strength, agility, intelligence, laststat));
                if (identificators[6] == "a") allItems.Add(new Armor(id, name, slot, strength, agility, intelligence, laststat));
                
                //0:Sword:0:5:2:0:10
                //1:Chainmail:3:5:0:0:10
            }
            return allItems;
        }
        /*private Weapon WeaponResolver(string[] identificators, int id, string name, PutOnItem.Slot slot) //
        {
            int dmg = Convert.ToInt32(identificators[4]);
            char scale = Convert.ToChar(identificators[5]);
            Weapon result = new Weapon(id, name, dmg, slot, scale);
            return result;
        }
        private Armor ArmorResolver(string[] identificators, int id, string name, PutOnItem.Slot slot)
        {
            int def = Convert.ToInt32(identificators[4]);
            int s = Convert.ToInt32(identificators[5]);
            int a = Convert.ToInt32(identificators[6]);
            int i = Convert.ToInt32(identificators[7]);
            Armor result = new Armor(id, name, def, slot, s, a, i);
            return result;
        }*/
    }
}
