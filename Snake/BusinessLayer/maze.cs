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

        public int[,] CreateMaze()
        {
            int[,] maze = new int[height,width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    maze[i,j] = no_border;   
                }

            }

            for (int i = 0; i < height; i++)
            {
                //every colum of first row and last row should be marked as border 
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        maze[i, j] = border;
                    } 
                }

                //first and last colum of other rows should be marked as border
                else
                {
                    maze[i, 0] = border;
                    maze[i, width - 1] = border;
                }
            }

            return maze;
        }

    }
}
