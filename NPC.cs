using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class NPC : Entity
    {
        public NPC(string Name, int Hp, int Damage, int MapId, int X, int Y) : base(Name, Hp, Damage, MapId, X, Y)
        {

        }
    }
}
