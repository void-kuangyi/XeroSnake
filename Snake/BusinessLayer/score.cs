using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Score
    {
        private int currentScore;
       
        public int getScore()
        {
            return currentScore;
        }

        public void incrementScore(int increment)
        {
            currentScore += increment;
        }

        public int getHighScore()
        {

        }

        public void setHighScore(int highScore)
        {

        }
    }
}
