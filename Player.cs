using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Player : Entity
    {
        private Weapon equipedWeapon;
        private Armor equipedHelmet;
        private Inventory inventory;

        public Player(string Name, int Hp, int Damage, int MapId, int X, int Y) : base(Name, Hp, Damage, MapId, X, Y) 
        {
            inventory = new Inventory();
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.SetCursorPosition(2, 3);
            Console.Write("Hand: {0} \n Head: {1}", equipedWeapon.Name, equipedHelmet.Name);
        }
    }
}
