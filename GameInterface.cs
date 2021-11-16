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
            Console.WriteLine("ЗДОРОВЬЕ:{0}/{1}", player.CurrentHP, player.HP);
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine("УРОН:{0}", player.Damage + player.CountDamage());
            //она не лишняя она не как все  -сам убери
            Console.SetCursorPosition(x, y+3);
            Console.WriteLine("СИЛА:{0}", player.Strength + player.CountStrength());
            Console.SetCursorPosition(x, y+4);
            Console.WriteLine("ИНТЕЛЕКТ:{0}", player.Intelligence + player.CountIntelligence());
            Console.SetCursorPosition(x, y+5);
            Console.WriteLine("ЗАЩИТА:{0}", player.Defense + player.CountDefense());
            Console.SetCursorPosition(x, y+6);
            Console.WriteLine("ЛОВКОСТЬ:{0}", player.Agility + player.CountAgility());
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("КВЕСТ:{0}", player.Quests[player.QuestNumber].questValue);

        }
        public static void DrawBattleInterface(Entity[] enemy, Entity friend)
        {
            Console.Clear();
            for (int i = enemy.Length-1; i >-1; i--)
            {
                Console.SetCursorPosition(53, 30 - i * 5);
                Console.WriteLine(enemy[i].Name);
                Console.SetCursorPosition(53, 31-i*5);
                Console.WriteLine("УРОН:{0}", enemy[i].Damage);
                Console.SetCursorPosition(53, 32 - i * 5);
                Console.WriteLine("ЗДОРОВЬЕ:{0}/{1}", enemy[i].CurrentHP, enemy[i].HP);
                Console.SetCursorPosition(53, 33 - i * 5);
                Console.WriteLine("ЗАЩИТА:{0}", enemy[i].Defense);
            }
            Console.SetCursorPosition(1,30);
            Console.WriteLine("УРОН:{0}", friend.Damage+((Player)friend).CountDamage());
            Console.SetCursorPosition(1,31);
            Console.WriteLine("ЗДОРОВЬЕ:{0}/{1}", friend.CurrentHP, friend.HP);
            Console.SetCursorPosition(1,32);
            Console.WriteLine("ЗАЩИТА:{0}", friend.Defense+((Player)friend).CountDefense());
        }
    }
}
