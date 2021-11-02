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
        private int mapId;

        public Entity(string Name, int Hp, int Damage, int MapId)
        {
            name = Name;
            hp = Hp;
            damage = Damage;
            mapId = MapId;
            currentHp = Hp;
        }
        public int getMapId()
        {
            return mapId;
        }
    }
}
