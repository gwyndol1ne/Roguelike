using System;
using System.Collections.Generic;
using System.Text;

namespace Connections
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
    public struct ConnectionPair
    {
        Connection map1Trigger, map2Trigger;
        int id1, id2;
    }
}
