using System;
using System.Collections.Generic;

using System.Media;
namespace Roguelike
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Quest> quests = new List<Quest>();
            quests.Add(new Quest("Узнайте имя Максима и пошлите его нахуй"));
            quests.Add(new Quest("Он зол бегите в яму"));
            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Maps.Initialise();
            Player player = new Player("Maksim", 2000, 100, 10, 10, 10, 0, 0, 6, 6, quests, 0);
            List<Entity> entities = new List<Entity>();
            List<Chest> chests = new List<Chest>();
            Game.GameStatus = Game.Status.StartMenu;
            Game.Start(player, entities, chests);
        }
    }
}
