using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLayer
{
    class AI
    {
        private int X;
        private int Y;
        public int XCoordinate
        {
            get
            {
                return X;
            }
        }

        public int YCoordinate
        {
            get
            {
                return Y;
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
            this.X = RandomPoint(XBorder - 1);
            this.Y = RandomPoint(YBorder - 1);

            return true;
        }

        public int RandomPoint(int limit)
        {
            Random randomNumber = new Random();
            return randomNumber.Next(limit);
        }

        public void MoveAI()
        {
            Random rnd = new Random();
            int randomMove = rnd.Next(3);

            switch (randomMove)
            {
                case (int)Direction.Right:
                    Y = Y - 1;
                    break;
                case (int)Direction.Left:
                    Y = Y + 1;
                    break;
                case (int)Direction.Up:
                    X = X + 1;
                    break;
                case (int)Direction.Down:
                    X = X - 1;
                    break;
            }
        }
    }
}
