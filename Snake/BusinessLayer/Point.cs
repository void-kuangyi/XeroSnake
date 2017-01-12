using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    class Point
    {
        private int x;
        private int y;

        public Point (int newX, int newY, Boolean head)
        {
            this.x = newX;
            this.y = newY;
        }

        public int returnX()
        {
            return this.x;
        }

        public int returnY()
        {
            return this.y;
        }

        public void setX(int tempX)
        {
            this.x = tempX;
        }

        public void setY(int tempY)
        {
            this.y = tempY;
        }

    }
}
