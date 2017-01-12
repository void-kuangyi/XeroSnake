using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    class GameSnake
    {
        private int currentDirection;  //direction the snake is facing


        //Contructor
        public GameSnake(int newLength)
        {
            this.length = newLength;
        }
        
        //Method to create new snake
        public List<Point> createFirstSnake(int width, int height, int length)
        {
            
            //create head node (head of snake)
            Point head = new BuisnessLayer.Point(width / 2, height / 2, true);
            List<Point> snakePoints = new List<Point>();

            //create rest of nodes (body of snake)

            int headX = head.returnX() - 1;
            for (int x = 0; x < length; x++)
            {
                Point temp = new BuisnessLayer.Point(headX, head.returnY(), false);
                headX--;
            }

            return snakePoints;
        }

    }
}
