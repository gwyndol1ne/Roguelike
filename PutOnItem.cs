using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class PutOnItem : Item
    {
        /*public enum Slot
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
        }*/
        public enum Slot
        {
            LeftHand = 0,
            RightHand = 1,
            Head = 2,
            Body = 3,
            Legs = 4,
            Foot = 5,
            Ring = 6,
            Amulet = 7,
        }
        public PutOnItem.Slot EquippmentSlot { get; }
        public int Strenght { get; }
        public int Agility { get; }
        public int Intelligence { get; }

        public PutOnItem (int id, string name, PutOnItem.Slot equippmentSlot, int strenght, int agility, int intelligence) : base(id, name)
        {
            EquippmentSlot = equippmentSlot;
            Strenght = strenght;
            Agility = agility;
            Intelligence = intelligence;
        }
        /* private int defense;
        private char equipmentSlot; //head - 'h' body - 'b' legs - 'l' foot - 'f' ring - 'r' amulet - 'a'
        private int strength;
        private int agility;
        private int intelligence;*/
    }
}
