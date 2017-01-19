using System;

namespace BusinessLayer
{
    public class Live
    {
        private int liveNumber;

        public Live()
        {
            liveNumber = 3;
        }

        public int LoseLive()
        {
            liveNumber--;
            return liveNumber;

        }

        public bool IsDead()
        {
            return liveNumber == 0;

        }



    }
}
