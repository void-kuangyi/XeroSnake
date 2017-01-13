using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Engine
    {
        private const int SNAKEINITIALLENGTH = 4;
        private const int MAZEBODY = 1;
        private const int SNAKEBODY = 3;
        private const int SNAKEHEAD = 2;
        private const int FOOD = 4;
        private int mazeLength { get; set; }
        private int mazeWidth { get; set; }
        private int[,] mazeArray { get; set; }

        private maze gameMaze;

        private GameSnake gameSnake1;
        private GameSnake gameSnake2;
        private List<Food> foodList;


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
                    // Create a New Maze and initialize it
                    gameMaze = new maze(mazeLength, mazeWidth);
                    mazeArray = gameMaze.CreateMaze();

                    // Add the Snake
                    gameSnake1 = new GameSnake();
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
                    Food newFood = new BusinessLayer.Food();
                    newFood.generateFood(mazeLength, mazeWidth);

                    bool isValid = true;
                    do
                    {
                        isValid = validateNewFoodLocation(newFood);
                    }while (!isValid);
                    foodList.Add(newFood);
                    mazeArray[newFood.getXLocation(), newFood.getyLocation()] = FOOD;
                    break;

                default :
                    // Invalid gameMode
                    break;
            }

            return mazeArray;
        }

        public bool validateNewFoodLocation(Food newFood)
        {
            if (mazeArray[newFood.getXLocation(), newFood.getyLocation()] == MAZEBODY)
            {
                return false;
            }
            if (mazeArray[newFood.getXLocation(), newFood.getyLocation()] == SNAKEBODY)
            {
                return false;
            }
            if (mazeArray[newFood.getXLocation(), newFood.getyLocation()] == SNAKEHEAD)
            {
                return false;
            }
            return true;
        }
    }
}
