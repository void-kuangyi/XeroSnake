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
        private int mazeLength { get; set; }
        private int mazeWidth { get; set; }
        private int[,] mazeArray { get; set; }
        private Score gameScore;

        private maze gameMaze;

        private GameSnake gameSnake1; 
        private GameSnake gameSnake2;
        private List<Food> foodList = new List<Food>();


        private enum gameMode
        {
            basic,
        }
        gameMode currentMode = gameMode.basic;


        public Engine(int length, int width, int mode)
        {
            mazeLength = length;
            mazeWidth = width; 
        }

        public int[,] initializeGame()
        {

            switch(currentMode)
            {
                case gameMode.basic:

                    gameScore = new Score();
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

                    foreach(Food value in foodList)
                    {
                        value.generateFood(mazeLength, mazeWidth);
                        bool isValid = true;
                        do
                        {
                            isValid = validateNewFoodLocation(value);
                        } while (!isValid);
                        mazeArray[value.getXLocation(), value.getyLocation()] = FOOD;
                    }

                    break;

                default :
                    // Invalid gameMode
                    break;
            }

            return mazeArray;
        }

        public bool validateNewFoodLocation(Food newFood)
        {
            int x = newFood.getXLocation();
            int y = newFood.getyLocation();

            if ((x >= mazeLength) || (y >= mazeWidth))
            {
                return false;
            }
            if (mazeArray[x,y] == MAZEBODY)
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
