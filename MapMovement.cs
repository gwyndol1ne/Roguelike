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
        public static void TryMove(Player player, int x, int y, MapCollector collector)
        {
            int canMove = collector.CanMove(player.Y + y, player.X + x, player.MapId);
            if (canMove == 1)
            {
                Draw.DrawAtPos(player.X, player.Y, collector.GetDrawnMapById(player.MapId)[player.Y, player.X]);
                player.X += x * canMove;
                player.Y += y * canMove;
                Draw.DrawAtPos(player.X, player.Y, '@');
            }
            bool moved = canMove == 1 ? true : false; //метод Даника
            if (moved && collector.Transition(player))
            {
                Draw.ReDrawMap(collector.GetMapById(player.MapId), player.X, player.Y, '@');
                moved = false;
            }
        }
    }
}
