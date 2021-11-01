using System;
using System.IO;

namespace Roguelike
{
    public class MapCollector {

        protected string[] mainMap;
        protected MapCollector()
        {
            mainMap = File.ReadAllLines("../../../main.map");
        }
        
    }
    class MapRender : MapCollector
    {
        public void RenderMainMap()
        {
            for(int i = 0; i < mainMap.Length; i++)
            {
                Console.WriteLine(mainMap[i]);
            }
        }
    }
}
