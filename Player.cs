using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Player : Entity
    {
        private Weapon equipedWeapon;
        private Armor equipedHelmet;
        private Inventory inventory;
        private List<Item> items;

        public Weapon EquipedWeapon { get { return equipedWeapon; } set { equipedWeapon = value; } }
        public Armor EquipedHelmet { get { return equipedHelmet; } set { equipedHelmet = value; } }

        public Player(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y) : base(Name, Hp, Strength, Agility, Intelligence, Defense, MapId, X, Y) { }

        public List<string> GetInventory()
        {
            List<string> result = new List<string>();
            result.Add("Hand: " + (equipedWeapon != null ? equipedWeapon.Name : "None"));
            result.Add("Head: " + (equipedHelmet != null ? equipedHelmet.Name : "None"));
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
                    if (item.GetSlot == Slot)
                        result.Add(item.Name);
                }
            }
            return result;
        }

        public void ChangeItemByChoice(int slot, int choice)
        {
            List<Item> slotItems = new List<Item>();
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item.GetSlot == slot)
                        slotItems.Add(item);
                }
            }
            switch (slot)
            {
                case 0:
                    EquipedWeapon = (Weapon)slotItems[choice];
                    break;
                case 1:
                    EquipedHelmet = (Armor)slotItems[choice];
                    break;
            }
        }
    }
}
