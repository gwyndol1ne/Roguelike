using System;
using Mapcollector;
using Screen;

namespace Roguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            MapCollector collector = new MapCollector();
            Draw screen = new Draw();
            Player player = new Player("a",0,0,0,0);
            screen.draw(collector.GetCurrentMap(player.getMapId()));
            Console.ReadLine();
        }
    }
}
