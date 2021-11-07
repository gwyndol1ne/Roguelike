using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Player : Entity
    {
        public Player(string Name, int Hp, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y) : base(Name, Hp, Strength, Agility,  Intelligence,  Defense, MapId, X, Y) { }
    }
}
