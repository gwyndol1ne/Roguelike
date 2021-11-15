using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    delegate void Ability(ref Player player, ref Entity[] entity, int numberOfEnemy);
    [Serializable]
    class Tarot
    {
        public int HP { get; set; }
        public int Defense { get; set; }
        public int Damage { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        private Ability Ability;

        public Tarot (int hP, int defense, int damage, int strength, int agility, int intelligence, Ability ability)
        {
            HP = hP;
            Defense = defense;
            Damage = damage;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Ability = ability;
        }
    }
}
