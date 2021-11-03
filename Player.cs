using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Player : Entity
    {
        public Player(string Name, int Hp, int Damage, int MapId, int X, int Y) : base(Name, Hp, Damage, MapId, X, Y) { }
    }
}
