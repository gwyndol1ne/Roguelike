using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Quest
    {
        public string qestValue { get; set; }
        public bool trigger { get; set; } = false;
        public Quest(string QuestValue) { qestValue = QuestValue; }

    }
}
