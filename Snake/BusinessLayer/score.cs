using DatabaseLayer;
using System.Collections.Generic;
using System;

namespace BusinessLayer
{
    public class Score
    {
        private static int currentScore;
        private const int NEWSCORE = 0;
        static Database db;
        string gameType;

        public Score(string gameType)
        {
            currentScore = NEWSCORE;
            this.gameType = gameType;
            db = new Database(gameType);
            currentScore = NEWSCORE;
        }
       
        public int getScore()
        {
            return currentScore;
        }

        public void incrementScore(int increment)
        {
            currentScore += increment;
        }


        public List<HighScore> getHighScore()
        {
            return db.getHighSCore();
        }

        public void setHighScore(int highScore)
        {
            if (db.setHighScore(highScore) == false)
            {
                throw new System.Exception("Database fail");
            }
        }

        internal void handleHighScore()
        {
            List<HighScore> highScoreList = new List<HighScore>();
            highScoreList = getHighScore();

            // Check if current score is larger than smallest score in list
            // If so, replace it and write to DB

            throw new Exception("Not fully implemented");
        }
    }
}