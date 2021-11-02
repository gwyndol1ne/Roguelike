using System;
using Roguelike;
using System.Collections.Generic;
namespace Roguelike
{
    public interface Abbility
    {
        public void UseAbbility() { }

    }
    public class Player
    {
        protected int mapID = 0;
        protected int Hp;
        public int x, y;
        protected int Damage;
        protected int Deffence;
        public int GetMapID()
        {
            return mapID;
        }
    }
    public class MagihensRed : Player, Abbility
    {
        public MagihensRed()
        {
            Hp = 12;
            Damage = 23;
            Deffence = 123;
        }
        public void UseAbbility()
        {
            Damage *= 2;
        }
    }
}