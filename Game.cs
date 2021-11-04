using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Game
    {
        const int gameBeforeStarting = 0;
        const int gameStarted = 2;
        public static void Start()
        {
            int gameStatus;
            string[] startMenuItems = { "Новая игра", "Выход" };
            Menu startMenu = new Menu(startMenuItems);
            gameStatus = startMenu.GetChoice();

            if (gameStatus == gameBeforeStarting)
            {
                Console.Clear();
                /*string[] tarotMenuItems = { "The Fool", "Magician's Red ", "High Priestess", "Empress ", "Emperor", "Hierophant Green", 
                                   "Lovers", "Silver Chariot", "Strength", "Hermit Purple", "Wheel of Fortune", "Justice", 
                                   "Hanged Man", "Death Thirteen", "Yellow Temperance", "Ebony Devil", "Tower of Gray", "Star Platinum", 
                                   "Dark Blue Moon ", "Sun", "Judgement ", "The World" };*/
                gameStatus = gameStarted;
            }

            if (gameStatus == gameStarted)
            {
                MapCollector collector = new MapCollector();
                Game game = new Game();
                Console.Clear();
                Draw screen = new Draw();
                Player player = new Player("a", 0, 0, 0, 0, 0);
                MovementManager movement = new MovementManager(collector.getMapById(player.MapId));
                screen.draw(collector.getDrawnMapById(player.MapId));
                Console.ReadLine();
            }
        }
    }
}
