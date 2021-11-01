using System;
using System.IO;
using System.Collections.Generic;

namespace Roguelike
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

    public class MapCollector {

        List<Map> baseMaps;
        string[] mapPaths = { "../../../main.map", "../../../boss.map" };
        public MapCollector()
        {
            for(int i = 0; i < mapPaths.Length; i++)
            {
                System.IO.File.ReadAllLines(mapPaths[i]);
            }
        }
        struct Map
        {
            int MapID;
            string[] textMap;
            string[] drawnMap;
            List<int> connectionX;
            List<int> connectionY;
            List<int> connectionID;
            Map(int mi, string[] tm)
            {
                connectionX = new List<int>();
                connectionY = new List<int>();
                connectionID = new List<int>();
                Solver solver = new Solver();
                MapID = mi;
                textMap = tm;
                List<Connection> copy = solver.ConnectionSolver(tm);
                for (int i = 0; i < copy.Count; i++)
                {
                    connectionX.Add(copy[i].cx);
                    connectionY.Add(copy[i].cy);
                    connectionID.Add(copy[i].id);
                }
                drawnMap = solver.SolveDrawnMap(tm);
            }
        }
    }
    class MapRender : MapCollector
    {
        public void RenderMap(string[] map)
        {
            for(int i = 0; i < map.Length-1; i++)
            {
                Console.WriteLine(map[i]);
            }
        }
    }
    class Solver
    {
        public List<Connection> ConnectionSolver(string[] map)
        {
            int index = 0;
            string numbers = "0123456789";
            List<Connection> result = new List<Connection>();
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    index = numbers.IndexOf(map[i][j]);
                    if (index >= 0)
                    {
                        result.Add(new Connection(i, j, index));
                    }
                }
            }
            return result;
        }
        public string[] SolveDrawnMap(string[] map)
        {
            string[] result = map;
            string numbers = "1234567890";
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (numbers.IndexOf(map[i][j]) >= 0)
                    {
                        map[i].ToCharArray()[j] = '#';
                    }
                }
            }
            return result;
        }
        
    }

    
}
