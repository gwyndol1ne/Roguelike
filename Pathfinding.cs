using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    static class Pathfinder
    {
        static private int startX, startY, endX, endY;
        struct Node
        {
            public double weight;
            public int x, y, prevX, prevY, dist;
            public bool wasChecked;
        }
        static private Node[,] nodes;
        public static point[] GetPath(int sx, int sy, int ex, int ey, bool[,] pass)
        {
            for(int i = -1; i < 2; i += 2)
            {
                if (sx + i == ex && sy == ey) return returnEdgeCase();
                if(sx == ex && sy+i == ey) return returnEdgeCase();
            }
            if(sx==ex && sy == ey) return returnEdgeCase();
            Setup(sx, sy, ex, ey, pass);
            CalculatePath();
            return CalculateMovement();
        }
        private static point[] returnEdgeCase()
        {
            point[] equalResult = new point[1];
            equalResult[0].x = 0;
            equalResult[0].y = 0;
            return equalResult;
        }
        private static void Setup(int sx, int sy, int ex, int ey, bool[,] pass)
        {
            startX = sx;
            startY = sy;
            endX = ex;
            endY = ey;
            nodes = new Node[pass.GetLength(0), pass.GetLength(1)];
            for (int i = 0; i < pass.GetLength(0); i++) for (int j = 0; j < pass.GetLength(1); j++)
                {
                    nodes[i, j].wasChecked = !pass[i, j];
                    nodes[i, j].x = i;
                    nodes[i, j].y = j;
                }
            nodes[sx, sy].dist = 0;
            nodes[sx, sy].prevX = sx;
            nodes[sx, sy].prevY = sy;
            nodes[sx, sy].weight = CalculateHeuristic(sx, sy);
            CalculateAdjasent(sx, sy);
        }
        private static void CalculatePath()
        {
            point nextNode;
            while (nodes[endX, endY].weight == 0)
            {
                nextNode = GetNextNode();
                CalculateAdjasent(nextNode.x, nextNode.y);
            }
        }
        private static double CalculateHeuristic(int x, int y)
        {
            return Math.Sqrt(Math.Pow(x - endX, 2) + Math.Pow(y - endY, 2));
        }
        private static point GetNextNode()
        {
            int minIndex = 0;
            List<Node> minPossible = new List<Node>();
            for (int i = 0; i < nodes.GetLength(0); i++) for (int j = 0; j < nodes.GetLength(1); j++) if (!nodes[i, j].wasChecked && nodes[i, j].weight != 0) minPossible.Add(nodes[i, j]);
            for (int i = 0; i < minPossible.Count; i++) if (minPossible[minIndex].weight > minPossible[i].weight) minIndex = i;
            point result;
            result.x = minPossible[minIndex].x;
            result.y = minPossible[minIndex].y;
            return result;
        }
        private static void CalculateAdjasent(int x, int y)
        {
            for (int i = -1; i < 2; i += 2)
            {
                if (!nodes[x + i, y].wasChecked && nodes[x + i, y].weight == 0) nodes[x + i, y] = CalculateNode(nodes[x + i, y], nodes[x, y]);
                if (!nodes[x, y + i].wasChecked && nodes[x, y + i].weight == 0) nodes[x, y + i] = CalculateNode(nodes[x, y + i], nodes[x, y]);
            }
            nodes[x, y].wasChecked = true;
        }
        private static Node CalculateNode(Node node, Node prevNode)
        {
            node.dist = prevNode.dist + 1;
            node.prevX = prevNode.x;
            node.prevY = prevNode.y;
            node.weight = node.dist + CalculateHeuristic(node.x, node.y);
            return node;
        }
        private static point[] CalculateMovement()
        {
            Node[] path = CalculatePathBackwards();
            point[] result = new point[path.Length - 1];
            for (int i = 0; i < path.Length - 1; i++)
            {
                result[i].x = path[i + 1].x - path[i].x;
                result[i].y = path[i + 1].y - path[i].y;
            }
            return result;
        }
        private static Node[] CalculatePathBackwards()
        {
            List<Node> path = new List<Node>();
            int x = endX, y = endY, bx;
            while (nodes[x, y].prevX != x || nodes[x, y].prevY != y)
            {
                path.Add(nodes[x, y]);
                bx = nodes[x, y].prevX;
                y = nodes[x, y].prevY;
                x = bx;
            }
            Node[] result = new Node[path.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = path[path.Count - i - 1];
            }
            return result;
        }
    }
}
