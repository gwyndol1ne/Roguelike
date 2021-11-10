using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public struct transition
    {
        public int x, y;
    }
    static class MovementManager
    {
        static private bool Transition(Player player)
        {
            int[,] transitionTo = Maps.GetTransitionsTo(player.MapId);
            if (transitionTo[player.Y,player.X] != -1)
            {
                int moveToMap = transitionTo[player.Y, player.X];
                transition transitionCoords = Maps.GetTransitionCoords(moveToMap,player.MapId);
                player.Y = transitionCoords.x;
                player.X = transitionCoords.y;
                player.MapId = moveToMap;
                return true;
            }
            return false;
        }
        public static bool TryMove(Player player, int x, int y)
        {
            int canMove = Maps.CanMoveTo(player.MapId,player.X + x, player.Y + y);
            if (canMove == 1)
            {
                Draw.DrawAtPos(player.X, player.Y, Maps.GetDrawnMap(player.MapId)[player.Y, player.X]);
                player.X += x * canMove;
                player.Y += y * canMove;
                Draw.DrawAtPos(player.X, player.Y, '@');
            }
            bool moved = canMove == 1 ? true : false; //метод Даника
            if (moved && MovementManager.Transition(player))
            {
                Draw.ReDrawMap(Maps.GetDrawnMap(player.MapId), player.X, player.Y, '@');
            }
            return moved;
        }
        public static int ChestTouched(int mapId, int x, int y)
        {
            if(Maps.ChestHere(mapId, x, y))
            {
                return (int)Game.Status.ChestOpened;
            }
            return (int)Game.Status.InGame;
        }
        
    }
}
