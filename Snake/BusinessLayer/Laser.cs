using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Laser : Point
    {
        Direction currentDirection;

        public Laser(int newX, int newY, Direction direction) : base (newX, newY)
        {
            setX(newX);
            setY(newY);
            currentDirection = direction;
        }
        public void Move()
        {
            switch (currentDirection)
            {
                case Direction.Right:
                    setY(returnY() + 1);
                    break;
                case Direction.Left:
                    setY(returnY() - 1);
                    break;
                case Direction.Up:
                    setX(returnX() - 1);
                    break;
                case Direction.Down:
                    setX(returnX() + 1);
                    break;
            }
        }
    }
}
