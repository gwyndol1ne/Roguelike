using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    delegate void _Ability(ref Player player, ref Entity[] entity, int numberOfEnemy = 0);
    [Serializable]
    class Tarot
    {
        public int HP { get; }
        public int Defense { get; }
        public int Damage { get; }
        public int Strength { get; }
        public int Agility { get; }
        public int Intelligence { get; }
        public bool Target { get; }
        public _Ability Ability { get; }

        public Tarot (int hP, int defense, int damage, int strength, int agility, int intelligence, bool target, _Ability ability)
        {
            HP = hP;
            Defense = defense;
            Damage = damage;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Ability = ability;
            Target = target;
        }

        static Tarot theFool = new Tarot(0, 5, -20, 0, -3, 0, true, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            entities[numberOfEnemy].GetDamaged(300);
        });
        static Tarot magician = new Tarot(0, 0, 0, 0, 0, 7, false, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            for (int i = 0; i < entities.Length; i++)
                entities[i].GetDamaged(200);
        });
        static Tarot empress = new Tarot(800, 0, 0, 0, 0, 0, true, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            entities[numberOfEnemy].GetDamaged(300 + (int)Math.Round(entities[numberOfEnemy].Stats["hp"][0] * 0.1)); //давай ты нормально сделаешь
        });
        static Tarot emperor = new Tarot(0, 0, 0, 0, 5, 0, true, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            
        });
        static Tarot hierophant = new Tarot(0, 0, 0, 0, 0, 7, false, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            
        });
        static Tarot lovers = new Tarot(0, 0, 0, 0, 0, 5, true, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {
            
        });
        static Tarot silverChariot = new Tarot(0, 0, 70, 0, 5, 0, true, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {

        });
        static Tarot starPlatinum = new Tarot(400, 4, 40, 4, 4, 4, false, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {

        });
        static Tarot tower = new Tarot(-1500, 0, 900, 0, 0, 0, false, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {

        });
        static Tarot ZAWARUDO = new Tarot(200, 2, 20, 2, 2, 8, true, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
        {

        });
        public static List<Tarot> Tarots = new List<Tarot> { theFool, magician, empress, emperor, hierophant, lovers, silverChariot, starPlatinum, tower, ZAWARUDO };
    }
}
