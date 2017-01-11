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
        private FileStream fileReader = new FileStream("highscore.txt", FileMode.OpenOrCreate, FileAccess.Read);
        private FileStream fileWriter = new FileStream("highscore.txt", FileMode.Open, FileAccess.Write);

        public int getScore()
        {
            return currentScore;
        }

        public void incrementScore(int increment)
        {
            currentScore += increment;
        }

        public void gameEndOperations()
        {


        }
    }
}
