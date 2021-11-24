using System;
using System.Collections.Generic;

using System.Media;
namespace Roguelike
{
    class Program
    {
        public static Game currentGame = new Game(GenerateStartPlayer(), GenerateStartEntities(), GenerateStartChests());
        static void Main(string[] args)
        {
            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Maps.Initialise();
            currentGame.GameStatus = Game.Status.StartMenu;
            currentGame.Start();
        }
        public static Player GenerateStartPlayer(int tarotNumber = 0, bool needUpdate = false)
        {
            List<Quest> quests = new List<Quest>();
            quests.Add(new Quest("Узнайте имя Максима и пошлите его нахуй"));
            quests.Add(new Quest("Он зол бегите в яму"));
            Player player = new Player("Maksim", 2000, 100, 10, 10, 10, 0, 0, 6, 6, quests, tarotNumber);
            if(needUpdate)
            {
                player.ChangeStatsByTarot(tarotNumber);
            }
            return player;
        }

        public static List<Chest> GenerateStartChests()
        {
            Chest chest1 = new Chest(0, 1, 10);
            chest1.GenerateContents(ItemCollector.GetAllItems());
            List<Chest> chests = new List<Chest>();
            chests.Add(chest1);
            return chests;
        }

        public static List<Entity> GenerateStartEntities()
        {
            NPC npc1 = new NPC("Максим", 2000, 1, 22, 11, 33, 2, 0, 4, 11, 'N', 0);
            Enemy enemy1 = new Enemy("Волибир", 10000, 50, 1, 1, 1, 1000, 2, 4, 5, 0);
            Enemy enemy0 = new Enemy("Калиста", 10000, 100, 1, 1, 1, 100, 2, 2, 5, 0);
            List<Entity> entities = new List<Entity>();
            entities.Add(npc1);
            entities.Add(enemy0);
            entities.Add(enemy1);
            return entities;
        }
    }
}
