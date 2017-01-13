using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GameSnake
    {
        enum Direction {right, down, left, up};
        Direction directionFacing;
        private int snakeLength;
        private List<Point> currentPosition;

        //Method to create new snake
        public List<Point> createFirstSnake(int width, int height, int newLength)
        {
            this.directionFacing = Direction.right;
            this.snakeLength = newLength;   
            //create head node (head of snake)
            Point head = new BusinessLayer.Point(width / 2, height / 2);
            List<Point> snakePoints = new List<Point>();

            //create rest of nodes (body of snake)

            int headX = head.returnX() - 1;
            for (int x = 0; x < snakeLength; x++)
            {
                Point temp = new BusinessLayer.Point(headX, head.returnY());
                headX--;
                snakePoints.Add(temp);
            }

            this.currentPosition = snakePoints;
            return snakePoints;
        }


        public List<Point> snakeMove(int direction, Boolean hasEaten)
        {
            //make new list equal to position to previous state of snake
            List<Point> snakeMoveList = currentPosition;
            Point snakeTurn = new Point(0, 0);
            //.directionFacing = direction;

            switch(direction)
            {
                 case (int)Direction.right:
                     snakeTurn.setX(snakeMoveList[0].returnX()+1);
                     snakeTurn.setY(snakeMoveList[0].returnY());
                     break;  
                 case (int)Direction.down:
                     snakeTurn.setX(snakeMoveList[0].returnX());
                     snakeTurn.setY(snakeMoveList[0].returnY()-1);
                     break;
                 case (int)Direction.left:
                     snakeTurn.setX(snakeMoveList[0].returnX()-1);
                     snakeTurn.setY(snakeMoveList[0].returnY());
                    break;
                 case (int)Direction.up:
                     snakeTurn.setX(snakeMoveList[0].returnX());
                     snakeTurn.setY(snakeMoveList[0].returnY()+1);
                     break;

            }

            if (hasEaten == true)
            {
                snakeMoveList.Insert(0, snakeTurn); //add new head with new direction to snake
            } else
            {
                snakeMoveList.Insert(0, snakeTurn); //add new head with new direction to snake
                snakeMoveList.RemoveAt(snakeMoveList.Count() - 1); //remove last element of snake
            }
  
            //update current position
            this.currentPosition = snakeMoveList;

            return snakeMoveList;
        }

     }
}

