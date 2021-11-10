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
            if (transitionTo[entity.Y,entity.X] != -1)
            {
                Maps.DelEntity(entity.MapId, entity.X, entity.Y);
                int moveToMap = transitionTo[entity.Y, entity.X];
                Draw.currentMapId = moveToMap;
                transition transitionCoords = Maps.GetTransitionCoords(moveToMap,entity.MapId);
                entity.Y = transitionCoords.x;
                entity.X = transitionCoords.y;
                entity.MapId = moveToMap;
                Maps.SetEntity(entity.MapId, entity.X, entity.Y, entity);
                return true;
            }
            return false;
        }
        public static bool TryMove(Entity entity, int x, int y)
        {
            int canMove = Maps.CanMoveTo(entity.MapId,entity.X + x, entity.Y + y);
            if (canMove == 1)
            {
                Draw.DrawAtPos(entity.X, entity.Y, Maps.GetDrawnMap(entity.MapId)[entity.Y, entity.X]);
                Maps.MoveEntity(entity.MapId, entity.X, entity.Y, x * canMove, y * canMove, entity);
                entity.X += x * canMove;
                entity.Y += y * canMove;
                Draw.DrawAtPos(entity.X, entity.Y, entity.Symbol);
            }
            bool moved = canMove == 1 ? true : false; //метод Даника
            if (moved && MovementManager.Transition(entity))
            {
                if (entity.MapId == Draw.currentMapId)
                {
                    Draw.ReDrawMap(Maps.GetDrawnMap(entity.MapId), entity.MapId);
                }
            }
            return moved;
        }
        public static int CantMoveDecider(int mapId, int x, int y)
        {
            int cgb = Maps.CantMoveBecause(mapId, x, y);
            if(cgb == (int)Maps.CantGoBecause.Chest)
            {
                return (int)Game.Status.ChestOpened;
            }
            else if (cgb == (int)Maps.CantGoBecause.Entity)
            {
                return (int)Game.Status.InDialog;
            }
            return (int)Game.Status.InGame;
        }
        
    }
}
