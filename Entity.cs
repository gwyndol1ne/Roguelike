using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Entity
    {
        private string name;
        private int hp;
        private int strength;
        private int agility;
        private int defense;
        private int intelligence;
        private int currentHp;
        private int x;
        private int y;
        private int mapId;
        private int damage;
        private char symbol;

        public Entity(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y, char symb)
        {
            name = Name;
            hp = Hp;
            strength = Strength;
            agility = Agility;
            intelligence = Intelligence;
            defense = Defense;
            mapId = MapId;
            currentHp = Hp;
            x = X;
            y = Y;
            symbol = symb;
            Maps.SetEntity(mapId, x, y, this);
        }
        public char Symbol
        {
            get { return symbol; }
        }
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }
        public string Name
        {
            get { return name; }
            
        }
        public int Strength
        {
            get { return strength; }
            set => strength = value;
        }
        public int Intelligence
        {
            get { return intelligence; }
            set => intelligence = value;
        }
        public int Agility
        {
            get { return agility; }
            set => agility = value;
        }
        public int Defense
        {
            get { return defense; }
            set => defense = value; // метод илья платонов (любитель)
        }
        public int MapId
        {
            get { return mapId; }
            set { mapId = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; } // метод максим матвеенко (профессионал)
        }
        public int X
        {
            get { return x; }
            set { x = value; } // метод даниил гончаров (сеньор помидор) я это не писал
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        
        public void Move(int dirX, int dirY)
        {
            if (!MovementManager.TryMove(this, dirX, dirY))
            {
                Game.SetStatus = MovementManager.CantMoveDecider(mapId, x + dirX, y + dirY);
            }
            else
            {
                
            }
        }
    }
}
