using BusinessLayer.FoodFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Engine
    {
        private const int snakeInitialLength = 4;
        private const int mazeBody = 1;
        private const int snakeBody = 3;
        private const int snakeHead = 2;
        private const int Food = 4;
        private const int step = 1;
        private const int snakeHitsMaze = 5;
        private int mazeLength { get; set; }
        private int mazeWidth { get; set; }
        private int[,] mazeArray { get; set; }
        private GameSound gameSound;
        private Maze gameMaze;

        private GameSnake gameSnake1;
        // For future use, 2 player game mode
        //private GameSnake gameSnake2;
        private Food food;
        private FoodGenerator foodGenerator;

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

        gameMode currentMode = gameMode.basic;

        public Engine(int length, int width, int mode)
        {
            mazeLength = length;
            mazeWidth = width;
            Score.resetScore();
            foodGenerator = new FoodGenerator();
        }

        public int[,] initializeGame()
        {

            switch (currentMode)
            {
                case gameMode.basic:


                    // Create a New Maze and initialize it
                    gameMaze = new Maze(mazeWidth, mazeLength);
                    mazeArray = gameMaze.CreateMaze();

                    // Add the Snake
                    gameSnake1 = new GameSnake();
                    //List<Point> snakeBody = new List<Point>();
                    List<Point> snakeCurrentBody = gameSnake1.createFirstSnake(mazeLength, mazeWidth, snakeInitialLength);

                    // Make the whole snake as body first
                    foreach (Point value in snakeCurrentBody)
                    {
                        mazeArray[value.returnX(), value.returnY()] = (int)Elements.snakeBody;
                    }
                    // Identify snake head
                    Point head = snakeCurrentBody[0];
                    mazeArray[head.returnX(), head.returnY()] = (int)Elements.snakeHead;

                    // Add the Food
                    bool isValid = true;
                    do
                    {
                        food = foodGenerator.generateFood(mazeLength, mazeWidth);
                        isValid = validateNewFoodLocation(food);
                    } while (!isValid);
                    mazeArray[food.xLocation, food.yLocation] = Food;
                    break;

                default:
                    throw new System.Exception("Invalid Game Mode!");
            }

            return mazeArray;
        }

        public int[,] updateGame(Direction snakeDirection)
        {
            if (snakeDirection == Direction.Unchanged)
            {
                snakeDirection = gameSnake1.directionFacing;
            }

            Point newSnakeHead = getNewHead(snakeDirection);
            List<Point> snakesNewLocation;

            switch (mazeArray[newSnakeHead.returnX(), newSnakeHead.returnY()])
            {

                case (int)Elements.mazeBody:
                    gameSound.SnakeDiesSound();
                    if (Score.getScore() > Score.getHighScore())
                    {
                        gameSound.SnakeGetsHighScore();
                        Score.setHighScore(Score.getScore());
                    }
                    mazeArray[0, 0] = snakeHitsMaze;
                    return mazeArray;


                case Food:  // snake hits the food
                    snakesNewLocation = gameSnake1.snakeMove(snakeDirection, true);
                    mazeArray = gameMaze.CreateMaze();
                    gameSound.SnakeEatsSound();
                    foreach (Point value in snakesNewLocation)
                    {
                        mazeArray[value.returnX(), value.returnY()] = snakeBody;
                    }
                    // Identify snake head
                    Point head = snakesNewLocation[0];
                    mazeArray[head.returnX(), head.returnY()] = snakeHead;

                    if ((newSnakeHead.returnX() == food.xLocation) && (newSnakeHead.returnY() == food.yLocation))
                    {
                        Score.incrementScore(food.pointsWorth);

                    }

                    food = null;
                    bool isValid = true;
                    do
                    {
                        food = foodGenerator.generateFood(mazeLength, mazeWidth);
                        isValid = validateNewFoodLocation(food);
                    } while (!isValid);

                    mazeArray[food.xLocation, food.yLocation] = Food;
                    break;

                default:   // snake moves
                    List<Point> SnakeCurrentPosition = gameSnake1.returnCurrentSnakePosition();
                    mazeArray[SnakeCurrentPosition.Last().returnX(), SnakeCurrentPosition.Last().returnY()] = (int)Elements.blank;
                    mazeArray[SnakeCurrentPosition.First().returnX(), SnakeCurrentPosition.First().returnY()] = (int)Elements.snakeBody;
                    snakesNewLocation = gameSnake1.snakeMove(snakeDirection, false);
                    mazeArray[snakesNewLocation.First().returnX(), snakesNewLocation.First().returnY()] = (int)Elements.snakeHead;

                    mazeArray[food.xLocation, food.yLocation] = Food;
                    break;
            }       
            return mazeArray;
        }

        private Point getNewHead(Direction snakeDirection)
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

                case Direction.Right:
                    newSnakeHead = new Point(x, y + step);
                    break;

                case Direction.Left:
                    newSnakeHead = new Point(x, y - step);
                    break;

                case Direction.Up:
                    newSnakeHead = new Point(x - step, y);
                    break;

                case Direction.Down:
                    newSnakeHead = new Point(x + step, y);
                    break;

                default:
                    throw new System.Exception("Invalid direction.");
            }
            return newSnakeHead;
        }
        public bool validateNewFoodLocation(Food newFood)
        {
            int x = newFood.xLocation;
            int y = newFood.yLocation;

            if ((x >= mazeLength) || (y >= mazeWidth))
            {
                return false;
            }
            if (mazeArray[x, y] == (int)Elements.mazeBody)
            {
                return false;
            }
            if (mazeArray[x, y] == (int)Elements.snakeBody)
            {
                return false;
            }
            if (mazeArray[x, y] == (int)Elements.snakeHead)
            {
                return false;
            }
            return true;
        }
    }
}