using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public delegate void effectAction(Entity[] entity, int number);
    [Serializable]
    public class Effect
    {
        public int duration { get; set; }
        public Effect(int dur)
        {
            duration = dur;
        }
        public static void AddEffect(EntireEffect effect, Entity target)
        {
            if(effect.buffs!=null) for(int i = 0; i < effect.buffs.Length; i++) target.EffectBuffs[effect.buffs[i].name].Add(effect.buffs[i]);
            if (effect.action != null) target.EffectActions.Add(effect.action);
        }
    }
    [Serializable]
    public class EffectAction : Effect
    {
        public effectAction action { get; }
        public Entity[] target { get; }
        public EffectAction(int dur, effectAction Action, Entity tg):base(dur)
        {
            target = new Entity[1];
            action = Action;
            target[0] = tg;
        }
        public EffectAction(int dur, effectAction Action, Entity[] targets) : base(dur)
        {
            action = Action;
            target = targets;
        }
        public static void LoversEffect(Entity[] entities, int damage)
        {
            if (entities != null) entities[0].GetDamaged(damage*3);
        }
    }
    [Serializable]
    public class EffectBuff : Effect
    {
        public int value { get; }
        public string name { get; }
        public EffectBuff(int dur, int val, string key): base(dur)
        {
            value = val;
            name = key;
        }
    }
    public struct EntireEffect
    {
        public EffectAction action;
        public EffectBuff[] buffs;
        public EntireEffect(EffectAction act, EffectBuff[] buff)
        {
            action = act;
            buffs = buff;
        }
    }
    
}
