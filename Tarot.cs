using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    delegate void _Ability(ref Player player, ref Entity[] entity, int numberOfEnemy);
    [Serializable]
    class Tarot
    {
        public int HP { get; }
        public int Defense { get; }
        public int Damage { get; }
        public int Strength { get; }
        public int Agility { get; }
        public int Intelligence { get; }
        public _Ability Ability { get; }

        public Tarot (int hP, int defense, int damage, int strength, int agility, int intelligence, _Ability ability)
        {
            HP = hP;
            Defense = defense;
            Damage = damage;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Ability = ability;
        }
        
        static Tarot theFool = new Tarot(0, 5, -20, 0, -3, 0, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            entities[numberOfEnemy].CurrentHP -= 300;
            entities[numberOfEnemy].Stuned = 1;
        });
        static Tarot magician = new Tarot(0, 0, 0, 0, 0, 7, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            for (int i = 0; i < entities.Length; i++)
                entities[i].CurrentHP -= 200;
        });
        static Tarot empress = new Tarot(800, 0, 0, 0, 0, 0, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            entities[numberOfEnemy].CurrentHP -= (300 + (entities[numberOfEnemy].HP / 100));
        });
        public static List<Tarot> Tarots = new List<Tarot> { theFool, magician, empress };
    }
}
