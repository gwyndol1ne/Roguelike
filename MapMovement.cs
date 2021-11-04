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
        public void MovementCheck(Player player, int movementX,int movementY)
        {
            int tryingX = player.X + movementX;
            int tryingY = player.Y + movementY;
            if (currentMap.passable[tryingX, tryingY])
            {

            }
        }
    }
}
