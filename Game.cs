using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{

    class Game
    {
        static int gameStatus = (int)Status.StartMenu;
        static public int GameStatus
        {
            set { gameStatus = value; }
        }
        public enum Status
        {
            ClassMenu = 0,
            Closed = 1,
            InGame = 2,
            PauseMenu = 3,
            StartMenu = 4,
            Inventory = 5,
            SlotChoice = 6,
            ItemChoice = 7,
            ChestOpened = 8,
            InNpc = 9,
            EntityCollided = 10,
            Theft = 11,
            InDialog = 12,
            Save = 13,
            Load = 14,
            InBattle = 15,
        }
        public static void Start(ref Player player, ref List<Entity> entities, ref List<Chest> chests)
        {
            Maps.Initialise();
            SaveAndLoad saveAndLoad = new SaveAndLoad();
            string[] startMenuItems = { "Новая игра", "Загрузить", "Выход" };
            Menu startMenu = new Menu(startMenuItems);


            string[] NpcMenuItems = { "Обокрасть", "Ударить", "Поговорить" };

            string[] pauseMenuItems = { "Продолжить игру ", "Сохранить", "Загрузить", "Выход в главное меню" };

            Menu pauseMenu = new Menu(pauseMenuItems);
            Menu NpcMenu = new Menu(NpcMenuItems);
            string[] tarotMenuItems = { "The Fool", "Magician's Red ", "High Priestess", "Empress ", "Emperor", "Hierophant Green",
                                       "Lovers", "Silver Chariot", "Strength", "Hermit Purple", "Wheel of Fortune", "Justice",
                                       "Hanged Man", "Death Thirteen", "Yellow Temperance", "Ebony Devil", "Tower of Gray", "Star Platinum",
                                       "Dark Blue Moon ", "Sun", "Judgement ", "The World" };
            Menu tarotMenu = new Menu(tarotMenuItems);
            string[] chestMenuItems;
            Menu chestMenu;
            Enemy enemy0 = new Enemy("Волибир", 100, 1, 1, 1, 1, 3, 0, 10, 16);
            string[] arr = new string[2];
            string[] arr2 = new string[3];
            arr[0] = "Привет как тебя зовут ?";
            arr2[0] = "Максим";
            arr2[1] = "Иди нахуй";
            arr2[2] = "Нет";
            string[] arr3 = new string[3];
            arr3[0] = "ОООО МЕНЯ ТОЖЕ";
            arr3[1] = "уфуфуфк";
            arr3[2] = "Лфдно";
            List<string> message = new List<string>(arr);
            List<string> answer = new List<string>(arr2);
            List<string> reaction = new List<string>(arr3);
            Dialog dialog = new Dialog(message, answer, reaction);
            Chest chest1 = new Chest(0, 1, 10);
            Friend npc1 = new Friend("Максим", 11, 23, 22, 11, 33, 2, 0, 4, 11);
            NPC YourSodaEffect;
            chest1.GenerateContents(ItemCollector.GetAllItems());
            /*int gameStatus = (int)Status.StartMenu;*/
            int moveX = 0, moveY = 0;
            do
            {
                if (gameStatus == (int)Status.Closed)
                {
                    Environment.Exit(0);
                }
                if (gameStatus == (int)Status.StartMenu)
                {
                    int choice = startMenu.GetChoice(true);
                    switch (choice)
                    {
                        case 0:
                            gameStatus = (int)Status.ClassMenu;
                            break;
                        case 1:
                            gameStatus = (int)Status.Load;
                            break;
                        case 2:
                            gameStatus = (int)Status.Closed;
                            break;
                    }
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
                    Draw.ReDrawMap(Maps.GetDrawnMap(player.MapId), player.MapId);
                    do
                    {
                        moveX = 0;
                        moveY = 0;
                        GameInterface.DrawMapInterface(player, 53, 3);
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
                                moveY = -1;
                            }

                            else if (pressedKey.Key == ConsoleKey.A)
                            {
                                moveX = -2;
                            }

                            else if (pressedKey.Key == ConsoleKey.S)
                            {
                                moveY = 1;
                            }

                            else if (pressedKey.Key == ConsoleKey.D)
                            {
                                moveX = 2;
                            }
                            if ((moveX != 0) || (moveY != 0))
                            {
                                enemy0.MoveTowards(player.X, player.Y);
                                player.Move(moveX, moveY);
                            }
                        }
                    } while (gameStatus == (int)Status.InGame);
                }
                if (gameStatus == (int)Status.PauseMenu)
                {
                    int choice = pauseMenu.GetChoice(true);
                    switch (choice)
                    {
                        case 0:
                            gameStatus = (int)Status.InGame;
                            break;
                        case 1:
                            gameStatus = (int)Status.Save;
                            break;
                        case 2:
                            gameStatus = (int)Status.Load;
                            break;
                        case 3:
                            gameStatus = (int)Status.StartMenu;
                            break;
                    }
                }

                if (gameStatus == (int)Status.Save)
                {

                    saveAndLoad.Save(ref player, ref entities, ref chests);
                    gameStatus = (int)Status.PauseMenu;
                }

                if (gameStatus == (int)Status.Load)
                {
                    if (saveAndLoad.Load(ref player, ref entities, ref chests))
                    {
                        Game.GameStatus = (int)Status.InGame;
                        Console.Clear();
                        Game.Start(ref player, ref entities, ref chests);
                    }
                    else
                    {
                        gameStatus = (int)Status.PauseMenu;
                    }
                }

                if (gameStatus == (int)Status.Inventory)
                {
                    do
                    {
                        List<string> inventoryItems = player.GetInventory();
                        Menu inventoryMenu = new Menu(inventoryItems);
                        int inventoryChoice = inventoryMenu.GetChoice(true); //3 что это? тот кто это писал з
                        if (inventoryChoice == 8)
                        {
                            gameStatus = (int)Status.InGame;
                            break;
                        }
                        Menu slotMenu = new Menu(player.GetNamesBySlot(inventoryChoice));
                        int slotChoice = slotMenu.GetChoice(true);
                        if (slotChoice == 0)
                        {
                            player.EquippedItems[inventoryChoice] = null;
                        }
                        else player.ChangeItemByChoice(slotChoice, inventoryChoice);
                    } while (true);
                }
                if (gameStatus == (int)Status.ChestOpened)
                {
                    chestMenuItems = Maps.GetChestItems(player.MapId, player.X + moveX, player.Y + moveY);
                    chestMenu = new Menu(chestMenuItems);
                    int choice = chestMenu.GetChoice(true);
                    if (choice < chestMenuItems.Length - 2)
                    {
                        player.AddItem(Maps.GetItemFromChest(player.MapId, player.X + moveX, player.Y + moveY, choice)); //сами думайте)
                    }
                    else if (choice == chestMenuItems.Length - 2)
                    {
                        player.AddItems(Maps.GetAllItemsFromChest(player.MapId, player.X + moveX, player.Y + moveY));
                    }
                    gameStatus = (int)Status.InGame;
                }
                if (gameStatus == (int)Status.InNpc)
                {

                    int choice = NpcMenu.GetChoice(true);
                    if (choice == 0)
                    {
                        gameStatus = (int)Status.Theft;

                    }
                    if (choice == 1)
                    {
                        //становится злым хз
                        gameStatus = (int)Status.InGame;

                    }
                    else if (choice == 2)
                    {
                        gameStatus = (int)Status.InDialog;
                    }


                }
                if (gameStatus == (int)Status.InDialog)
                {
                    Console.Clear();

                    YourSodaEffect = Maps.GetMyNpc(player.MapId, player.X + moveX, player.Y + moveY);
                    int leave = dialog.GetDialog(YourSodaEffect);
                    if (leave == 0)

                    {
                        gameStatus = (int)Status.InGame;
                    }
                }
                if (gameStatus == (int)Status.Theft)
                {
                    YourSodaEffect = Maps.GetMyNpc(player.MapId, player.X + moveX, player.Y + moveY);
                    Menu TiefsMenu = new Menu(YourSodaEffect.GetTiefsItemNames());
                    int choice = TiefsMenu.GetChoice(true);
                    if (choice < YourSodaEffect.GetTiefsItemNames().Count - 2)
                    {
                        player.AddItem(Maps.GetItemFromTiefsBag(player.MapId, player.X + moveX, player.Y + moveY, choice)); //сами думайте)
                    }
                    else if (choice == YourSodaEffect.GetTiefsItemNames().Count - 2)
                    {
                        player.AddItems(Maps.GetAllItemFromTiefsBag(player.MapId, player.X + moveX, player.Y + moveY));
                    }
                    gameStatus = (int)Status.InGame;
                }
                if (gameStatus == (int)Game.Status.InBattle)
                {
                    Console.Clear();
                    Battle battle1 = new Battle(player, Maps.GetEnemyEntities(player.MapId, player.X, player.Y));
                }

            } while (true);
        }
    }
}

