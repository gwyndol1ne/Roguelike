using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Weapon : Item
    {
        private int damage;
        private bool oneHanded;
        private char scaleStat;

        public Weapon(int Id, string Name, int Damage, bool OneHanded, char ScaleStat) : base(Id, Name)
        {
            damage = Damage;
            oneHanded = OneHanded;
            scaleStat = ScaleStat; // agility - 'a', strength - 's', intelligence - 'i'
        }
    }
}
