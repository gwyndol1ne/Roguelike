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
            Player player = new Player("Maksim", 666, 666, 666, 666, 666, 666, 666, 10, 11);
            Game.GameStatus = (int)Game.Status.StartMenu;
            Game.Start(player, new List<Entity>(), new List<Chest>());
        }
    }
}
