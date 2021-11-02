using System;
using System.Collections.Generic;
using System.Text;

namespace Connections
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
    public struct ConnectionPair
    {
        Connection map1Trigger, map2Trigger;
        int id1, id2;
        public ConnectionPair(Connection c1, Connection c2, int i1, int i2) 
        {
            map1Trigger = c1;
            map2Trigger = c2;
            id1 = i1;
            id2 = i2;
        }
    }
}
