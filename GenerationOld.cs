using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Dungeon
    {
        int width, height;
        int[,] maze;
        int nuli;
        public void createDungeon()
        {
            int iterations = 1125;
            width = 22;
            height = 19;
            maze = new int[height, width];

            int currentY = height - 1;
            int currentX = width - 1;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    maze[y, x] = 1;
                }
            }

            maze[currentY, currentX] = 0;

            Random rng = new Random();

            for (int i = 0; i < iterations; i++)
            {
                switch (rng.Next(1, 5))
                {
                    case 1:
                        if (currentY > 2) currentY--;
                        break;
                    case 2:
                        if (currentX > 2) currentX--;
                        break;
                    case 3:
                        if (currentY < height - 2) currentY++;
                        break;
                    case 4:
                        if (currentX < width - 2) currentX++;
                        break;
                }
                maze[currentY, currentX] = 0;
            }
            // maze[currentY1, currentX1] = 3;
            for (int i = 0; i < height; i++)
            {
                for (int f = 0; f < width; f++)
                {
                    if (maze[i, f] == 0)
                    {
                        nuli++;

                    }
                }

            }
            if (nuli < height * width)
            {
                createDungeon();
            }

        }
        public void GetExit()
        {
            for (int i = 0; i < height; i++)
            {
                for (int f = 0; f < width; f++)
                {
                    if (maze[i, f] == 0)
                    {
                        maze[i, f] = 2;
                        return;
                    }
                }

            }
        }
        public void GetChest()
        {
            for (int i = height / 2 - 4; i < height; i++)
            {
                for (int f = width / 2 - 4; f < width; f++)
                {
                    if (maze[i, f] == 0)
                    {
                        maze[i, f] = 3;

                        return;
                    }
                }

            }
        }
        public void GetEntity()
        {
            Random rng = new Random();
            for (int i = height - rng.Next(2, 15); i < height; i++)
            {
                for (int f = width - rng.Next(2, 15); f < width; f++)
                {
                    if (maze[i, f] == 0)
                    {
                        maze[i, f] = 5;
                        return;
                    }
                }

            }
        }
        public char[,] GetDungeon()
        {
            char[,] vs = new char[height + 1, width + 1]; ;
            for (int i = 0; i < height; i++)
            {
                for (int f = 0; f < width; f++)
                {
                    if (maze[i, f] == 0)
                    {
                        vs[i, f] = '.';
                    }
                    if (maze[i, f] == 1)
                    {

                        vs[i, f] = '#';
                    }
                    if (maze[i, f] == 2)
                    {
                        vs[i, f] = 'E';
                    }
                    if (maze[i, f] == 3)
                    {
                        vs[i, f] = 'C';
                    }
                    if (maze[i, f] == 5)
                    {
                        vs[i, f] = '$';
                    }

                }

            }

            for (int i = 0; i < width + 1; i++)
            {
                vs[height, i] = '#';
            }

            for (int i = 0; i < height; i++)
            {
                vs[i, width] = '#';
            }
            return vs;
        }
        public char[,] GetFullDungeon(int EntityValue)
        {
            this.createDungeon();
            this.GetExit();
            this.GetChest();
            for (int i = 0; i < EntityValue; i++)
            {
                this.GetEntity();
            }
            return this.GetDungeon();
        }
    }

}
