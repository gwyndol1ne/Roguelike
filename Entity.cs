﻿using System;

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
            Alive = true;
            Maps.SetEntity(mapId, x, y, this);
            Stunned = 0;
        }
        public bool Alive { get; set; }
        public char Symbol { get; }
        public string Name { get ; }
        public int HP { get; set; }
        public int Damage { get; }
        public int Strength { get; }
        public int Agility { get; }
        public int Defense { get; }
        public int Intelligence { get; }
        public int CurrentHP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MapId { get; set; }
        public int Stunned { get; set; }

        public bool Move(int dirX, int dirY)
        {
            int startingMapId = MapId;
            if (!MovementManager.TryMove(this, dirX, dirY))
            {
                int gameStatus = MovementManager.CantMoveDecider(MapId, X + dirX, Y + dirY);
                if (this is Player)
                {
                    Game.GameStatus = (Game.Status)gameStatus;
                }
                else if (this is Enemy)
                {
                    if (gameStatus == (int)Game.Status.InBattleForEntity) Game.GameStatus = Game.Status.InBattle;
                }
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
            double percentBlocked = (Defense * 0.01) / (1 + Defense * 0.01);
            int damageRecieved = (int)Math.Round(Convert.ToDouble(damage) * (1 - percentBlocked)); //да да давай говори я же понимаю все
            if (damageRecieved >= CurrentHP)
            {
                CurrentHP = 0;
                Alive = false;
            }
            else CurrentHP -= damageRecieved;
            return damageRecieved;
        }
    }
}
