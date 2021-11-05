using System;

namespace Roguelike
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 34);
            Game.Start();
        }
    }
}
