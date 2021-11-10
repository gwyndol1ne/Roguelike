using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Armor : PutOnItem
    {

        public int Defense { get; }

        public Armor(int id, string name, PutOnItem.Slot equippmentSlot, int strength, int agility, int intelligence, int defense) : 
                base(id, name, equippmentSlot, strength, agility, intelligence)
        {
            Defense = defense;
        }
    }
}
