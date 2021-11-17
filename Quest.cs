using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    [Serializable]
    public class Quest
    {
        public string questValue { get; set; }
        public bool trigger { get; set; }

        public Quest(string QuestValue) 
        { 
            questValue = QuestValue;
            trigger = false;
        }
    }
}
