using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public struct Connection
    {
        public int cx, cy, id;
        public Connection(int X, int Y, int Id)
        {
            cx = X;
            cy = Y;
            id = Id;
        }
    }
}
