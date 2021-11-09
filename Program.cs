using System;


using System.Media;
namespace Roguelike
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            Game.Start();
        }
    }
}
