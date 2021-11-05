using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{

    class Game
    {
        private enum Status
        {
            ClassMenu = 0,
            Closed = 1,
            InGame = 2,
            PauseMenu = 3,
            StartMenu = 4,

        }
        public static void Start()
        {
            int gameStatus = (int)Status.StartMenu;
            do
            {
                if (gameStatus == (int)Status.StartMenu)
                {
                    string[] startMenuItems = { "Новая игра", "Выход" };
                    Menu startMenu = new Menu(startMenuItems);
                    gameStatus = startMenu.GetChoice();
                }

                if (gameStatus == (int)Status.ClassMenu)
                {
                    Console.Clear();
                    /*string[] tarotMenuItems = { "The Fool", "Magician's Red ", "High Priestess", "Empress ", "Emperor", "Hierophant Green", 
                                       "Lovers", "Silver Chariot", "Strength", "Hermit Purple", "Wheel of Fortune", "Justice", 
                                       "Hanged Man", "Death Thirteen", "Yellow Temperance", "Ebony Devil", "Tower of Gray", "Star Platinum", 
                                       "Dark Blue Moon ", "Sun", "Judgement ", "The World" };*/
                    gameStatus = (int)Status.InGame;
                }

                if (gameStatus == (int)Status.InGame)
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
                            Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                            player.Y = player.Y-1*collector.CanMove(player.X,player.Y-1,player.MapId);
                        }

                        if (pressedKey.Key == ConsoleKey.A)
                        {
                            Console.SetCursorPosition(player.X, player.Y);
                            Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                            player.X = player.X - 1 * collector.CanMove(player.X-1, player.Y, player.MapId);
                        }

                        if (pressedKey.Key == ConsoleKey.S)
                        {
                            Console.SetCursorPosition(player.X, player.Y);
                            Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                            player.Y = player.Y + 1 * collector.CanMove(player.X, player.Y+1, player.MapId);
                        }

                        if (pressedKey.Key == ConsoleKey.D)
                        {
                            Console.SetCursorPosition(player.X, player.Y);
                            Console.WriteLine(collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                            player.X = player.X + 1 * collector.CanMove(player.X+1, player.Y, player.MapId);
                        }
                        if (collector.Transition(player))
                        {
                            Console.Clear();
                            screen.draw(collector.GetDrawnMapById(player.MapId));
                        }
                        if (pressedKey.Key == ConsoleKey.Escape)
                        {
                            gameStatus = (int)Status.PauseMenu;
                        }
                    } while (gameStatus == (int)Status.InGame);

                    if (gameStatus == (int)Status.PauseMenu)
                    {
                        string[] pauseMenuItems = { "Продолжить игру ", "Выход в главное меню" };
                        Menu pauseMenu = new Menu(pauseMenuItems);
                        int choice = pauseMenu.GetChoice();
                        if (choice == 0)
                        {
                            gameStatus = (int)Status.InGame;
                        }
                        if (choice == 1)
                        {
                            gameStatus = (int)Status.StartMenu;
                        }
                    }

                    if (gameStatus == (int)Status.Closed)
                    {
                        Environment.Exit(0);
                    }
                }
            } while (true);
        }
    }
}

