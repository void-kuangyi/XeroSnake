using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class maze
    {
        private const int BORDER = 1;
        private const int NO_BORDER = 0;
        private int width, height;
        private int[,] Maze;
        Random random_number;



        public maze(int w,int h)
        {
            width = w;
            height = h;
            Maze = new int[height, width];
            random_number = new Random();
        }

        public int[,] CreateMaze()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Maze[i,j] = NO_BORDER;   
                }

            }

            for (int i = 0; i < height; i++)
            {
                //every colum of first row and last row should be marked as border 
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Maze[i, j] = BORDER;
                    } 
                }

                //first and last colum of other rows should be marked as border
                else
                {
                    Maze[i, 0] = BORDER;
                    Maze[i, width - 1] = BORDER;
                }
            }


            Generate_Horizon_Line_In_Maze(random_number.Next(0,height),random_number.Next(0,width),2);

            Generate_Vertical_Line_In_Maze(random_number.Next(0, height), random_number.Next(0, width), 2);

            Generate_Rectangle_In_Maze(random_number.Next(0,height),2,3,5);

            return Maze;
        }



        public void Generate_Horizon_Line_In_Maze(int PointX, int PointY, int LineLength)
        {
            for (int i = 0; i < LineLength; i++)
            {
                Maze[PointX, PointY + i] = BORDER;

            }

        }



        public void Generate_Vertical_Line_In_Maze(int PointX, int PointY, int LineLength)
        {

            for (int i = 0; i < LineLength; i++)
            {
                Maze[PointX + i, PointY] = BORDER;

            }
        }



        public void Generate_Rectangle_In_Maze(int PointX,int PointY,int rectangle_width, int rectangle_height)
        {
            for (int i = 0; i < rectangle_height; i++)
            {
                for (int j = 0; j < rectangle_width; j++)
                {
                    Maze[PointX + i, PointY + j] = BORDER;

                }

            }




        }
    }
}
