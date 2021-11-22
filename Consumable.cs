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
    class Consumable : PutOnItem
    {
        private ConsumableType consumableType;
        private string[] fields;
        private int[] values;
        private int[] durations;
        public Consumable(int Id, string Name, ConsumableType ctype, string[] Fields, int[] Values, int[] Durations) : base(Id, Name, Slot.Consumables, 0 , 0 , 0)
        {
            consumableType = ctype;
            fields = Fields;
            values = Values;
            durations = Durations;
        }
        public void UseConsumable(Entity target)
        {
            switch (consumableType)
            {
                case ConsumableType.Restore:
                    Effect.AddEffect(new EntireEffect(null, new EffectBuff[] { new EffectBuff(1, values[0], "hp") }),target);
                    break;
                case ConsumableType.Buff:
                    EffectBuff[] buffs = new EffectBuff[durations.Length];
                    for (int i = 0; i < buffs.Length; i++) buffs[i] = new EffectBuff(durations[i], values[i], fields[i]);
                    Effect.AddEffect(new EntireEffect(null, buffs),target);
                    break;
            }
        }
    }
}
