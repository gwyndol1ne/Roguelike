using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class MovementManager
    {
        Map currentMap;
        public MovementManager(Map setMap)
        {
            currentMap = setMap;
        }
        public void setCurrentMap(Map map)
        {
            currentMap = map;
        }

    }
}
