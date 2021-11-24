﻿using System;
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
            int target;
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
                        target = enemyChoiceMenu.GetChoice(false, false);
                        Effect.AddEffect(new EntireEffect(null,new EffectBuff[] { new EffectBuff(2, 10, "defense") }), friend[0]);
                        aliveEnemies[target].GetDamaged(friend[0].Stats["damage"][1]);
                        break;
                    case 1:
                        GameInterface.DrawBattleInterface(aliveEnemies, friend[0]);
                        target = enemyChoiceMenu.GetChoice(false, false);
                        Player player = friend[0] as Player;
                        Tarot.Tarots[player.TarotNumber].Ability(ref player, ref aliveEnemies, target);
                        break;
                    case 2:
                        List<string> items = ((Player)friend[0]).GetNamesBySlot((int)PutOnItem.Slot.Consumables);
                        Menu consumableMenu = new Menu(items);
                        choice = consumableMenu.GetChoice(false, false);
                        break;
                }
                for (int i = 0; i < aliveEnemies.Length; i++) aliveEnemies[i].UpdateEffects();
                for (int i = 0; i < friend.Length; i++) friend[i].UpdateEffects();
                UpdateAliveEnemies();
                for (int i = 0; i < aliveEnemies.Length; i++) friend[0].GetDamaged(aliveEnemies[i].Stats["damage"][1]);
            }
            if (friend[0].Alive)
            {
                Program.currentGame.GameStatus = Game.Status.InGame;
                for (int i = 0; i < enemy.Length; i++) Maps.DelEntity(enemy[i].MapId, enemy[i].X, enemy[i].Y);
            }
            else
            {
                Program.currentGame = new Game(Program.GenerateStartPlayer(), Program.GenerateStartEntities(), Program.GenerateStartChests());
                Program.currentGame.GameStatus = Game.Status.StartMenu;
                Program.currentGame.Start();
            }
        }
    }
}
