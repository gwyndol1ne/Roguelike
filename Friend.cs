using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Friend : NPC
    {
        public Friend(string Name, int Hp, int Damage, int X, int Y) : base(Name, Hp, Damage, X, Y) { }
    }
}
