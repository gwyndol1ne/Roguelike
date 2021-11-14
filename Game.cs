using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{

    class Game
    {
        static int gameStatus = (int)Status.StartMenu;
        static public int SetStatus
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
            Theft=11,
            InDialog=12


        }
        public static void Start()
        {
            Maps.Initialise();
            Player player = null;
            string[] startMenuItems = { "Новая игра", "Выход" };
            Menu startMenu = new Menu(startMenuItems);
            string[] pauseMenuItems = { "Продолжить игру ", "Выход в главное меню" };
            string[] NpcMenuItems = { "Обокрасть","Ударить","Поговорить" };
            Menu pauseMenu = new Menu(pauseMenuItems);
            Menu NpcMenu = new Menu(NpcMenuItems);
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
            arr2[0] = "Максим";
            arr2[1] = "Иди нахуй";
            arr2[2] = "Нет";
            string[] arr3 = new string[3];
            arr3[0] = "ОООО МЕНЯ ТОЖЕ";
            arr3[1] = "уфуфуфк";
            arr3[2] = "Лфдно";
            List<string> Message = new List<string>(arr);
            List<string> otwet = new List<string>(arr2);
            List<string> reaction = new List<string>(arr3);
            Dialog dialog = new Dialog(Message, otwet,reaction);
            Chest chest1 = new Chest(0, 1, 10);

            NPC npc1 = new NPC("Максим",11, 23, 22, 11, 33, 2, 0, 4, 32);
            NPC npc2 = new NPC("Максм", 11,25, 21, 12, 3, 2, 0, 6, 30);
            NPC YourNpc;
            chest1.GenerateContents(ItemCollector.GetAllItems());

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
                    player = new Player("a", 0, 10, 2, 0, 0, 0, 0, 10, 11);
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
                            npc1.X++;
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
                        if (choice < chestMenuItems.Length - 2){
                            player.AddItem(Maps.GetItemFromChest(player.MapId, player.X + moveX, player.Y + moveY, choice)); //сами думайте)
                        }
                        else if(choice == chestMenuItems.Length - 2)
                        {
                            player.AddItems(Maps.GetAllItemsFromChest(player.MapId,player.X+moveX,player.Y+moveY));
                        }
                        gameStatus = (int)Status.InGame;
                    }
                    if (gameStatus==(int)Status.InNpc)
                    {
                        
                        int choice = NpcMenu.GetChoice(true);
                        if (choice == 0)
                        {
                            gameStatus = (int)Status.Theft;

                        }
                        if (choice==1)
                        {
                            //становится злым хз
                            gameStatus = (int)Status.InGame;

                        }
                        else if (choice == 2)
                        {
                            gameStatus = (int)Status.InDialog;
                        }
                       

                    }
                    if (gameStatus==(int)Status.InDialog)
                    {
                        Console.Clear();
                        YourNpc = Maps.GetMyNpc(player.MapId, player.X + moveX, player.Y + moveY);
                        int leave = dialog.GetDialog(YourNpc);
                        if (leave == 0)
                        {
                            gameStatus = (int)Status.InGame;
                        }
                    }
                    if (gameStatus == (int)Status.Theft)
                    {
                        YourNpc = Maps.GetMyNpc(player.MapId, player.X + moveX, player.Y + moveY);
                        Menu TiefsMenu = new Menu(YourNpc.GetTiefsItemNames());
                        int choice = TiefsMenu.GetChoice(true);
                        if (choice < YourNpc.GetTiefsItemNames().Count - 2)
                        {
                            player.AddItem(Maps.GetItemFromTiefsBag(player.MapId, player.X + moveX, player.Y + moveY, choice)); //сами думайте)
                        }
                        else if (choice == YourNpc.GetTiefsItemNames().Count - 2)
                        {
                            player.AddItems(Maps.GetAllItemFromTiefsBag(player.MapId, player.X + moveX, player.Y + moveY));
                        }
                        gameStatus = (int)Status.InGame;
                    }
                }
            } while (true);
        }
    }
}

