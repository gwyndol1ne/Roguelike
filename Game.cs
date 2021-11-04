using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
   
    class Game
    {
        
        /*const int gameBeforeStarting = 0;
        const int gameStarted = 2;*/
        private enum Status : int
        {
            gameBeforeStarting = 0,
            gameStarted = 2,
            gameInProcess = 3,
        }
        public static void Start()
        {
            int gameStatus;
            string[] startMenuItems = { "Новая игра", "Выход" };
            Menu startMenu = new Menu(startMenuItems);
            gameStatus = startMenu.GetChoice();

            if (gameStatus == (int)Status.gameBeforeStarting)
            {
                Console.Clear();
                /*string[] tarotMenuItems = { "The Fool", "Magician's Red ", "High Priestess", "Empress ", "Emperor", "Hierophant Green", 
                                   "Lovers", "Silver Chariot", "Strength", "Hermit Purple", "Wheel of Fortune", "Justice", 
                                   "Hanged Man", "Death Thirteen", "Yellow Temperance", "Ebony Devil", "Tower of Gray", "Star Platinum", 
                                   "Dark Blue Moon ", "Sun", "Judgement ", "The World" };*/
                gameStatus = (int)Status.gameStarted;
            }

            if (gameStatus == (int)Status.gameStarted)
            {
                Console.Clear();
                MapCollector collector = new MapCollector();
                Draw screen = new Draw();
                Player player = new Player("a", 0, 0, 0, 11, 11);
                ConsoleKeyInfo pressedKey;
                screen.draw(collector.GetDrawnMapById(player.MapId));
                do
                {
                    
                    Console.SetCursorPosition(player.X, player.Y);
                    Console.Write("a");
                    pressedKey = Console.ReadKey(true);
                  
                    if (pressedKey.Key == ConsoleKey.W)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                        Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y,player.X]);
                        player.Y--;
                    }
                    if (pressedKey.Key == ConsoleKey.A)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                        Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                        player.X--;
                    }

                    if (pressedKey.Key == ConsoleKey.S)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                        Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                        player.Y++;
                    }

                    if (pressedKey.Key == ConsoleKey.D)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                        Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                        player.X++;
                    }
                } while (gameStatus != (int)Status.gameInProcess);
            }
        }
    }
}
