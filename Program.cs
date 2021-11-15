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
            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Maps.Initialise();
            Player player = new Player("Maksim", 2000, 100, 10, 10, 10, 0, 0, 6, 6, theFool);
            List<Entity> entities = new List<Entity>();
            List<Chest> chests = new List<Chest>();
            Game.GameStatus = (int)Game.Status.StartMenu;
            Game.Start(player, entities, chests);
        }
    }
}
