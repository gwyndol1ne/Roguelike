using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Item
    {
        public enum Slot
        {
            None = 0,
            LeftHand = 1,
            RightHand = 2,
            Head = 3,
            Body = 4,
            Legs = 5,
            Foot = 6,
            Ring = 7,
            Amulet = 8,
        }

        private int id;
        private string name;
        private int slot;

        public string Name { get { return name; } }
        public int GetSlot { get { return slot; } }
        public Item(int Id, string Name, Slot Slot)
        {
            id = Id;
            name = Name;
            slot = (int)Slot;
        }
    }
}
