using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class maze
    {
        private const int border = 1;
        private const int no_border = 0;
        private int width, height;




        public maze(int w,int h)
        {
            width = w;
            height = h;
        }

        public int[,] CreateMaze(int w,int h)
        {
            int[,] maze = new int[width,height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i,j] = no_border;   
                }

            }

            for (int i = 0; i < width; i++)
            {
                //every row of first column and last column should be marked as border 
                if (i == 0 || i == width - 1)
                {
                    for (int j = 0; j < height; j++)
                    {
                        maze[i, j] = border;
                    } 
                }

                //first and last row of other columns should be marked as border
                else
                {
                    maze[i, 0] = border;
                    maze[i, height - 1] = border;
                }
            }

            return maze;
        }

    }
}
