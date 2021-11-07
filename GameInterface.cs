using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class GameInterface
    {
       
        public static  void GetGameInterface(Player player) 
        {
            Console.SetCursorPosition(63, 4);
            Console.WriteLine("ЗДОРОВЬЕ:{0}", player.HP);
            Console.SetCursorPosition(63, 5);
            Console.WriteLine("СИЛА:{0}", player.Strength);
            Console.SetCursorPosition(63, 6);
            Console.WriteLine("ИНТЕЛЕКТ:{0}", player.Intelligence);
            Console.SetCursorPosition(63, 7);
            Console.WriteLine("ЗАЩИТА:{0}", player.Defense);
            Console.SetCursorPosition(63, 8);
            Console.WriteLine("ЛОВКОСТЬ:{0}", player.Agility);
            Console.SetCursorPosition(63, 9);
            Console.WriteLine("ВАШИ КВЕСТЫ");
        }

    }
}
