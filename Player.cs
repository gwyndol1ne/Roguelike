using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Player : Entity
    {
        private Item[] equippedItems = new Item[8]; 
        private List<Item> items = new List<Item>();
        //что это нахуй такое зачем оно вообще существует
        public Weapon EquippedLeftHand { get { return (Weapon)equippedItems[(int)Item.Slot.LeftHand - 1]; } set { equippedItems[(int)Item.Slot.LeftHand - 1] = value; } }
        public Weapon EquippedRightHand { get { return (Weapon)equippedItems[(int)Item.Slot.RightHand - 1]; } set { equippedItems[(int)Item.Slot.RightHand - 1] = value; } }
        public Armor EquippedHelmet { get { return (Armor)equippedItems[(int)Item.Slot.Head - 1]; } set { equippedItems[(int)Item.Slot.Head - 1] = value; } }
        public Armor EquippedPlate { get { return (Armor)equippedItems[(int)Item.Slot.Body - 1]; } set { equippedItems[(int)Item.Slot.Body - 1] = value; } }
        public Armor EquippedLegs { get { return (Armor)equippedItems[(int)Item.Slot.Legs - 1]; } set { equippedItems[(int)Item.Slot.Legs - 1] = value; } }
        public Armor EquippedBoots { get { return (Armor)equippedItems[(int)Item.Slot.Foot - 1]; } set { equippedItems[(int)Item.Slot.Foot - 1] = value; } }
        public Armor EquippedRing { get { return (Armor)equippedItems[(int)Item.Slot.Ring - 1]; } set { equippedItems[(int)Item.Slot.Ring - 1] = value; } }
        public Armor EquippedAmulet { get { return (Armor)equippedItems[(int)Item.Slot.Amulet - 1]; } set { equippedItems[(int)Item.Slot.Amulet - 1] = value; } }

        public Player(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y) :
                      base(Name, Hp, Strength, Agility, Intelligence, Defense, MapId, X, Y)
        { }

        public List<string> GetInventory() //ждет изменений максима - ничего менять не буду
        {
            List<string> result = new List<string>();
            result.Add("Left Hand: " + (EquippedLeftHand != null ? EquippedLeftHand.Name : "None"));
            result.Add("Right Hand: " + (EquippedRightHand != null ? EquippedRightHand.Name : "None"));
            result.Add("Head: " + (EquippedHelmet != null ? EquippedHelmet.Name : "None"));
            result.Add("Body: " + (EquippedPlate != null ? EquippedPlate.Name : "None"));
            result.Add("Legs: " + (EquippedLegs != null ? EquippedLegs.Name : "None"));
            result.Add("Foot: " + (EquippedBoots != null ? EquippedBoots.Name : "None"));
            result.Add("Ring: " + (EquippedRing != null ? EquippedRing.Name : "None"));
            result.Add("Amulet: " + (EquippedAmulet != null ? EquippedAmulet.Name : "None"));
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

        public void ChangeItemByChoice(int slot/*slot*/, int choice/*inventory*/) //.....
        {
            List<Item> slotItems = new List<Item>();
            if (items != null)
            {
                foreach (Item item in items)
                {
                    if (item.GetSlot == choice + 1)
                        slotItems.Add(item);
                }
            }
            switch (choice) //Mohammedu Abdul???!!?!??! Yes I am!
            {
                case 0:
                    EquippedLeftHand = (Weapon)slotItems[slot - 1];
                    break;
                case 1:
                    EquippedRightHand = (Weapon)slotItems[slot - 1];
                    break;
                case 2:
                    EquippedHelmet = (Armor)slotItems[slot - 1];
                    break;
                case 3:
                    EquippedPlate = (Armor)slotItems[slot - 1];
                    break;
                case 4:
                    EquippedLegs = (Armor)slotItems[slot - 1];
                    break;
                case 5:
                    EquippedBoots = (Armor)slotItems[slot - 1];
                    break;
                case 6:
                    EquippedRing = (Armor)slotItems[slot - 1];
                    break;
                case 7:
                    EquippedAmulet = (Armor)slotItems[slot - 1];
                    break;
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}
