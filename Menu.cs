using System.Text;
using System;


namespace Roguelike
{
    class Menu
    {
        private string[] menuItems;
        private int cursor;

        public Menu(string[] MenuItems)
        {
            menuItems = MenuItems;
            cursor = 0;
        }

        public int GetChoice()
        {
            cursor = 0;
            Console.Clear();
            ConsoleKeyInfo key;
            bool exit = false;
                do
                {
                    for (int i = 0; i < menuItems.Length; i++)
                    {
                        Console.SetCursorPosition(60 - ((menuItems[i].Length + 1) / 2), i);
                        if (cursor == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) exit = true;
                    else
                    {
                        if (key.Key == ConsoleKey.UpArrow)
                        {
                            cursor--;
                            if (cursor == -1) cursor = menuItems.Length - 1;
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            cursor++;
                            if (cursor == menuItems.Length) cursor = 0;
                        }
                    }
                } while (!exit);
            return cursor;
        }
    }
}
