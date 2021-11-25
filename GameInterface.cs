using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class GameInterface
    {
       
        public static void DrawMapInterface(Player player, int x, int y) 
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("ЛОКАЦИЯ:{0}", Maps.GetMapName(player.MapId));
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("ЗДОРОВЬЕ:{0}/{1}", player.Stats["hp"][1], player.Stats["hp"][0]);
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine("УРОН:{0}", player.Stats["damage"][1]);
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine("ЗАЩИТА:{0}", player.Stats["defense"][1]);
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine("СИЛА:{0}", player.Stats["strength"][1]);
            Console.SetCursorPosition(x, y+5);
            Console.WriteLine("ЛОВКОСТЬ:{0}", player.Stats["agility"][1]);
            Console.SetCursorPosition(x, y+6);
            Console.WriteLine("ИНТЕЛЕКТ:{0}", player.Stats["intelligence"][1]);
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("КВЕСТ:{0}", player.Quests[player.QuestNumber].questValue);

        }
        public static void DrawBattleInterface(Entity[] enemy, Entity friend)
        {
            Console.Clear();
            for (int i = enemy.Length - 1; i > -1; i--)
            {
                Console.SetCursorPosition(53, 30 - i * 5);
                Console.WriteLine(enemy[i].Name);
                Console.SetCursorPosition(53, 31 - i * 5);
                Console.WriteLine("УРОН:{0}", enemy[i].Stats["damage"][1]);
                Console.SetCursorPosition(53, 32 - i * 5);
                Console.WriteLine("ЗДОРОВЬЕ:{0}/{1}", enemy[i].Stats["hp"][1], enemy[i].Stats["hp"][0]);
                Console.SetCursorPosition(53, 33 - i * 5);
                Console.WriteLine("ЗАЩИТА:{0}", enemy[i].Stats["defense"][1]);
            }
            Console.SetCursorPosition(1,30);
            Console.WriteLine("УРОН:{0}", friend.Stats["damage"][1]);
            Console.SetCursorPosition(1,31);
            Console.WriteLine("ЗДОРОВЬЕ:{0}/{1}", friend.Stats["hp"][1], friend.Stats["hp"][0]);
            Console.SetCursorPosition(1,32);
            Console.WriteLine("ЗАЩИТА:{0}", friend.Stats["defense"][1]);
        }
    }
}
