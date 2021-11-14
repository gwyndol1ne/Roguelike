using System;
using System.Collections.Generic;

using System.Media;
namespace Roguelike
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Maps.Initialise();
            Player player = new Player("Maksim", 5, 5, 5, 5, 5, 5, 0, 6, 6);
            Game.GameStatus = (int)Game.Status.StartMenu;
            Game.Start(player, new List<Entity>(), new List<Chest>());
        }
    }
}
