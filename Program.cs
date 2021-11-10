using System;


using System.Media;
namespace Roguelike
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Roguelike";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Game.Start();
        }
    }
}
