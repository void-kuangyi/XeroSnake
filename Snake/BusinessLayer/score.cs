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
            highScoreList = db.getHighSCore();

            // Check if current score is larger than smallest score in list
            // If so, replace it and write to DB

            throw new Exception("Not fully implemented");
        }

        internal List<string> getHighScoreList()
        {
            List<string> highScoreStringList = new List<string>();
            List<HighScore> highScoreList = new List<HighScore>();
            highScoreList = db.getHighSCore();

            highScoreList.Sort((a, b) => a.score.CompareTo(b.score));

            foreach (HighScore highScore in highScoreList)
            {
                highScoreStringList.Add(highScore.name + "  " + highScore.score.ToString());
            }

            return highScoreStringList;
        }
    }
}