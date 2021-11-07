using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class GameInterface
    {
       
        public static void GetGameInterface(Player player) 
        {
            Console.SetCursorPosition(63, 4);
            Console.WriteLine("HP:{0}", player.HP);
            Console.SetCursorPosition(63, 5);
            Console.WriteLine("STRENGTH:{0}", player.Strength);
            Console.SetCursorPosition(63, 6);
            Console.WriteLine("INTELECT:{0}", player.Intelligence);
            Console.SetCursorPosition(63, 7);
            Console.WriteLine("DEFENSE:{0}", player.Defense);
            Console.SetCursorPosition(63, 8);
            Console.WriteLine("AGILITY:{0}", player.Agility); // прекрасно
            Console.SetCursorPosition(63, 9);                 // великолепно
            Console.WriteLine("YOUR QUESTS");
        }

    }
}
