using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace Snake
{
    class Score
    {
        private int currentScore;
        Database db = new Database();
       
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
            return db.getHighSCore();
        }

        public void setHighScore(int highScore)
        {
            db.setHighScore(highScore);
        }
    }
}
