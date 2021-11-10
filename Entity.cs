using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Entity
    {
        public string Name { get ; }
        public int HP { get; }
        public int Damage { get; }
        public int Strength { get; }
        public int Agility { get; }
        public int Defense { get; }
        public int Intelligence { get; }
        public int CurrentHP { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MapId { get; set; }

        public Entity(string name, int hp, int damage, int strength, int agility, int intelligence, int defense, int mapId, int x, int y)
        {
           
            Name = name;
            HP = hp;
            Damage = damage;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Defense = defense;
            MapId = mapId;
            CurrentHP = hp;
            X = x;
            Y = y;
        }

        public void Move(int dirX, int dirY)
        {
            if (!MovementManager.TryMove(this, dirX, dirY))
            {
                Game.SetStatus = MovementManager.CantMoveDecider(MapId, X + dirX, Y + dirY);
            }
        }
    }
}
