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



            int iterations = 1000;
            width = 23;
            height = 20;
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

            int currentY1 = 0;
            int currentX1 = 0;
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
                if (i == rng.Next(75, 999))
                {
                    currentX1 = currentX;
                    currentY1 = currentY;
                }

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
            if (nuli < height * width / 2)
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
        public void GetDungeon()
        {
            for (int i = 0; i < height; i++)
            {
                for (int f = 0; f < width; f++)
                {
                    if (maze[i, f] == 0)
                    {
                        Console.Write("." + " ");
                    }
                    if (maze[i, f] == 1)
                    {
                        Console.Write("#" + " ");
                    }
                    if (maze[i, f] == 2)
                    {
                        Console.Write("E" + " ");
                    }
                    if (maze[i, f] == 3)
                    {
                        Console.Write("С" + " ");
                    }
                    if (maze[i, f] == 5)
                    {
                        Console.Write("$" + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }


}
