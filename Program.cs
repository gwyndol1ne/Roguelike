using System;
using Mapcollector;
using Screen;
using Menu;
namespace Roguelike
{
    delegate void method();

    class Program
    {
        static void Main(string[] args)
        {
            int Playbel = 1;
            void Play()
            {
                Console.WriteLine("Начата игра");
                Playbel = 2;
            }

            string[] items = { "Новая игра", "Выход" };
            method[] methods = new method[] { Play, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            menuResult = menu.PrintMenu();
            methods[menuResult]();

            if (Playbel == 2)
            {
                Console.Clear();
                string[] Class = { "The Fool", "Magician's Red ", "High Priestess", "Empress ", "Emperor", "Hierophant Green", "Lovers", "Silver Chariot", "Strength", "Hermit Purple", "Wheel of Fortune", "Justice", "Hanged Man", "Death Thirteen", "Yellow Temperance", "Ebony Devil", "Tower of Gray", "Star Platinum", "Dark Blue Moon ", "Sun", "Judgement ", "The World" };

                ConsoleMenu menu2 = new ConsoleMenu(Class);
                int menuResult2;
                menuResult2 = menu2.PrintMenu();
                Console.Clear();
                Console.WriteLine("Выбран класс");
                Console.WriteLine(Class[menuResult2]);
                Playbel = 3;
            }
            Console.Clear();
            if (Playbel == 3)
            {
                MapCollector collector = new MapCollector();
                Draw screen = new Draw();
                Player player = new Player("a", 0, 0, 0, 0);
                screen.draw(collector.GetCurrentMap(player.getMapId()));
                Console.ReadLine();
            }
        }
        static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");

        }
    }
}
