﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    [Serializable]
    class Enemy : NPC
    {
        public Enemy(string Name, int Hp, int Damage, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y,int trigerNummber) : 
                base(Name, Hp, Damage, Strength, Agility, Intelligence, Defense, MapId, X, Y, '$', trigerNummber) { }

    }
}
