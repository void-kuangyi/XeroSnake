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

            int mazeMode = randomNumber.Next(1, 5);

            switch (mazeMode)
            {
                case 1:
                    GenerateGridMaze();
                    break;

                case 2:
                    GenerateCrossMaze();
                    break;

                case 3:
                    GenerateVerticalJungleMaze();
                    break;

                case 4:
                    GenerateHorizonJungleMaze();
                    break;

                default:
                    break;
            }


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
            for (int i = 0; i < height - 2; i = i + 4)
            {
                for (int j = 0; j < width - 2; j = j + 4)
                {

                    GenerateRectangleObstacle(i, j, 2, 2);

                }

            }

        }

        public void GenerateHorizonJungleMaze()
        {
            int gapBetweenTwoLine = randomNumber.Next(2, 5);

            for (int i = 0; i < height; i = i + gapBetweenTwoLine)
            {
                GenerateHorizonLineObstacle(i, 0, width / 3);
                GenerateHorizonLineObstacle(i, (width / 3) * 2, width / 3);

            }



        }

        public void GenerateVerticalJungleMaze()
        {
            int gapBetweenTwoLine = randomNumber.Next(4, 7);
            for (int i = 0; i < width; i = i + gapBetweenTwoLine)
            {
                GenerateVerticalLineObstacle(0, i, height / 3);
                GenerateVerticalLineObstacle((height / 3) * 2, i, height / 3);

            }


        }


        public void GenerateCrossMaze()
        {
            for (int i = 1; i < height - 1; i = i + height / 5)
            {
                for (int j = 1; j < width - 1; j = j + width / 5)
                {
                    GenerateCrossObstacle(i, j);

                }

            }

        }

        public void GenerateHorizonLineObstacle(int pointX, int pointY, int lineLength)
        {
            for (int i = 0; i < lineLength; i++)
            {
                Maze[pointX, pointY + i] = border;

            }

        }



        public void GenerateVerticalLineObstacle(int pointX, int pointY, int lineLength)
        {

            for (int i = 0; i < lineLength; i++)
            {
                Maze[pointX + i, pointY] = border;

            }
        }



        public void GenerateRectangleObstacle(int pointX, int pointY, int rectangleWidth, int rectangleHeight)
        {
            for (int i = 0; i < rectangleHeight; i++)
            {
                for (int j = 0; j < rectangleWidth; j++)
                {
                    Maze[pointX + i, pointY + j] = border;

                }

            }
        }


        public void GenerateCrossObstacle(int pointX, int pointY)
        {
            Maze[pointX, pointY] = border;
            Maze[pointX - 1, pointY] = border;
            Maze[pointX + 1, pointY] = border;
            Maze[pointX, pointY - 1] = border;
            Maze[pointX, pointY + 1] = border;

        }
    }
}
