using System;
using System.Collections.Generic;
using System.Text;

namespace connections
{
    public struct Connection
    {
        public int cx, cy, id;
        public Connection(int x, int y, int id)
        {
            cx = x;
            cy = y;
            this.id = id;
        }
    }
}
