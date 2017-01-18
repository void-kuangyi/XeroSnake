using System;


namespace BusinessLayer
{
    public class maze
    {
        private const int border = 1;
        private const int noBorder = 0;
        private int width, height;
        private int[,] Maze;
        private Random randomNumber;



        public maze(int w, int h)
        {
            width = w;
            height = h;
            Maze = new int[height, width];
            randomNumber = new Random();
        }

        public int[,] CreateMaze()
        {
            GenerateBorder();
        
            int mazeMode = randomNumber.Next(1,3);

            /*  switch (mazeMode)
              {
                  case 1:
                      GenerateGridMaze();
                      break;


                  case 2:
                      GenerateCrossMaze();
                      break;


                  default:
                      break;
              } */

            // GenerateCrossMaze();
            GenerateGridMaze();

            return Maze;
        }


        public void GenerateBorder()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Maze[i, j] = noBorder;
                }

            }

            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Maze[i, j] = border;
                    }
                }

                else
                {
                    Maze[i, 0] = border;
                    Maze[i, width - 1] = border;
                }
            }

        }


        public void GenerateGridMaze()
        {
            for (int i = 0; i < height; i = i + 4)
            {
                for (int j = 0; j < width; j = j + 4)
                {

                        GenerateRectangleObstacle(i, j, 2, 2);


                }

            }

        }

        public void GenerateJungleMaze()
        {







        }


        public void GenerateCrossMaze()
        {
            for (int i = 1; i < height - 1; i = i + height/5)
            {
                for (int j = 1; j < width - 1; j = j + width/5)
                {
                    GenerateCrossObstacle(i,j);

                }

            }   

        }

        /*     public void Generate_All_Obstacles()
             {
                 int Vertical_Line_Head_X = random_number.Next(0, height);
                 int Vertical_Line_Head_Y = random_number.Next(width / 2, width);

                 Generate_Vertical_Line_Obstacle(Vertical_Line_Head_X, Vertical_Line_Head_Y, random_number.Next(0, height - Vertical_Line_Head_X));

                 int Horizon_Line_Head_X = random_number.Next(0, height);
                 int Horizon_Line_Head_Y = random_number.Next(0, width / 2 - 1);

                 Generate_Horizon_Line_Obstacle(Horizon_Line_Head_X, Horizon_Line_Head_Y, random_number.Next(0, Horizon_Line_Head_Y));


                 int Rectangle_Head_X = random_number.Next(0, height / 2);
                 int Rectangle_Head_Y = random_number.Next(0, width / 2);

                 int Rectangle_width = random_number.Next(0, width / 2 - Rectangle_Head_Y);
                 int Rectangle_height = random_number.Next(0, height / 2 - Rectangle_Head_X);

                 Generate_Rectangle_Obstacle(Rectangle_Head_X, Rectangle_Head_Y, Rectangle_width, Rectangle_height);

             }
             */

        public void GenerateHorizonLineObstacle(int PointX, int PointY, int LineLength)
        {
            for (int i = 0; i < LineLength; i++)
            {
                Maze[PointX, PointY + i] = border;

            }

        }



        public void GenerateVerticalLineObstacle(int PointX, int PointY, int LineLength)
        {

            for (int i = 0; i < LineLength; i++)
            {
                Maze[PointX + i, PointY] = border;

            }
        }



        public void GenerateRectangleObstacle(int PointX, int PointY, int rectangle_width, int rectangle_height)
        {
            for (int i = 0; i < rectangle_height; i++)
            {
                for (int j = 0; j < rectangle_width; j++)
                {
                    Maze[PointX + i, PointY + j] = border;

                }

            }
        }


        public void GenerateCrossObstacle(int pointX, int pointY)
        {
            Maze[pointX,pointY] = border;
            Maze[pointX - 1, pointY] = border;
            Maze[pointX + 1, pointY] = border;
            Maze[pointX, pointY - 1] = border;
            Maze[pointX, pointY + 1] = border;

        }
    }
}
