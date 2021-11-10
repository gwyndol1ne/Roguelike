using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{

    class Game
    {
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
            InDialog = 9,
            EntityCollided = 10

        }
        public static void Start()
        {
            Maps.Initialise();
            ItemCollector icollector = new ItemCollector();
            Player player = null;
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
            string[] arr = new string[2];
            string[] arr2 = new string[3];
            arr[0] = "Привет как тебя зовут ?";
            arr2[0] = "ytn";
            arr2[1] = "lf";
            arr2[2] = "nj";
            List<string> Message = new List<string>(arr);
            List<string> otwet = new List<string>(arr2);
            Dialog dialog = new Dialog(Message, otwet);
            Chest chest1 = new Chest(0, 1, 10);
            NPC npc1 = new NPC("Максим", 23, 22, 11, 33, 2, 0, 4, 32);
            chest1.GenerateContents(icollector.GetItemList);
            int gameStatus = (int)Status.StartMenu;
            int moveX = 0, moveY = 0;
            do
            {
                if (gameStatus == (int)Status.Closed)
                {
                    Environment.Exit(0);
                }
                if (gameStatus == (int)Status.StartMenu)
                {
                    player = new Player("a", 0, 10, 0, 0, 0, 0, 10, 11);
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
                    Draw.ReDrawMap(Maps.GetDrawnMap(player.MapId), player.X, player.Y, '@');

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
                            if (!MovementManager.TryMove(player, moveX, moveY))
                            {


               


                             


                                gameStatus = MovementManager.CantMoveDecider(player.MapId, player.X + moveX, player.Y + moveY);

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
                            int inventoryChoice = inventoryMenu.GetChoice(true); //3 что это?
                            if (inventoryChoice == 8)
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
                                        player.EquippedLeftHand = null;
                                        break;
                                    case 1:
                                        player.EquippedRightHand = null;
                                        break;
                                    case 2:
                                        player.EquippedHelmet = null;
                                        break;
                                    case 3:
                                        player.EquippedPlate = null;
                                        break;
                                    case 4:
                                        player.EquippedLegs = null;
                                        break;
                                    case 5:
                                        player.EquippedBoots = null;
                                        break;
                                    case 6:
                                        player.EquippedRing = null;
                                        break;
                                    case 7:
                                        player.EquippedAmulet = null;
                                        break;
                                }
                            }
                            else player.ChangeItemByChoice(slotChoice, inventoryChoice);
                        } while (true);
                    }
                    if (gameStatus == (int)Status.ChestOpened)
                    {
                        chestMenuItems = Maps.GetChestItems(player.MapId, player.X + moveX, player.Y + moveY);
                        chestMenu = new Menu(chestMenuItems);
                        int choice = chestMenu.GetChoice(true);
                        if (choice < chestMenuItems.Length - 2){
                            player.AddItem(Maps.GetItemFromChest(player.MapId, player.X + moveX, player.Y + moveY, choice)); //сами думайте)
                        }
                        else if(choice == chestMenuItems.Length - 2)
                        {
                            player.AddItems(Maps.GetAllItemsFromChest(player.MapId,player.X+moveX,player.Y+moveY));
                        }
                        gameStatus = (int)Status.InGame;
                    }
                    if (gameStatus==(int)Status.InDialog)
                    {
                        Console.Clear();
                        dialog.GetDialog(npc1);
                        ConsoleKeyInfo key;
                        key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Enter)
                        {

                        }
                    }
                }
            } while (true);
        }
    }
}

