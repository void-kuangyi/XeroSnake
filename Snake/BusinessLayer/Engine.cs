using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Engine
    {
        private const int SNAKEINITIALLENGTH = 4;
        private const int MAZEBODY = 1;
        private const int SNAKEBODY = 3;
        private const int SNAKEHEAD = 2;
        private const int FOOD = 4;
        private const int STEP = 1;
        private const int SNAKEHITSMAZE = 5;
        private int mazeLength { get; set; }
        private int mazeWidth { get; set; }
        private int[,] mazeArray { get; set; }

        private maze gameMaze;

        private GameSnake gameSnake1;
        // For future use, 2 player game mode
        //private GameSnake gameSnake2;
        private List<Food> foodList = new List<Food>();


        private enum gameMode
        {
            basic,
        }
        public enum snakeAction
        {
            eat,
            die,
            move
        }
        public enum direction
        {
            right,
            left,
            up,
            down
        }

        gameMode currentMode = gameMode.basic;


        public Engine(int length, int width, int mode)
        {
            mazeLength = length;
            mazeWidth = width;
            Score.resetScore();
        }

        public int[,] initializeGame()
        {

            switch (currentMode)
            {
                case gameMode.basic:


                    // Create a New Maze and initialize it
                    gameMaze = new maze(mazeWidth, mazeLength);
                    mazeArray = gameMaze.CreateMaze();

                    // Add the Snake
                    gameSnake1 = new GameSnake();
                    //List<Point> snakeBody = new List<Point>();
                    List<Point> snakeBody = gameSnake1.createFirstSnake(mazeLength, mazeWidth, SNAKEINITIALLENGTH);

                    // Make the whole snake as body first
                    foreach (Point value in snakeBody)
                    {
                        mazeArray[value.returnX(), value.returnY()] = SNAKEBODY;
                    }
                    // Identify snake head
                    Point head = snakeBody[0];
                    mazeArray[head.returnX(), head.returnY()] = SNAKEHEAD;

                    // Add the Food
                    foodList.Add(new Food());

                    foreach (Food value in foodList)
                    {
                        bool isValid = true;
                        do
                        {
                            value.generateFood(mazeLength, mazeWidth);
                            isValid = validateNewFoodLocation(value);
                        } while (!isValid);
                        mazeArray[value.getXLocation(), value.getyLocation()] = FOOD;
                    }

                    break;

                default:
                    // Invalid gameMode
                    throw new System.Exception("Invalid Game Mode!");
            }

            return mazeArray;
        }

        public int[,] updateGame(int snakeDirection)
        {
            Point newSnakeHead = getNewHead(snakeDirection);
            List<Point> snakesNewLocation;
            switch (mazeArray[newSnakeHead.returnX(), newSnakeHead.returnY()])
            {

                case MAZEBODY:  // snake hits the maze
                    if (Score.getScore() > Score.getHighScore())
                    {
                        Score.setHighScore(Score.getScore());
                    }
                    mazeArray[0, 0] = SNAKEHITSMAZE;
                    return mazeArray;


                case FOOD:  // snake hits the food
                    snakesNewLocation = gameSnake1.snakeMove(snakeDirection, true);
                    mazeArray = gameMaze.CreateMaze();
                    foreach (Point value in snakesNewLocation)
                    {
                        mazeArray[value.returnX(), value.returnY()] = SNAKEBODY;
                    }
                    // Identify snake head
                    Point head = snakesNewLocation[0];
                    mazeArray[head.returnX(), head.returnY()] = SNAKEHEAD;

                    int foodToRemove = 0;
                    foreach (Food value in foodList)
                    {
                        if ((newSnakeHead.returnX() == value.getXLocation()) && (newSnakeHead.returnY() == value.getyLocation()))
                        {
                            Score.incrementScore(value.getFoodType());
                            foodToRemove = foodList.IndexOf(value);
                        }
                    }
                    foodList.RemoveAt(foodToRemove);



                    Food newFood = new Food();
                    bool isValid = true;
                    do
                    {
                        newFood.generateFood(mazeLength, mazeWidth);
                        isValid = validateNewFoodLocation(newFood);
                        if (isValid)
                        {
                            foodList.Add(newFood);
                            mazeArray[newFood.getXLocation(), newFood.getyLocation()] = FOOD;
                        }
                    } while (!isValid);


                    break;

                default:   // snake moves
                    snakesNewLocation = gameSnake1.snakeMove(snakeDirection, false);
                    mazeArray = gameMaze.CreateMaze();
                    foreach (Point value in snakesNewLocation)
                    {
                        mazeArray[value.returnX(), value.returnY()] = SNAKEBODY;
                    }
                    Point newhead = snakesNewLocation[0];
                    mazeArray[newhead.returnX(), newhead.returnY()] = SNAKEHEAD;

                    foreach (Food value in foodList)
                    {
                        mazeArray[value.getXLocation(), value.getyLocation()] = FOOD;
                    }


                    break;
            }
            return mazeArray;
        }

        private Point getNewHead(int snakeDirection)
        {
            List<Point> snakeBody = gameSnake1.returnCurrentSnakePosition();

            // Check current snake head location.
            Point snakeHead = snakeBody.First();

            // Cross check with new snake head location.
            Point newSnakeHead;
            int x = snakeHead.returnX();
            int y = snakeHead.returnY();
            switch (snakeDirection)
            {

                case (int)direction.right:
                    newSnakeHead = new Point(x + STEP, y);
                    break;

                case (int)direction.left:
                    newSnakeHead = new Point(x - STEP, y);
                    break;

                case (int)direction.up:
                    newSnakeHead = new Point(x, y - STEP);
                    break;

                case (int)direction.down:
                    newSnakeHead = new Point(x, y + STEP);
                    break;

                default:
                    throw new System.Exception("Invalid direction.");
            }
            return newSnakeHead;
        }
        public bool validateNewFoodLocation(Food newFood)
        {
            int x = newFood.getXLocation();
            int y = newFood.getyLocation();

            if ((x >= mazeLength) || (y >= mazeWidth))
            {
                return false;
            }
            if (mazeArray[x, y] == MAZEBODY)
            {
                return false;
            }
            if (mazeArray[x, y] == SNAKEBODY)
            {
                return false;
            }
            if (mazeArray[x, y] == SNAKEHEAD)
            {
                return false;
            }
            return true;
        }
    }
}