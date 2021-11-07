using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class NPC : Entity
    {
        public NPC(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y) : base(Name, Hp, Strength,  Agility, Intelligence, Defense, MapId, X, Y)
        {

        }
    }
}
