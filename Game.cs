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
            Inventory = 5,
            SlotChoice = 6,
            ItemChoice = 7,
        }
        public static void Start()
        {
            ItemCollector icollector = new ItemCollector();
            Player player = new Player("a", 0, 0, 0, 0, 0, 0, 11, 11);
            MapCollector collector = new MapCollector();
            string[] startMenuItems = { "Новая игра", "Выход" };
            Menu startMenu = new Menu(startMenuItems);
            string[] pauseMenuItems = { "Продолжить игру ", "Выход в главное меню" };
            Menu pauseMenu = new Menu(pauseMenuItems);
            string[] tarotMenuItems = { "The Fool", "Magician's Red ", "High Priestess", "Empress ", "Emperor", "Hierophant Green",
                                       "Lovers", "Silver Chariot", "Strength", "Hermit Purple", "Wheel of Fortune", "Justice",
                                       "Hanged Man", "Death Thirteen", "Yellow Temperance", "Ebony Devil", "Tower of Gray", "Star Platinum",
                                       "Dark Blue Moon ", "Sun", "Judgement ", "The World" };
            Menu tarotMenu = new Menu(tarotMenuItems);
            int gameStatus = (int)Status.StartMenu;
            do
            {
                if (gameStatus == (int)Status.Closed)
                {
                    Environment.Exit(0);
                }
                if (gameStatus == (int)Status.StartMenu)
                {
                    player = new Player("a", 0, 0, 0, 0, 0, 0, 11, 11);
                    gameStatus = startMenu.GetChoice(true);
                }
                if (gameStatus == (int)Status.ClassMenu)
                {
                    Console.Clear();
                    tarotMenu.GetChoice(true);
                    gameStatus = (int)Status.InGame;
                }
                if (gameStatus == (int)Status.InGame)
                {
                    ConsoleKeyInfo pressedKey;
                    Draw.ReDrawMap(collector.GetMapById(player.MapId), player.X, player.Y, '@');

                    do
                    {
                        GameInterface.GetGameInterface(player);
                        pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Escape)
                        {
                            gameStatus = (int)Status.PauseMenu;
                        }
                        else if (pressedKey.Key == ConsoleKey.I)
                        {
                            gameStatus = (int)Status.Inventory;
                        }
                        else
                        {
                            if (pressedKey.Key == ConsoleKey.W)
                            {
                                MovementManager.TryMove(player, 0, -1, collector);
                            }

                            else if (pressedKey.Key == ConsoleKey.A)
                            {
                                MovementManager.TryMove(player, -1, 0, collector);
                            }

                            else if (pressedKey.Key == ConsoleKey.S)
                            {
                                MovementManager.TryMove(player, 0, 1, collector);
                            }

                            else if (pressedKey.Key == ConsoleKey.D)
                            {
                                MovementManager.TryMove(player, 1, 0, collector);
                            }
                        }
                    } while (gameStatus == (int)Status.InGame);

                    if (gameStatus == (int)Status.PauseMenu)
                    {
                        int choice = pauseMenu.GetChoice(true);
                        if (choice == 0)
                        {
                            gameStatus = (int)Status.InGame;

                        }
                        else if (choice == 1)
                        {
                            gameStatus = (int)Status.StartMenu;
                        }
                    }

                    if (gameStatus == (int)Status.Inventory)
                    {
                        do
                        {
                            List<string> inventoryItems = player.GetInventory();
                            Menu inventoryMenu = new Menu(inventoryItems);
                            int inventoryChoice = inventoryMenu.GetChoice(true);
                            if (inventoryChoice == 2)
                            {
                                gameStatus = (int)Status.InGame;
                                break;
                            }
                            Menu slotMenu = new Menu(player.GetNamesBySlot(inventoryChoice + 1));
                            int slotChoice = slotMenu.GetChoice(true);
                            if (slotChoice == 0)
                            {
                                switch (inventoryChoice)
                                {
                                    case 0:
                                        player.EquipedWeapon = null;
                                        break;
                                    case 1:
                                        player.EquipedHelmet = null;
                                        break;
                                }

                            }
                            else player.ChangeItemByChoice(slotChoice, inventoryChoice);
                        } while (true);
                    }
                }
            } while (true);

        }
    }
}

