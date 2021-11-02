using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Entity
    {
        private string name;
        private int hp;
        private int damage;
        private int currentHp;

        public Entity(string Name, int Hp, int Damage)
        {
            name = Name;
            hp = Hp;
            damage = Damage;
            currentHp = Hp;
        }
    }
}
