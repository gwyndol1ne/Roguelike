using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public delegate void EffectAction(Entity entity);
    public class Effect
    {
        public int duration { get; }
        public EffectAction action { get; }
        public Effect(int d, EffectAction[] effectActions)
        {
            duration = d;
            action = effectActions[0];
            for (int i = 1; i < effectActions.Length; i++) action += effectActions[i];
        }
        static public void CalculateEffects(Entity entity)
        {
           
        }
    }
}
