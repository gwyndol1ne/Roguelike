using System.Text;
using System;


namespace Menu
{
    class ConsoleMenu
    {
        int time = 0;
        readonly string[] menuItems;
        int counter = 0;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }
        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }

                }
                System.Threading.Thread.Sleep(1000);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }

    }
}
