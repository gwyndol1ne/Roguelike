using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    [Serializable]
    public class Weapon : PutOnItem
    {
        public int Damage { get; }

        public Weapon(int id, string name, PutOnItem.Slot equippmentSlot, int strenght, int agility, int intelligence, int damage) : 
                 base(id, name, equippmentSlot, strenght, agility, intelligence)
        {
            Damage = damage;
        }
    }
}
