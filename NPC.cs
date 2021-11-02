using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class NPC : Entity
    {
        private int x;
        private int y;

        public NPC(string Name, int Hp, int Damage, int X, int Y) : base(Name, Hp, Damage)
        {
            x = X;
            y = Y;
        }
    }
}
