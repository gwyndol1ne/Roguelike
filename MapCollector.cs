using System;
using System.IO;
using System.Collections.Generic;
using mapsolvers;
using connections;

namespace mapcollector {
    public class MapCollector {

        public List<Map> baseMaps = new List<Map>();
        string[] workingOnMap;
        string[] mapPaths = { "../../../main.map", "../../../boss.map" };
        public MapCollector()
        {
            for(int i = 0; i < mapPaths.Length; i++)
            {
                workingOnMap = System.IO.File.ReadAllLines(mapPaths[i]);
                baseMaps.Add(new Map(i, workingOnMap));
            }
        }
        public struct Map
        {
            int MapID;
            string[] textMap;
            string[] drawnMap;
            List<Connection> connections;
            bool[,] standable;
            public Map(int mi, string[] tm)
            {
                connections = new List<Connection>();
                MapSolver solver = new MapSolver();
                MapID = mi;
                textMap = tm;
                connections = solver.ConnectionSolver(tm);
                drawnMap = solver.SolverDrawnMap(tm);
                standable = solver.SolverStandable(tm, "#~ ");
            }
        }
    }
}
