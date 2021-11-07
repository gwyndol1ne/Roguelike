﻿using System;
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
            ChestOpened = 5,
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
            string[] chestMenuItems;
            Menu chestMenu;
            Chest chest1 = new Chest(0, 1, 10,collector);
            chest1.GenerateContents(icollector.GetItemList);
            int gameStatus = (int)Status.StartMenu;
            int moveX = 0, moveY = 0;
            bool triedMoving = false;
            do
            {
                if (gameStatus == (int)Status.Closed)
                {
                    Environment.Exit(0);
                }
                if (gameStatus == (int)Status.StartMenu)
                {
                    gameStatus = startMenu.GetChoice();
                }
                if (gameStatus == (int)Status.ClassMenu)
                {
                    Console.Clear();
                    tarotMenu.GetChoice();
                    gameStatus = (int)Status.InGame;
                }
                if (gameStatus == (int)Status.InGame)
                {
                   
                    ConsoleKeyInfo pressedKey;
                    Draw.ReDrawMap(collector.GetMapById(player.MapId), player.X, player.Y, '@');
                    
                    do
                    {
                        moveX = 0;
                        moveY = 0;
                        GameInterface.GetGameInterface(player);
                        pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Escape)
                        {
                            gameStatus = (int)Status.PauseMenu;
                        }
                        else
                        {
                            if (pressedKey.Key == ConsoleKey.W)
                            {
                                player.Agility++;
                                moveY = -1;
                            }

                            else if (pressedKey.Key == ConsoleKey.A)
                            {
                                moveX = -1;
                            }

                            else if (pressedKey.Key == ConsoleKey.S)
                            {
                                moveY = 1;
                            }

                            else if (pressedKey.Key == ConsoleKey.D)
                            {
                                moveX = 1;
                            }
                            if (!MovementManager.TryMove(player, moveX, moveY, collector))
                            {
                                gameStatus = MovementManager.ChestTouched(player.MapId, player.X + moveX, player.Y + moveY, collector);
                            }
                            
                        }
                    } while (gameStatus == (int)Status.InGame);

                    if (gameStatus == (int)Status.PauseMenu)
                    {
                        int choice = pauseMenu.GetChoice();
                        if (choice == 0)
                        {
                            gameStatus = (int)Status.InGame;

                        }
                        else if (choice == 1)
                        {
                            gameStatus = (int)Status.StartMenu;
                        }
                    }
                    if (gameStatus == (int)Status.ChestOpened)
                    {
                        chestMenuItems = collector.GetChestItems(player.MapId, player.X + moveX, player.Y + moveY);
                        chestMenu = new Menu(chestMenuItems);
                        chestMenu.GetChoice();
                        gameStatus = (int)Status.InGame;
                    }
                }
            } while (true);
            
        }
    }
}

