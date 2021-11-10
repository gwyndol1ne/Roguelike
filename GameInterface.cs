using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class GameInterface
    {
        public static void GetGameInterface(Player player, MapCollector collector) 
        {
            Console.SetCursorPosition(53, 3);
            Console.WriteLine("ЛОКАЦИЯ:{0}", collector.GetMapById(player.MapId).name);
            Console.SetCursorPosition(53, 4);
            Console.WriteLine("ЗДОРОВЬЕ:{0}", player.HP);
            Console.SetCursorPosition(53, 5);
            Console.WriteLine("СИЛА:{0}", player.Strength);
            Console.SetCursorPosition(53, 6);
            Console.WriteLine("ИНТЕЛЕКТ:{0}", player.Intelligence);
            Console.SetCursorPosition(53, 7);
            Console.WriteLine("ЗАЩИТА:{0}", player.Defense);
            Console.SetCursorPosition(53, 8);
            Console.WriteLine("ЛОВКОСТЬ:{0}", player.Agility);
            Console.SetCursorPosition(53, 9);
            Console.WriteLine("ВАШИ КВЕСТЫ");

        }

    }
}
