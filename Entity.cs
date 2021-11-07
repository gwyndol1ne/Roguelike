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

        public Entity(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y)
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
        }
        public int HP
        {
            get { return hp; }
            set { hp = value; }
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
            set => defense = value;
        }
        public int MapId
        {
            get { return mapId; }
            set { mapId = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        
        
    }
}
