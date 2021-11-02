using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Enemy : NPC
    {
        public Enemy(string Name, int Hp, int Damage, int MapId, int X, int Y) : base(Name, Hp, Damage, MapId, X, Y) { }
    }
}
