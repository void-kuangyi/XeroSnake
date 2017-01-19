using System;


namespace BusinessLayer
{
    public class Maze
    {
        private const int border = 1;
        private const int noBorder = 0;
        private enum direction { horizon, vertical };
        private int width, height;
        private int[,] maze;
        private Random randomNumber;
        private int mazeMode;
        private enum mazeLevel { easy = 1, medium, hard};
        



        public Maze(int w, int h, int mazeMode)
        {
            width = w;
            height = h;
            this.mazeMode = mazeMode;
            maze = new int[height, width];
            randomNumber = new Random();
        }

        public int[,] CreateMaze()
        {
            GenerateBorder();

            switch (mazeMode)
            {
                case (int)mazeLevel.easy :
                    if (randomNumber.Next(0, 1) < 0.5)
                    {
                        GenerateHorizonJungleMaze();
                    } 
                    else
                    {
                        GenerateVerticalJungleMaze();
                    }
                    break;

                case (int)mazeLevel.medium:
                    GenerateCrossMaze();
                    break;

                case (int)mazeLevel.hard:
                    GenerateGridMaze();
                    break;

                default:
                    break;
            }


            return maze;
        }


        public void GenerateBorder()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    maze[i, j] = noBorder;
                }

            }

            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        maze[i, j] = border;
                    }
                }

                else
                {
                    maze[i, 0] = border;
                    maze[i, width - 1] = border;
                }
            }

        }


        public void GenerateGridMaze()
        {
            const int gapBetweenTwoRectangle = 4;
            const int rectangleWidth = 2;
            const int rectangleHeight = 2;
            for (int i = 0; i < height - 2; i = i + gapBetweenTwoRectangle)
            {
                for (int j = 0; j < width - 2; j = j + gapBetweenTwoRectangle)
                {

                    GenerateRectangleObstacle(i, j, rectangleWidth, rectangleHeight);

                }

            }

        }

        public void GenerateHorizonJungleMaze()
        {
            int gapBetweenTwoLine = randomNumber.Next(2, 5);

            for (int i = 0; i < height; i = i + gapBetweenTwoLine)
            {
                GenerateLineObstacle(i, 0, width / 3,(int)direction.horizon);
                GenerateLineObstacle(i, (width / 3) * 2, width / 3,(int)direction.horizon);

            }



        }

        public void GenerateVerticalJungleMaze()
        {
            int gapBetweenTwoLine = randomNumber.Next(4, 7);
            for (int i = 0; i < width; i = i + gapBetweenTwoLine)
            {
                GenerateLineObstacle(0, i, height / 3,(int)direction.vertical);
                GenerateLineObstacle((height / 3) * 2, i, height / 3,(int)direction.vertical);

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

        public void GenerateLineObstacle(int pointX, int pointY, int lineLength, int lineDirection)
        {
            switch (lineDirection)
            {
                case (int)direction.horizon:

                    for (int i = 0; i < lineLength; i++)
                    {
                        maze[pointX, pointY + i] = border;

                    }
                    break;
                case (int)direction.vertical:

                    for (int i = 0; i < lineLength; i++)
                    {
                        maze[pointX + i, pointY] = border;

                    }

                    break;



            }


        }

        public void GenerateRectangleObstacle(int pointX, int pointY, int rectangleWidth, int rectangleHeight)
        {
            for (int i = 0; i < rectangleHeight; i++)
            {
                for (int j = 0; j < rectangleWidth; j++)
                {
                    maze[pointX + i, pointY + j] = border;

                }

            }
        }


        public void GenerateCrossObstacle(int pointX, int pointY)
        {
            maze[pointX, pointY] = border;
            maze[pointX - 1, pointY] = border;
            maze[pointX + 1, pointY] = border;
            maze[pointX, pointY - 1] = border;
            maze[pointX, pointY + 1] = border;

        }
    }
}
