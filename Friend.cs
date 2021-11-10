using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Friend : NPC
    {
        public Friend(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y, MapCollector collector) : base(Name, Hp, Strength,  Agility,  Intelligence,  Defense, MapId, X, Y,collector) { }
    }
}
