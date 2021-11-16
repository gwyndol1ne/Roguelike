using System;
using System.Collections.Generic;

using System.Media;
namespace Roguelike
{
    class Program
    {

        static void Main(string[] args)
        {
            Tarot theFool = new Tarot(0, 5, -20, 0, -3, 0, (ref Player player, ref Entity[] entities, int numberOfEnemy) => 
            {
                entities[numberOfEnemy].GetDamaged(300);
                entities[numberOfEnemy].Stunned = 1;                 //вынести нахуй отсюда
                                                                     //класс не выбирается а просто так
            });

            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Maps.Initialise();

            List<Quest> qest = new List<Quest>();

            Quests qests = new Quests(qest);
            Quest StartQest = new Quest("Узнайте имя Максима и пошлите его нахуй");
            Quest qest1 = new Quest("Он зол бегите в яму");
            qest.Add(StartQest);
            qest.Add(qest1);
            Player player = new Player("Maksim", 2000, 100, 10, 10, 10, 0, 0, 6, 6, qests,theFool);

            List<Entity> entities = new List<Entity>();
            List<Chest> chests = new List<Chest>();
            Game.GameStatus = (int)Game.Status.StartMenu;
            Game.Start(player, entities, chests);
        }
    }
}
