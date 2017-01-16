using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GameSnake
    {
        public enum Direction {right, down, left, up};
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
            snakePoints.Add(head);

            //create rest of nodes (body of snake)

            int headX = head.returnX() - 1;
            for (int x = 0; x < snakeLength-1; x++)
            {
                Point temp = new BusinessLayer.Point(headX, head.returnY());
                snakePoints.Add(temp);

                headX--;
            }

            this.currentPosition = snakePoints;
            return snakePoints;
        }

        public Direction getDirectionFacing()
        {
            return directionFacing;
        }

        //right = 0, down = 1, left = 2, up = 3
        public List<Point> snakeMove(int direction, Boolean hasEaten)
        {
            //make new list equal to position to previous state of snake
            List<Point> snakeMoveList = currentPosition;
            Point snakeTurn = new Point(0, 0);
            
            
            switch(direction)
            {
                 case (int)Direction.right:
                     snakeTurn.setX(snakeMoveList[0].returnX()+1);
                     snakeTurn.setY(snakeMoveList[0].returnY());
                     this.directionFacing = Direction.right;
                     break;  
                 case (int)Direction.down:
                     snakeTurn.setX(snakeMoveList[0].returnX());
                     snakeTurn.setY(snakeMoveList[0].returnY()-1);
                     this.directionFacing = Direction.down;
                    break;
                 case (int)Direction.left:
                     snakeTurn.setX(snakeMoveList[0].returnX()-1);
                     snakeTurn.setY(snakeMoveList[0].returnY());
                     this.directionFacing = Direction.left;
                    break;
                 case (int)Direction.up:
                     snakeTurn.setX(snakeMoveList[0].returnX());
                     snakeTurn.setY(snakeMoveList[0].returnY()+1);
                     this.directionFacing = Direction.up;
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

        //return current snake position
        public List<Point> returnCurrentSnakePosition()
        {
            return this.currentPosition;
        }

     }
}
