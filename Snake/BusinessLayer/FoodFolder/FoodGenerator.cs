using System;

namespace BusinessLayer.FoodFolder
{
    class FoodGenerator
    {
        private const int NoOfFoodTypes = 2;

        Random randomNumber = new Random();

        public Food generateFood(int xBorder, int yBorder)
        {
            Food food;

            generateFoodLocation(ref xBorder, ref yBorder);
            int foodID = randomNumber.Next(1, NoOfFoodTypes + 1);

            switch (foodID)
            {
                case 1:
                    food = new BasicFood();
                    break;
                case 2:
                    food = new AdvancedFood();
                    break;
                default:
                    throw new SystemException("Invalid food type in generateFood");
            }

            food.xLocation = xBorder;
            food.yLocation = yBorder;

            return food;
        }

        private void generateFoodLocation(ref int xBorder, ref int yBorder)
        {
            if (xBorder < 0 || yBorder < 0)
            {
                throw new SystemException("Invalid coordinates passed to generateFood function.");
            }
            xBorder = randomGenerate(xBorder - 1);
            yBorder = randomGenerate(yBorder - 1);
        }

        private int randomGenerate(int numberLimit)
        {
            return randomNumber.Next(numberLimit);
        }

    }
}
