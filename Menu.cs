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
            ConsoleKeyInfo key;
            DateTime lastPressedTime = DateTime.MinValue;
            do
            {
                Console.Clear();
              
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.SetCursorPosition(40, 1 + i);
                    if (cursor == i)
                    {
                     
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                 
                    else
                    {
                       
                        Console.WriteLine(menuItems[i]);
                    }

                }
                System.Threading.Thread.Sleep(80);
                key = Console.ReadKey();
                if (DateTime.Now > lastPressedTime.AddSeconds(.02))
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
                
                lastPressedTime = DateTime.Now;
            }
            while (key.Key != ConsoleKey.Enter);
            return cursor;
        }
    }
}
