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
        static private bool Transition(Entity entity)
        {
            int[,] transitionTo = Maps.GetTransitionsTo(entity.MapId);
            if (transitionTo[entity.Y, entity.X] != -1)
            {
                int moveToMap = transitionTo[entity.Y, entity.X];
                transition transitionCoords = Maps.GetTransitionCoords(moveToMap, entity.MapId);
                entity.Y = transitionCoords.x;
                entity.X = transitionCoords.y;
                entity.MapId = moveToMap;
                return true;
            }
            return false;
        }
        public static bool TryMove(Entity entity, int x, int y)
        {
            int canMove = Maps.CanMoveTo(entity.MapId, entity.X + x, entity.Y + y);
            if (canMove == 1)
            {
                Draw.DrawAtPos(entity.X, entity.Y, Maps.GetDrawnMap(entity.MapId)[entity.Y, entity.X]);
                entity.X += x * canMove;
                entity.Y += y * canMove;
                Draw.DrawAtPos(entity.X, entity.Y, '@');
            }
            bool moved = canMove == 1 ? true : false; //метод Даника
            if (moved && MovementManager.Transition(entity))
            {
                Draw.ReDrawMap(Maps.GetDrawnMap(entity.MapId), entity.X, entity.Y, '@');
            }
            return moved;
        }
        public static int CantMoveDecider(int mapId, int x, int y)
        {
            int cgb = Maps.CantMoveBecause(mapId, x, y);
            if (cgb == (int)Maps.CantGoBecause.Chest)
            {
                return (int)Game.Status.ChestOpened;
            }

            if (Maps.checkNpc(mapId, x, y))
            {
                return (int)Game.Status.InDialog;
            }
            return (int)Game.Status.InGame;
        }

    }
}
