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
        private const int step = 1;

        private const int mazeRenderWidth = 70;
        private const int mazeRenderLength = 20;
        private int mazeLength { get; set; }
        private int mazeWidth { get; set; }
        private Elements [,] mazeArray { get; set; }
        private GameSound gameSound;
        private Maze gameMaze;
        private int mazeMode;

        private GameSnake gameSnake1;
        // For future use, 2 player game mode
        //private GameSnake gameSnake2;
        private Food food;
        private FoodGenerator foodGenerator;
        private gameMode currentGameMode;
        public Engine(gameMode mode,int mazeMode, int length = mazeRenderLength, int width = mazeRenderWidth)
        {
            mazeLength = length;
            mazeWidth = width;
            currentGameMode = mode;
            this.mazeMode = mazeMode;
            Score.resetScore();
            foodGenerator = new FoodGenerator();
        }

        public Elements[,] initializeGame()
        {

            switch (currentGameMode)
            {
                case gameMode.basic:

                    gameMaze = new Maze(mazeWidth, mazeLength,mazeMode );
                    mazeArray = gameMaze.CreateMaze();
                    gameSound = new GameSound();
                    gameSnake1 = new GameSnake();

                    List<Point> snakeCurrentBody = gameSnake1.createFirstSnake(mazeLength, mazeWidth, snakeInitialLength);
                    AddSnakeToTheMaze(snakeCurrentBody);
                    AddFoodToTheMaze();
                    break;

                default:
                    throw new System.Exception("Invalid Game Mode!");
            }

            return mazeArray;
        }

        public Elements [,] updateGame(Direction snakeDirection)
        {
            if (snakeDirection == Direction.Unchanged)
            {
                snakeDirection = gameSnake1.directionFacing;
            }

            Point newSnakeHead = getNewHead(snakeDirection);
            List<Point> snakesNewLocation;

            switch (mazeArray[newSnakeHead.returnX(), newSnakeHead.returnY()])
            {

                case Elements.mazeBody:
                    gameSound.SnakeDiesSound();
                    if (Score.getScore() > Score.getHighScore())
                    {
                        gameSound.SnakeGetsHighScore();
                        Score.setHighScore(Score.getScore());
                    }
                    mazeArray[0, 0] = Elements.snakeDeath;
                    return mazeArray;


                case Elements.foodBasic:
                case Elements.foodAdvanced:
                    snakesNewLocation = gameSnake1.snakeMove(snakeDirection, true);
                    
                    gameSound.SnakeEatsSound();
                    AddSnakeToTheMaze(snakesNewLocation);

                    if ((newSnakeHead.returnX() == food.xLocation) && (newSnakeHead.returnY() == food.yLocation))
                    {
                        Score.incrementScore(food.pointsWorth);
                    }

                    food = null;
                    AddFoodToTheMaze();
                    break;

                default:   // snake moves
                    List<Point> SnakeCurrentPosition = gameSnake1.returnCurrentSnakePosition();
                    mazeArray[SnakeCurrentPosition.Last().returnX(), SnakeCurrentPosition.Last().returnY()] = Elements.blank;
                    mazeArray[SnakeCurrentPosition.First().returnX(), SnakeCurrentPosition.First().returnY()] = Elements.snakeBody;
                    snakesNewLocation = gameSnake1.snakeMove(snakeDirection, false);
                    mazeArray[snakesNewLocation.First().returnX(), snakesNewLocation.First().returnY()] = Elements.snakeHead;

                    break;
            }       
            return mazeArray;
        }

        private void AddFoodToTheMaze()
        {
            bool isValid = true;
            do
            {
                food = foodGenerator.generateFood(mazeLength, mazeWidth);
                isValid = validateNewFoodLocation(food);
            } while (!isValid);
            if(food is BasicFood)
            {
                mazeArray[food.xLocation, food.yLocation] = Elements.foodBasic;
            }
            else
            {
                mazeArray[food.xLocation, food.yLocation] = Elements.foodAdvanced;
            }
                
        }

        private void AddSnakeToTheMaze(List<Point> snakesNewLocation)
        {
            foreach (Point value in snakesNewLocation)
            {
                mazeArray[value.returnX(), value.returnY()] = Elements.snakeBody;
            }
            // Identify snake head
            Point head = snakesNewLocation[0];
            mazeArray[head.returnX(), head.returnY()] = Elements.snakeHead;
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
            if (mazeArray[x, y] == Elements.mazeBody)
            {
                return false;
            }
            if (mazeArray[x, y] == Elements.snakeBody)
            {
                return false;
            }
            if (mazeArray[x, y] == Elements.snakeHead)
            {
                return false;
            }
            return true;
        }
    }
}