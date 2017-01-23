using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SmartAI : AI
    {
        public void SmartMove(int verticalOrHorizontal, List<Point> snakePoints, int previousX, int previousY)
        {
            int middle = snakePoints.Count / 2;
            Point middlePoint = snakePoints.ElementAt(middle);

            int distanceFromX = middlePoint.returnX() - previousX;
            //  - means move up
            //  + means move down            
            int distanceFromY = middlePoint.returnY() - previousY;
            // - means move left
            //  + means move right

            if (verticalOrHorizontal == 0)
            {
                if(distanceFromX > 0)
                {
                    XCoordinate = XCoordinate + 1;
                }
                else
                {
                    XCoordinate = XCoordinate - 1;
                }
            }
            else
            {
                if (distanceFromY > 0)
                {
                    YCoordinate = YCoordinate + 1;
                }
                else
                {
                    YCoordinate = YCoordinate - 1;
                }
            }   
        }
    }
}
