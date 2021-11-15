using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Roguelike
{
    [Serializable]
    public class Entity
    {
        public Entity(string name, int hp, int damage, int strength, int agility, int intelligence, int defense, int mapId, int x, int y, char symb)
        {
            Damage = damage;
            Name = name;
            HP = hp;
            CurrentHP = hp;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Defense = defense;
            MapId = mapId;
            X = x;
            Y = y;
            Symbol = symb;
            Maps.SetEntity(mapId, x, y, this);
            Stuned = 0;
        }
        public char Symbol { get; }
        public string Name { get ; }
        public int HP { get; }
        public int Damage { get; }
        public int Strength { get; }
        public int Agility { get; }
        public int Defense { get; }
        public int Intelligence { get; }
        public int CurrentHP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MapId { get; set; }
        public int Stuned { get; set; }

        public bool Move(int dirX, int dirY)
        {
            int startingMapId = MapId;
            if (!MovementManager.TryMove(this, dirX, dirY))
            {
                Game.GameStatus = MovementManager.CantMoveDecider(MapId, X + dirX, Y + dirY);
                return false;
            }
            if (startingMapId != MapId) return false;
            return true;
        }
        public void MoveTowards(int x, int y)
        {
            point direction = Pathfinder.GetPath(Y,(X+1)/2,y,(x+1)/2, Maps.GetPassableForPathfinding(MapId))[0];
            direction.y *= 2;
            Move(direction.y, direction.x);
        }
        public int GetDamaged(int damage)
        {
            int damageRecieved = damage - Defense;
            CurrentHP -= damageRecieved;
            return damageRecieved;
        }
    }
}
