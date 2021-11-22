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
                if (identificators[6] == "w") allItems.Add(new Weapon(id, name, slot, strength, agility, intelligence, Convert.ToInt32(identificators[7])));
                else if (identificators[6] == "a") allItems.Add(new Armor(id, name, slot, strength, agility, intelligence, Convert.ToInt32(identificators[7])));
                else if (identificators[6] == "c")
                {
                    int length = (identificators.Length - 7) / 3;
                    string[] fields = new string[length];
                    int[] durations = new int[length];
                    int[] values = new int[length];
                    for(int j = 0; j < fields.Length; j ++)
                    {
                        fields[j] = identificators[j * 3 + 7];
                        durations[j] = Convert.ToInt32(identificators[j * 3 + 8]);
                        values[j] = Convert.ToInt32(identificators[j * 3 + 9]);
                    }
                    allItems.Add(new Consumable(id, name, ConsumableType.Buff, fields, values, durations));
                }
            }
            return allItems;
        }
    }
}
