using System;
using System.IO;

namespace Roguelike
{
    public class MapCollector {

        protected string[] lines;
        
    }
    class MapRender : MapCollector
    {
        public MapRender()
        {

        }
        void RenderMap()
        {
            for(int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
