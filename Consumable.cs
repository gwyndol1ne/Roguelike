using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public enum ConsumableType
    {
        Restore = 0,
        Buff = 1,
        PermaBuff = 2,
    }
    class Consumable : Item
    {
        public ConsumableType consumableType;
        public string fields;
        public int[] values;
        public Consumable(int Id, string Name, ConsumableType ctype, string Fields, int[] Values) : base(Id, Name)
        {
            consumableType = ctype;
            fields = Fields;
            values = Values;
        }
        public void useConsumable(Entity target)
        {
            switch (consumableType)
            {
                case ConsumableType.Restore:
                    
                    break;
            }
        }
    }
}
