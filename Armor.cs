using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Armor : Item
    {
        private int defense;
        private char equipmentSlot; //head - 'h' body - 'b' legs - 'l' foot - 'f' ring - 'r' amulet - 'a'
        private int strength;
        private int agility;
        private int intelligence;

        public Armor (int Id, string Name, int Defense, char EquipmentSlot, int Strength, int Agility, int Intelligence) : base (Id, Name)
        {
            defense = Defense;
            equipmentSlot = EquipmentSlot;
            strength = Strength;
            agility = Agility;
            intelligence = Intelligence;
        }
    }
}
