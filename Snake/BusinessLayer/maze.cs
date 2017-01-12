using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    class maze
    {

        static int[,] CreateMaze(int w,int h)
        {
            int width, height;
            width = w;
            height = h;

            int[,] maze = new int[width,height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i,j] = 0;   
                }

            }

            for (int i = 0; i < width; i++)
            {
                if (i == 0 || i == width - 1)
                {
                    for (int j = 0; j < height; j++)
                    {
                        maze[i, j] = 1;
                    } 
                }
                else
                {
                    maze[i, 0] = 1;
                    maze[i, height - 1] = 1;
                }
            }

            return maze;
        }

    }
}
