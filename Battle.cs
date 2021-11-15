using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Battle
    {
        private Entity[] friend;
        private Entity[] enemy;
        private Entity[] aliveEnemies;
        string[] battleChoice = { "АТАКОВАТЬ", "ИСПОЛЬЗОВАТЬ СПОСОБНОСТЬ", "ОТКРЫТЬ ИНВЕНТАРЬ" };
        string[] enemyChoice;
        Menu battleMenu, enemyChoiceMenu;
        
        public Battle(Entity f, Entity[] e)
        {
            friend = new Entity[1];
            friend[0] = f;
            enemy = e;
            aliveEnemies = e;
            battleMenu = new Menu(battleChoice);
            Start();
        }
        private void UpdateAliveEnemies()
        {
            List<Entity> lResult = new List<Entity>();
            for(int i = 0; i < enemy.Length; i++) if (enemy[i].Alive) lResult.Add(enemy[i]);
            aliveEnemies = new Entity[lResult.Count];
            for (int i = 0; i < aliveEnemies.Length; i++) aliveEnemies[i] = lResult[i];
        }
        private string[] GetAliveEnemyNames()
        {
            string[] result = new string[aliveEnemies.Length];
            for (int i = 0; i < aliveEnemies.Length; i++) result[i] = aliveEnemies[i].Name;
            return result;
        }
        private void Start()
        {
            while ((aliveEnemies.Length != 0)&&(friend[0].Alive))
            {
                enemyChoice = GetAliveEnemyNames();
                enemyChoiceMenu = new Menu(enemyChoice);
                GameInterface.DrawBattleInterface(aliveEnemies, friend[0]);
                int choice = battleMenu.GetChoice(false, false);
                switch (choice)
                {
                    case 0:
                        GameInterface.DrawBattleInterface(aliveEnemies, friend[0]);
                        int target = enemyChoiceMenu.GetChoice(false, false);
                        aliveEnemies[target].GetDamaged(friend[0].Damage);
                        UpdateAliveEnemies();
                        for(int i = 0; i < aliveEnemies.Length; i++) friend[0].GetDamaged(aliveEnemies[i].Damage);
                        break;
                }
            }
            Game.GameStatus = (int)Game.Status.InGame;
            for (int i = 0; i < enemy.Length; i++) Maps.DelEntity(enemy[i].MapId, enemy[i].X, enemy[i].Y);
        }
    }
}
