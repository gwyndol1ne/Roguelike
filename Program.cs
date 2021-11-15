using System;
using System.Collections.Generic;

using System.Media;
namespace Roguelike
{
    class Program
    {

        static void Main(string[] args)
        {
            Tarot theFool = new Tarot(0, 5, 0, 0, -3, 0, (ref Player player, ref Entity[] entities, int numberOfEnemy) => 
            {
                entities[numberOfEnemy].CurrentHP -= 300;
                entities[numberOfEnemy].Stuned = 1;
            });
            Tarot magician = new Tarot(0, 0, 0, 0, 0, 7, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
            {
                for (int i = 0; i < entities.Length; i++)
                    entities[i].CurrentHP -= 200;
            });
            Tarot empress = new Tarot(800, 0, 0, 0, 0, 0, (ref Player player, ref Entity[] entities, int numberOfEnemy) =>
            {
                entities[numberOfEnemy].CurrentHP -= (300 + (entities[numberOfEnemy].HP / 100));
            });

            List<Quest> quests = new List<Quest>();
            quests.Add(new Quest("Узнайте имя Максима и пошлите его нахуй"));
            quests.Add(new Quest("Он зол бегите в яму"));
            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Maps.Initialise();
            Player player = new Player("Maksim", 2000, 100, 10, 10, 10, 0, 0, 6, 6, quests, theFool);
            List<Entity> entities = new List<Entity>();
            List<Chest> chests = new List<Chest>();
            Game.GameStatus = (int)Game.Status.StartMenu;
            Game.Start(player, entities, chests);
        }
    }
}
