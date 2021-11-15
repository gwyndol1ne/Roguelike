﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Roguelike
{
    [Serializable]
    public class Player : Entity
    {
        public PutOnItem[] EquippedItems { get; set; }
        private List<Item> items = new List<Item>();
        public  int QestNummbet { get; set; } = 0;
        
        public Player(string Name, int Hp, int Damage, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y,Qests urQest) :
                 base(Name, Hp, Damage, Strength, Agility, Intelligence, Defense, MapId, X, Y, '@') 
        {
          
            Qests=urQest;
            Draw.currentMapId = MapId;
            EquippedItems = new PutOnItem[8];

        }
        public Qests Qests { get; set; }
        public Qest GetQest() 
        {
            return Qests.Yests[QestNummbet];
        }
        public List<string> GetInventory() //ждет изменений максима -ничего менять не буду
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                result.Add((PutOnItem.Slot)i + ": " + (EquippedItems[i] != null ? EquippedItems[i].Name : "None"));
            }
            result.Add("Вернуться к игре");
            return result;
        }

        public List<string> GetNamesBySlot(int Slot)
        {
            List<string> result = new List<string>();
            result.Add("None");
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item is Weapon || item is Armor)
                    {
                        PutOnItem putOnItem = item as PutOnItem;
                        if ((int)putOnItem.EquippmentSlot == Slot)
                        {
                            result.Add(putOnItem.Name);
                        }
                    }
                }
            }
            return result;
        }

        public void ChangeItemByChoice(int slot/*slot*/, int choice/*inventory*/) //.....
        {
            List<Item> slotItems = new List<Item>();
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item is Weapon || item is Armor)
                    {
                        PutOnItem putOnItem = item as PutOnItem;
                        if ((int)putOnItem.EquippmentSlot == choice)
                        {
                            slotItems.Add(putOnItem);
                        }
                    }
                }
            }
            if (choice < 3) EquippedItems[choice] = (Weapon)slotItems[slot - 1];
            else EquippedItems[choice] = (Armor)slotItems[slot - 1];
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void AddItems(Item[] items) 
        {
            for(int i = 0; i < items.Length; i++)
            {
                AddItem(items[i]);
            }
        }
        public int CountDamage()
        {
            int damage = 0;
            for(int i = 0; i < 2; i++)
            {
                if (EquippedItems[i] != null)
                {
                    Weapon weapon = EquippedItems[i] as Weapon;
                    damage += weapon.Damage;
                }
            }
            return damage;
        }
        public int CountDefense()
        {
            int defense = 0;
            for (int i = 2; i < 8; i++)
            {
                if (EquippedItems[i] != null)
                {
                    Armor armor = EquippedItems[i] as Armor;
                    defense += armor.Defense;
                }
            }
            return defense;
        }
        public int CountAgility()
        {
            int agility = 0;
            for (int i = 0; i < 8; i++)
            {
                if (EquippedItems[i] != null)
                {
                    agility += EquippedItems[i].Agility;
                }
            }
            return agility;
        }

        public int CountStrength()
        {
            int strength = 0;
            for (int i = 0; i < 8; i++)
            {
                if (EquippedItems[i] != null)
                {
                    strength += EquippedItems[i].Strenght;
                }
            }
            return strength;
        }
        public int CountIntelligence()
        {
            int intelligence = 0;
            for (int i = 0; i < 8; i++)
            {
                if (EquippedItems[i] != null)
                {
                    intelligence += EquippedItems[i].Intelligence;
                }
            }
            return intelligence;
        }
    }
}
