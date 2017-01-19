using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLayer
{
    public class AI
    {
        private Direction currentDirection;
        private int X;
        private int Y;
        Random randomNumber = new Random();
        public int XCoordinate
        {
            get
            {
                return X;
            }
            set
            {
                X = value;
            }
        }

        public int YCoordinate
        {
            get
            {
                return Y;
            } set
            {
                Y = value;
            }
        }

        public AI()
        {
            X = -1;
            Y = -1;
        }

        public bool SpawnAI(int XBorder, int YBorder)
        {
            if (XBorder < 0 || YBorder < 0)
            {
                return false;
            }
            this.X = randomNumber.Next(XBorder - 1);
            this.Y = randomNumber.Next(YBorder - 1);
           // currentDirection = Direction.Right;

            return true;
        }



        public void MoveAI()
        {

            bool Opposite = true;
            int rnd = 0;
            while (Opposite != false)
            {
               // Console.Write("I AM HERE");
                rnd = randomNumber.Next(0,4);
                if (rnd == 0 && currentDirection == Direction.Left)
                {
                    Opposite = true;
                    break;
                } else if (rnd == 1 && currentDirection == Direction.Right)
                {
                    Opposite = true;
                    break;
                }
                else if (rnd == 2 && currentDirection == Direction.Down)
                {
                    Opposite = true;
                    break;
                }
                else if (rnd == 3 && currentDirection == Direction.Up)
                {
                    Opposite = true;
                    break;
                }
                else
                {
                    Opposite = false;
                }

            }
           

            switch (rnd)
            {
                case (int)Direction.Right:
                    Y = Y + 1;
                    currentDirection = Direction.Right;
                    break;
                case (int)Direction.Left:
                    Y = Y - 1;
                    currentDirection = Direction.Left;
                    break;
                case (int)Direction.Up:
                    X = X - 1;
                    currentDirection = Direction.Up;
                    break;
                case (int)Direction.Down:
                    X = X + 1;
                    currentDirection = Direction.Down;
                    break;
            }
        }
    }
}
