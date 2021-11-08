using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Armor : Item
    {

        private int defense;
        private char equipmentSlot; //head - 'h' body - 'b' legs - 'l' foot - 'f' ring - 'r' amulet - 'a'
        private int strength;
        private int agility;
        private int intelligence;

        public Armor(int Id, string Name, int Defense, Item.Slot Slot, int Strength, int Agility, int Intelligence) : base(Id, Name, Slot)
        {
            defense = Defense;
            strength = Strength;
            agility = Agility;
            intelligence = Intelligence;
        }
    }
}
