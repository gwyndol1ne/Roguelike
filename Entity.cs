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
        private int x;
        private int y;
        private int mapId;

        public Entity(string Name, int Hp, int Damage, int MapId, int X, int Y)
        {
            name = Name;
            hp = Hp;
            damage = Damage;
            mapId = MapId;
            currentHp = Hp;
            x = X;
            y = Y;
        }
        public int MapId
        {
            get { return mapId; }
            set { if (value >= 0 && value < 9) mapId = value; else mapId = -1; }
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
