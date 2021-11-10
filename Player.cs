using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Player : Entity
    {
        public Item[] EquippedItems { get; set; }
        private List<Item> items = new List<Item>();

        /*public Weapon EquippedLeftHand { get { return (Weapon)equippedItems[(int)PutOnItem.Slot.LeftHand]; } set { equippedItems[(int)PutOnItem.Slot.LeftHand] = value; } }
        public Weapon EquippedRightHand { get { return (Weapon)equippedItems[(int)PutOnItem.Slot.RightHand]; } set { equippedItems[(int)PutOnItem.Slot.RightHand] = value; } }
        public Armor EquippedHelmet { get { return (Armor)equippedItems[(int)PutOnItem.Slot.Head]; } set { equippedItems[(int)PutOnItem.Slot.Head] = value; } }
        public Armor EquippedPlate { get { return (Armor)equippedItems[(int)PutOnItem.Slot.Body]; } set { equippedItems[(int)PutOnItem.Slot.Body] = value; } }
        public Armor EquippedLegs { get { return (Armor)equippedItems[(int)PutOnItem.Slot.Legs]; } set { equippedItems[(int)PutOnItem.Slot.Legs] = value; } }
        public Armor EquippedBoots { get { return (Armor)equippedItems[(int)PutOnItem.Slot.Foot]; } set { equippedItems[(int)PutOnItem.Slot.Foot] = value; } }
        public Armor EquippedRing { get { return (Armor)equippedItems[(int)PutOnItem.Slot.Ring]; } set { equippedItems[(int)PutOnItem.Slot.Ring] = value; } }
        public Armor EquippedAmulet { get { return (Armor)equippedItems[(int)PutOnItem.Slot.Amulet]; } set { equippedItems[(int)PutOnItem.Slot.Amulet] = value; } }*/

        public Player(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y) :
                 base(Name, Hp, Strength, Agility, Intelligence, Defense, MapId, X, Y) 
        {
            EquippedItems = new Item[8];
        }

        public List<string> GetInventory() //ждет изменений максима
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 8; i++)
                result.Add((PutOnItem.Slot)i + (EquippedItems[i] != null ? EquippedItems[i].Name : "None"));
            /*result.Add("Left Hand: " + (EquippedLeftHand != null ? EquippedLeftHand.Name : "None"));
            result.Add("Right Hand: " + (EquippedRightHand != null ? EquippedRightHand.Name : "None"));
            result.Add("Head: " + (EquippedHelmet != null ? EquippedHelmet.Name : "None"));
            result.Add("Body: " + (EquippedPlate != null ? EquippedPlate.Name : "None"));
            result.Add("Legs: " + (EquippedLegs != null ? EquippedLegs.Name : "None"));
            result.Add("Foot: " + (EquippedBoots != null ? EquippedBoots.Name : "None"));
            result.Add("Ring: " + (EquippedRing != null ? EquippedRing.Name : "None"));
            result.Add("Amulet: " + (EquippedAmulet != null ? EquippedAmulet.Name : "None"));*/
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
                    /*if ((item is PutOnItem) && item.equippmentSlot == Slot)
                        result.Add(item.Name);*/
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

        public void ChangeItemByChoice(int slot/*slot*/, int choice/*inventory*/)
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

            /*switch (choice)
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
            }*/
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}
