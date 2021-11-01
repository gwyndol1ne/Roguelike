using System;

namespace Roguelike
{
    public class Tile
    {
        protected bool can_stand_on;
        protected char draw_symbol;
    }
    class EmptyTile : Tile
    {
        EmptyTile()
        {
            can_stand_on = true;
            draw_symbol = '.';
        }
    }
    class WallTile : Tile
    {
        WallTile()
        {
            can_stand_on = false;
            draw_symbol = '#';
        }
    }
    class DungeonEntranceTile : Tile
    {
        DungeonEntranceTile()
        {
            can_stand_on = true;
            draw_symbol = 'd';
        }
    }
    class BossEntranceTile : Tile
    {
        BossEntranceTile()
        {
            can_stand_on = true;
            draw_symbol = 'b';
        }
    }
    class SeaTile : Tile
    {
        SeaTile()
        {
            can_stand_on = false;
            draw_symbol = '$';
        }
    }
}
