using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Weapon : Item
    {
        private int damage;
        private char scaleStat;

        public Weapon(int Id, string Name, int Damage, Item.Slot Slot, char ScaleStat) : base(Id, Name, Slot)
        {
            damage = Damage;
            scaleStat = ScaleStat; // agility - 'a', strength - 's', intelligence - 'i'
        }
        public int Damage
        {
            get { return damage; }
        }
        
    }
}
