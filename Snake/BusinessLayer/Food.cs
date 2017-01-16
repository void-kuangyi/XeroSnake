using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Food
    {
        public const int BUFFER = 1;
        private int yLocation;
        private int xLocation;
        public enum foodType
        {
            basic = 1
        }
        foodType type = foodType.basic;

        public Food()
        {
            xLocation = -1;
            yLocation = -1;
            type = foodType.basic;
        }

        public bool generateFood(int xBorder, int yBorder)
        {
            if (xBorder < 0 || yBorder < 0)
            {
                return false; // Negative number input
            }
            this.xLocation = randomGenerate(xBorder - 1);
            this.yLocation = randomGenerate(yBorder - 1);

            return true;
        }

        private int randomGenerate(int numberLimit)
        {
            Random randomNumber = new Random();
            return randomNumber.Next(numberLimit);
        }

        public int getFoodType()
        {
            return (int)type;
        }

        public int getXLocation()
        {
            return xLocation;
        }
        public int getyLocation()
        {
            return yLocation;
        }

        public void setXLocation(int newSetXLocation)
        {
            xLocation = newSetXLocation;
        }

        public void setYLocation(int newSetYLocation)
        {
            yLocation = newSetYLocation;
        }
    }
}