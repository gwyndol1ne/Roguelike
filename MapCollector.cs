using System;
using System.IO;

namespace Roguelike
{
    public class MapCollector {

        public string[] mainMap;
        public MapCollector()
        {
            mainMap = File.ReadAllLines("../../../main.map");
        }
    }
    class MapRender : MapCollector
    {
        public void RenderMap(string[] map)
        {
            for(int i = 0; i < map.Length; i++)
            {
                Console.WriteLine(map[i]);
            }
        }
    }
}
