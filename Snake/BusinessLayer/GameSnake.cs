using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class GameSnake
    {
        private int currentDirection;  //direction the snake is facing
        private int length;
        private List<Point> currentPosition;

        //Method to create new snake
        public List<Point> createFirstSnake(int width, int height, int length)
        {
            
            //create head node (head of snake)
            Point head = new BusinessLayer.Point(width / 2, height / 2);
            List<Point> snakePoints = new List<Point>();

            //create rest of nodes (body of snake)

            int headX = head.returnX() - 1;
            for (int x = 0; x < length; x++)
            {
                Point temp = new BusinessLayer.Point(headX, head.returnY());
                headX--;
            }

            this.currentPosition = snakePoints;
            return snakePoints;
        }



    }
}
