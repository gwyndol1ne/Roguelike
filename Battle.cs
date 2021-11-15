using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Battle
    {
        private Entity[] friend;
        private Entity[] enemy;
        string[] battleChoice = { "АТАКОВАТЬ", "ИСПОЛЬЗОВАТЬ СПОСОБНОСТЬ", "ОТКРЫТЬ ИНВЕНТАРЬ" };
        string[] enemyChoice;
        Menu battleMenu, enemyChoiceMenu;
        
        public Battle(Entity f, Entity[] e)
        {
            friend = new Entity[1];
            friend[0] = f;
            enemy = e;
            battleMenu = new Menu(battleChoice);
            Begin();
        }
        private string[] GetEnemyNames()
        {
            List<string> lResult = new List<string>();
            foreach (Entity entity in enemy) if (entity.Alive) lResult.Add(entity.Name);
            string[] result = new string[lResult.Count];
            for (int i = 0; i < result.Length; i++) result[i] = lResult[i];
            return result;
        }
        private void Begin()
        {
            enemyChoice = GetEnemyNames();
            enemyChoiceMenu = new Menu(enemyChoice);
            GameInterface.DrawBattleInterface(enemy, friend[0]);
            int choice = battleMenu.GetChoice(false,false);
            switch (choice)
            {
                case 0:
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    int target = enemyChoiceMenu.GetChoice(false, false);
                    break;
            }

            Console.ReadKey();
        }


    }
}
