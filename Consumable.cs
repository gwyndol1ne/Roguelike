﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Consumable : Item
    {
        public Consumable(int Id, string Name, Item.Slot Slot) : base(Id, Name, Slot){ }
    }
}
