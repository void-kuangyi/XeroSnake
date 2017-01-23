using System;


namespace BusinessLayer
{
    public class Maze
    {
        private enum direction { horizon, vertical };
        private int width, height;
        private Elements[,] maze;
        private Random randomNumber;
        private MazeLevel mazeMode;


        public Maze(int w, int h, MazeLevel mazeMode)
        {
            width = w;
            height = h;
            this.mazeMode = mazeMode;
            maze = new Elements[height, width];
            randomNumber = new Random();
        }

        public Elements[,] CreateMaze()
        {
            GenerateBorder();

            switch (mazeMode)
            {

                case MazeLevel.Beginner:
                    GenerateSuperEasyMaze();
                    break;

                case MazeLevel.Easy:
                    if (randomNumber.NextDouble() < 0.5)
                    {
                        GenerateHorizonJungleMaze();
                    }
                    else
                    {
                        GenerateVerticalJungleMaze();
                    }
                    
                    break;

                case MazeLevel.Medium:
                    GenerateCrossMaze();
                    break;

                case MazeLevel.Hard:
                    GenerateGridMaze();
                    break;

                default:
                    throw new SystemException("Invalid game mode passed to Maze class");
            }


            return maze;
        }


        public void GenerateBorder()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    maze[i, j] = Elements.blank;
                }

            }

            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        maze[i, j] = Elements.mazeBody;
                    }
                }

                else
                {
                    maze[i, 0] = Elements.mazeBody;
                    maze[i, width - 1] = Elements.mazeBody;
                }
            }

        }


        public void GenerateGridMaze()
        {
            const int gapBetweenTwoRectangle = 5;
            const int rectangleWidth = 1;
            const int rectangleHeight = 1;
            for (int i = 1; i < height - 1; i = i + gapBetweenTwoRectangle)
            {
                for (int j = 0; j < width - 1; j = j + gapBetweenTwoRectangle)
                {

                    GenerateRectangleObstacle(i, j, rectangleWidth, rectangleHeight);

                }

            }

        }

        public void GenerateHorizonJungleMaze()
        {
            int gapBetweenTwoLine = 5;

            for (int i = 0; i < height; i = i + gapBetweenTwoLine)
            {
                GenerateLineObstacle(i, 0, width / 3, (int)direction.horizon);
                GenerateLineObstacle(i, (width / 3) * 2, width / 3, (int)direction.horizon);

            }



        }

        public void GenerateVerticalJungleMaze()
        {
            int gapBetweenTwoLine = 7;
            for (int i = 0; i < width; i = i + gapBetweenTwoLine)
            {
                GenerateLineObstacle(0, i, height / 3, (int)direction.vertical);
                GenerateLineObstacle((height / 3) * 2 + 1, i, height / 3, (int)direction.vertical);

            }


        }

        public void GenerateSuperEasyMaze()
        {
            const int gapBetweenTwoRectangle = 20;
            const int rectangleWidth = 3;
            const int rectangleHeight = 5;
            for (int i = 7; i < height - 1; i = i + gapBetweenTwoRectangle)
            {
                for (int j = 12; j < width - 1; j = j + gapBetweenTwoRectangle)
                {

                    GenerateRectangleObstacle(i, j, rectangleWidth, rectangleHeight);

                }

            }

        }

        public void GenerateCrossMaze()
        {
            int gapBetweenTwoCross = 7;
            for (int i = 5; i < height - 1; i = i + gapBetweenTwoCross)
            {
                for (int j = 6; j < width - 3; j = j + gapBetweenTwoCross)
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
                        maze[pointX, pointY + i] = Elements.mazeBody;

                    }
                    break;
                case (int)direction.vertical:

                    for (int i = 0; i < lineLength; i++)
                    {
                        maze[pointX + i, pointY] = Elements.mazeBody;

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
                    maze[pointX + i, pointY + j] = Elements.mazeBody;

                }

            }
        }


        public void GenerateCrossObstacle(int pointX, int pointY)
        {
            maze[pointX, pointY] = Elements.mazeBody;
            maze[pointX - 1, pointY] = Elements.mazeBody;
            maze[pointX + 1, pointY] = Elements.mazeBody;
            maze[pointX, pointY - 1] = Elements.mazeBody;
            maze[pointX, pointY + 1] = Elements.mazeBody;

        }
    }
}
