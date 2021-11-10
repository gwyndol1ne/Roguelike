using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class GameInterface
    {
       
        public static void GetGameInterface(Player player) 
        {
            Console.SetCursorPosition(53, 3);
            Console.WriteLine("ЛОКАЦИЯ:{0}", Maps.GetMapName(player.MapId));
            Console.SetCursorPosition(53, 4);
            Console.WriteLine("ЗДОРОВЬЕ:{0}", player.HP);
            Console.SetCursorPosition(53, 5);
            Console.WriteLine("УРОН:{0}", player.Damage);
            //она не лишняя она не как все
            Console.SetCursorPosition(53, 6);
            Console.WriteLine("СИЛА:{0}", player.Strength);
            Console.SetCursorPosition(53, 7);
            Console.WriteLine("ИНТЕЛЕКТ:{0}", player.Intelligence);
            Console.SetCursorPosition(53, 8);
            Console.WriteLine("ЗАЩИТА:{0}", player.Defense);
            Console.SetCursorPosition(53, 9);
            Console.WriteLine("ЛОВКОСТЬ:{0}", player.Agility);
            Console.SetCursorPosition(53, 10);
            Console.WriteLine("ВАШИ КВЕСТЫ");

        }

    }
}
