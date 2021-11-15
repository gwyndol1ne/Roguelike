using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Qest
    {
        public string qestValue { get; set; }
        public bool trigger { get; set; } = false;
        public Qest(string QestValue) { qestValue = QestValue; }

    }
}
