using System;
using Roguelike;

namespace Roguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            MapCollector collector = new MapCollector();
            MapRender render = new MapRender();
            render.RenderMap(collector.mainMap);
            Console.ReadLine();
        }
    }
}
