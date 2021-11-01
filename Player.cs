using System;

namespace Roguelike
{
     public interface Abbility
    {
        void UseAbillity();
       
    }
   public class MagihensRed:Abbility
    {
        void Abbility.UseAbillity() { }
    }
    public class PLayer
    {
        protected int Hp;
        protected int Damage;
        protected int Deffence;
        protected Abbility Passive;
        protected Abbility Aktiv;

        public PLayer(int Hp,int Damage,int Deffence,Abbility Passive,Abbility Aktiv)
        {
            this.Hp = Hp;
            this.Damage = Damage;
            this.Deffence = Deffence;
            this.Aktiv = Aktiv;
            this.Passive = Passive;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
