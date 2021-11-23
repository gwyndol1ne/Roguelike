using System;
using System.Collections.Generic;

using System.Media;
namespace Roguelike
{
    class Program
    {
        static List<Entity> entities = new List<Entity>();
        static List<Chest> chests = new List<Chest>();
        static List<Quest> quests = new List<Quest>();
        static Player player = new Player("Maksim", 2000, 100, 10, 10, 10, 0, 0, 6, 6, quests, 0);
        static public void Restart()
        {
            Maps.Initialise();
            Game.GameStatus = Game.Status.StartMenu;
            Game.Start(player, entities, chests);
        }
        static void Main(string[] args)
        {
            Maps.Initialise();
            quests.Add(new Quest("Узнайте имя Максима и пошлите его нахуй"));
            quests.Add(new Quest("Он зол бегите в яму"));
            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Chest chest1 = new Chest(0, 1, 10);
            chest1.GenerateContents(ItemCollector.GetAllItems());
            NPC npc1 = new NPC("Максим", 2000, 1, 22, 11, 33, 2, 0, 4, 11, 'N', 0);
            Enemy enemy1 = new Enemy("Волибир", 10000, 50, 1, 1, 1, 1000, 2, 4, 5, 0);
            Enemy enemy0 = new Enemy("Калиста", 10000, 100, 1, 1, 1, 100, 2, 2, 5, 0);
            entities.Add(npc1);
            entities.Add(enemy0);
            entities.Add(enemy1);
            chests.Add(chest1);
            Restart();
        }
    }
}
