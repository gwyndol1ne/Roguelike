using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    [Serializable]
    class Consumable : PutOnItem
    {
        private string[] fields;
        private int[] values;
        private int[] durations;
        public Consumable(int Id, string Name, string[] Fields, int[] Values, int[] Durations) : base(Id, Name, Slot.Consumables, 0 , 0 , 0)
        {
            fields = Fields;
            values = Values;
            durations = Durations;
        }
        public void UseConsumable(Entity target)
        {
            EffectBuff[] buffs = new EffectBuff[durations.Length];
            for (int i = 0; i < buffs.Length; i++) buffs[i] = new EffectBuff(durations[i], values[i], fields[i]);
            Effect.AddEffect(new EntireEffect(null, buffs), target);
        }
    }
}
