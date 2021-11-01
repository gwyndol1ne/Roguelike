using System;
using System.Collections.Generic;

namespace Roguelike
{
    class TileManager
    {
        List<bool> canStandOn;
        TileManager() 
        { 
            List<bool> canStandOn = new List<bool>(); 
        }
        string unstandable = "#~ ";
        public void update(string[] currentMap)
        {
            for(int i = 0; i < currentMap.Length; i++)
            {
                for(int j = 0; j < currentMap[i].Length; j++)
                {
                    if (unstandable.IndexOf(currentMap[i][j]) >= 0)
                    {
                        canStandOn.Add(false);
                    }
                    else
                    {
                        canStandOn.Add(true);
                    }
                }
            }
        }
        public void clearMap()
        {
            canStandOn.Clear();
        }
    }
}
