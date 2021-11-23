using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{

    class Game
    {
        static Status gameStatus;
        public static Status GameStatus { get { return gameStatus; } set { gameStatus = value; } }
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
            InNPC = 9,
            EntityCollided = 10,
            Theft = 11,
            InDialog = 12,
            Save = 13,
            Load = 14,
            InBattle = 15,
            InBattleForEntity = 16,
        }
        public static void Start(Player player, List<Entity> entities, List<Chest> chests)
        {
            GameStatus = Status.StartMenu;
            Maps.Initialise();
            Maps.SetEntity(player.MapId, player.X, player.Y, player);
            foreach (Entity entity in entities) Maps.SetEntity(entity.MapId, entity.X, entity.Y, entity);
            foreach (Chest chest in chests) Maps.SetChest(chest.MapId, chest.X, chest.Y, chest);
            Draw.currentMapId = player.MapId;
            SaveAndLoad saveAndLoad = new SaveAndLoad();
            string[] startMenuItems = { "Новая игра", "Загрузить", "Выход" };
            Menu startMenu = new Menu(startMenuItems);
            string[] NpcMenuItems = { "Обокрасть", "Ударить", "Поговорить" };
            string[] pauseMenuItems = { "Продолжить игру ", "Сохранить", "Загрузить", "Выход в главное меню" };
            Menu pauseMenu = new Menu(pauseMenuItems);
            Menu NpcMenu = new Menu(NpcMenuItems);
            string[] tarotMenuItems = { "The Fool", "Magician's Red ", "Empress ", "Emperor", "Hierophant Green",
                                       "Lovers", "Silver Chariot",  "Star Platinum", "Tower of Gray", "The World" };
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
            List<string> message = new List<string>(arr);
            List<string> answer = new List<string>(arr2);
            List<string> reaction = new List<string>(arr3);
            Dialog dialog = new Dialog(message, answer, reaction);
            NPC currentNPC;
            
            int moveX = 0, moveY = 0;
            do
            {
                switch (gameStatus)
                {
                    case Status.Closed:
                        Environment.Exit(0);
                        break;
                    case Status.StartMenu:
                        switch (startMenu.GetChoice(true, true))
                        {
                            case 0:
                                gameStatus = Status.ClassMenu;
                                break;
                            case 1:
                                gameStatus = Status.Load;
                                break;
                            case 2:
                                gameStatus = Status.Closed;
                                break;
                        }
                        break;
                    case Status.ClassMenu:
                        int choice = tarotMenu.GetChoice(true, true);
                        player.TarotNumber = choice;
                        player.ChangeStatsByTarot(player.TarotNumber);
                        player.UpdateEffects();
                        gameStatus = Status.InGame;
                        break;
                    case Status.InGame:
                        Draw.ReDrawMap(Maps.GetDrawnMap(player.MapId), player.MapId);
                        do
                        {
                            if (player.Quests[player.QuestNumber].trigger == true) //вылетай вылетай мы же богатые заново запустим
                            {
                                player.QuestNumber++;
                                player.Quests[player.QuestNumber].trigger = false;
                            }
                            moveX = 0;
                            moveY = 0;
                            GameInterface.DrawMapInterface(player, 53, 3);
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.Escape:
                                    gameStatus = Status.PauseMenu;
                                    break;
                                case ConsoleKey.I:
                                    gameStatus = Status.Inventory;
                                    break;
                                case ConsoleKey.W:
                                    moveY = -1;
                                    break;
                                case ConsoleKey.A:
                                    moveX = -2;
                                    break;
                                case ConsoleKey.S:
                                    moveY = 1;
                                    break;
                                case ConsoleKey.D:
                                    moveX = 2;
                                    break;
                            }
                            if (((moveX != 0) || (moveY != 0)) && (player.Move(moveX, moveY)))
                            {
                                Maps.EnemyMovement(player.MapId, player.X, player.Y);
                                player.UpdateEffects();
                            }
                        } while (gameStatus == Status.InGame);
                        break;
                    case Status.PauseMenu:
                        switch (pauseMenu.GetChoice(true, true))
                        {
                            case 0:
                                gameStatus = Status.InGame;
                                break;
                            case 1:
                                gameStatus = Status.Save;
                                break;
                            case 2:
                                gameStatus = Status.Load;
                                break;
                            case 3:
                                Game.Start(Program.GenerateStartPlayer(), Program.GenerateStartEntities(), Program.GenerateStartChests());
                                break;
                        }
                        break;
                    case Status.Save:
                        saveAndLoad.Save(ref player, ref entities, ref chests);
                        gameStatus = Status.PauseMenu;
                        break;
                    case Status.Load:
                        if (saveAndLoad.Load(ref player, ref entities, ref chests))
                        {
                            Maps.Initialise();
                            GameStatus = Status.InGame;
                            Start(player, entities, chests);
                        }
                        else gameStatus = Status.PauseMenu;
                        break;
                    case Status.Inventory:
                        do
                        {
                            List<string> inventoryItems = player.GetInventory();
                            Menu inventoryMenu = new Menu(inventoryItems);
                            int inventoryChoice = inventoryMenu.GetChoice(true, true); //3 что это? тот кто это писал з
                            if (inventoryChoice == inventoryItems.Count-1)
                            {
                                gameStatus = Status.InGame;
                                break;
                            }
                            Menu slotMenu = new Menu(player.GetNamesBySlot(inventoryChoice));
                            int slotChoice = slotMenu.GetChoice(true, true);
                            if (slotChoice == 0)
                            {
                                if(inventoryChoice!=inventoryItems.Count-2) player.EquippedItems[inventoryChoice] = null;
                            }
                            else player.ChangeItemByChoice(slotChoice, inventoryChoice);
                        } while (true);
                        break;
                    case Status.ChestOpened:
                        chestMenuItems = Maps.GetChestItems(player.MapId, player.X + moveX, player.Y + moveY);
                        chestMenu = new Menu(chestMenuItems);
                        int chestChoice = chestMenu.GetChoice(true, true);
                        if (chestChoice < chestMenuItems.Length - 2)
                        {
                            player.AddItem(Maps.GetItemFromChest(player.MapId, player.X + moveX, player.Y + moveY, chestChoice));
                        }
                        else if (chestChoice == chestMenuItems.Length - 2)
                        {
                            player.AddItems(Maps.GetAllItemsFromChest(player.MapId, player.X + moveX, player.Y + moveY));
                        }
                        gameStatus = Status.InGame;
                        break;
                    case Status.InNPC:
                        switch (NpcMenu.GetChoice(true, true))
                        {
                            case 0:
                                gameStatus = Status.Theft;
                                break;
                            case 1:
                                currentNPC = (NPC)Maps.GetEntity(player.MapId, player.X + moveX, player.Y + moveY);
                                currentNPC = new Enemy(currentNPC.Name, currentNPC.Stats["hp"][0], currentNPC.Stats["damage"][0],
                                    currentNPC.Stats["strength"][0], currentNPC.Stats["agility"][0],currentNPC.Stats["intelligence"][0],
                                    currentNPC.Stats["defense"][0], currentNPC.MapId, currentNPC.X, currentNPC.Y, currentNPC.TrigerNummber); //ничего не ужасно все дозволено
                                gameStatus = Status.InBattle;
                                break;
                            case 2:
                                gameStatus = Status.InDialog;
                                break;
                        }
                        break;
                    /*case Status.InDialog:
                        Console.Clear();
                        NPC currentNPC = (NPC)Maps.GetEntity(player.MapId, player.X + moveX, player.Y + moveY);
                        if (dialog.GetDialog(currentNPC, player, npc1) == 0)
                            gameStatus = Status.InGame;
                        break;*///остается в комментах пока Илья не поменяет так, чтобы работало с текущим вариантом загрузки нпс
                    case Status.Theft:
                        currentNPC = (NPC)Maps.GetEntity(player.MapId, player.X + moveX, player.Y + moveY);
                        Menu TiefsMenu = new Menu(currentNPC.GetTiefsItemNames());
                        int theftChoice = TiefsMenu.GetChoice(true, true);
                        if (theftChoice == currentNPC.GetTiefsItemNames().Count - 1)
                        {
                            gameStatus = Status.InGame;
                        }
                        else if (theftChoice < currentNPC.GetTiefsItemNames().Count - 2)
                        {
                            if (new Random().Next(0, 2) == 1)
                            {
                                player.AddItem(Maps.GetItemFromNPC(player.MapId, player.X + moveX, player.Y + moveY, theftChoice));
                                gameStatus = Status.InGame;
                            }
                            else
                            {
                                gameStatus = Status.InBattle;
                            }
                        }
                        else if (theftChoice == currentNPC.GetTiefsItemNames().Count - 2)
                        {
                            if (new Random().Next(0, currentNPC.NPCInventory.Count) == 1)
                            {
                                player.AddItems(Maps.GetAllItemsFromNPC(player.MapId, player.X + moveX, player.Y + moveY));
                                gameStatus = Status.InGame;
                            }
                            else
                            {
                                gameStatus = Status.InBattle;
                            }
                        }
                        break;
                    case Status.InBattle:
                        Battle battle1 = new Battle(player, Maps.GetNearEntities(player.MapId, player.X, player.Y));
                        break;
                }
            } while (true);
        }
    }
}