using System;
using Roguelike;
using System.Collections.Generic;
namespace Roguelike 
{
    public class Item
    {

    }
    public class Weapon : Item
    {
        public  int damage;

    }
    public interface Abbility
    {
        public void UseAbbility() { }

    }
    public class PLayer
    {
       
       protected List<Weapon> weapons = new List<Weapon>();
        protected int Hp;
        public int x, y;
        protected int Damage;
        protected int Deffence;
        protected int x;
        protected int y;
        public void GivWeapon(Weapon wp)
        {
            weapons.Add(wp);
        }
        public Weapon wp = weapons[0];
       

    }
    public class MagihensRed : PLayer, Abbility
    {
        public MagihensRed()
        {
            Hp = 12;
            Damage =23;
            Deffence =123;
        }  
            Damage += wp.damage
        public void UseAbbility()
        {
            Damage *= 2;
        }

        
    }
<<<<<<< HEAD

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellrld!");
        }
    }
}
=======

>>>>>>> 538efb5b77a644371a9d88e8547650abf9bac712
