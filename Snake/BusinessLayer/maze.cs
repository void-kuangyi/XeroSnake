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
            Generate_Basic_Maze();

            Generate_All_Obstacles();
            
            return Maze;
        }


        public void Generate_Basic_Maze()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Maze[i, j] = NO_BORDER;
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

        }



        public void Generate_All_Obstacles()
        {
            int Vertical_Line_Head_X = random_number.Next(0,height);
            int Vertical_Line_Head_Y = random_number.Next(width/2,width);

            Generate_Vertical_Line_Obstacle(Vertical_Line_Head_X,Vertical_Line_Head_Y,random_number.Next(0,height - Vertical_Line_Head_X));

            int Horizon_Line_Head_X = random_number.Next(0,height);
            int Horizon_Line_Head_Y = random_number.Next(0,width/2 - 1);

            Generate_Horizon_Line_Obstacle(Horizon_Line_Head_X,Horizon_Line_Head_Y,random_number.Next(0,Horizon_Line_Head_Y));


            int Rectangle_Head_X = random_number.Next(0, height/2);
            int Rectangle_Head_Y = random_number.Next(0, width/2);

            int Rectangle_width = random_number.Next(0,width/2 - Rectangle_Head_Y);
            int Rectangle_height = random_number.Next(0, height/2 - Rectangle_Head_X);

            Generate_Rectangle_Obstacle(Rectangle_Head_X, Rectangle_Head_Y, Rectangle_width, Rectangle_height);



        }


        public void Generate_Horizon_Line_Obstacle(int PointX, int PointY, int LineLength)
        {
            for (int i = 0; i < LineLength; i++)
            {
                Maze[PointX, PointY  - i] = BORDER;

            }

        }



        public void Generate_Vertical_Line_Obstacle(int PointX, int PointY, int LineLength)
        {

            for (int i = 0; i < LineLength; i++)
            {
                Maze[PointX + i, PointY] = BORDER;

            }
        }



        public void Generate_Rectangle_Obstacle(int PointX,int PointY,int rectangle_width, int rectangle_height)
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
