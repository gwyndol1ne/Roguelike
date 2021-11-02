using System;
using System.IO;
using System.Collections.Generic;
using Mapsolvers;
using Connections;

namespace Mapcollector
{
    public class MapCollector
    {

        public List<Map> baseMaps = new List<Map>();
        string[] workingOnMap;
        string[] mapPaths = { "../../../main.map", "../../../boss.map" };
        string[] connections = { "1 ", "0 "};
        public MapCollector()
        {
            for (int i = 0; i < mapPaths.Length; i++)
            {
                workingOnMap = System.IO.File.ReadAllLines(mapPaths[i]);
                baseMaps.Add(new Map(i, MapAdder()));
            }
        }
        protected string[] MapAdder()
        {
            int actualLength = 0;
            for(int i = 0; i < workingOnMap.Length; i++)
            {
                if (workingOnMap[i] != null)
                {
                    actualLength++;
                }
            }
            string[] result = new string[actualLength];
            for(int i = 0; i < workingOnMap.Length; i++)
            {
                if (workingOnMap[i] != null)
                {
                    result[i] = workingOnMap[i];
                }
            }
            return result;
        }
        
        public string[] GetCurrentMap(int i)
        {
            return baseMaps[i].drawnMap;
        }
    }
    public struct Map
    {
        int MapID;
        string[] textMap;
        public string[] drawnMap;
        List<Connection> connections;
        bool[,] standable;
        public Map(int mi, string[] tm)
        {
            connections = new List<Connection>();
            MapSolver solver = new MapSolver();
            MapID = mi;
            textMap = tm;
            connections = solver.ConnectionSolver(textMap);
            drawnMap = solver.SolverDrawnMap(textMap);
            standable = solver.SolverStandable(drawnMap, "#~ ");
        }
    }
}
