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

        internal void handleHighScore(string currentName)
        {
            List<HighScore> highScoreList = new List<HighScore>();
            highScoreList = db.getHighSCore();

            highScoreList.Sort((a, b) => a.score.CompareTo(b.score));

            if (highScoreList.Count < 5 && currentScore != 0)
            {
                HighScore hs = new HighScore();
                hs.name = currentName;
                hs.score = currentScore;
                highScoreList.Add(hs);

                db.setHighScore(highScoreList);
            }
            else if (currentScore > highScoreList[0].score)
            {
                highScoreList[0].score = currentScore;
                highScoreList[0].name = currentName;

                db.setHighScore(highScoreList);
            }
        }

        internal List<string> getHighScoreList()
        {
            List<string> highScoreStringList = new List<string>();
            List<HighScore> highScoreList = new List<HighScore>();
            highScoreList = db.getHighSCore();

            highScoreList.Sort((a, b) => -1 * a.score.CompareTo(b.score)); // "-1 *" to sort in descending order

            foreach (HighScore highScore in highScoreList)
            {
                highScoreStringList.Add(highScore.name + "  " + highScore.score.ToString());
            }

            return highScoreStringList;
        }
    }
}