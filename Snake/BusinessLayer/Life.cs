using System;

namespace BusinessLayer
{
    public class Life
    {
        private int lifeNumber;

        public Life()
        {
            lifeNumber = 3;
        }

        public int LoseLife()
        {
            lifeNumber--;
            return lifeNumber;

        }

        public bool IsDead()
        {
            return lifeNumber == 0;

        }



    }
}
