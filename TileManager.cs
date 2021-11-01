using System;
using System.Collections.Generic;

namespace Roguelike
{
    class TileManager
    {
        struct TransitionTile
        {
            int x, y;
            MapTransition transition;
        }
        List<TransitionTile> transitions = new List<TransitionTile>();
        List<List<bool>> canStandOn = new List<List<bool>>();
        string unstandable = "#~ ";
        public void update(string[] currentMap)
        {
            for(int i = 0; i < currentMap.Length; i++)
            {
                canStandOn.Add(new List<bool>());
                for(int j = 0; j < currentMap[i].Length; j++)
                {
                    if (unstandable.IndexOf(currentMap[i][j]) >= 0)
                    {
                        canStandOn[i].Add(false);
                    }
                    else
                    {
                        canStandOn[i].Add(true);
                    }
                }
            }
        }
        public void clearMap()
        {
            canStandOn.Clear();
            transitions.Clear();
        }
        public void printCurrentMapBools()
        {
            for(int i = 0; i < canStandOn.Count; i++)
            {
                for(int j = 0; j < canStandOn[i].Count; j++)
                {
                    Console.Write(canStandOn[i][j]);
                }
                Console.WriteLine();
            }
        }
        
    }
    class MapTransition : TileManager
    {
        string[] transitionTo;
        MapTransition(string[] map)
        {
            transitionTo = map;
        }
        void UseTransition()
        {

        }
    }
}
