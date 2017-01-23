using DatabaseLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Score
    {
        private static int currentScore;
        private const int NEWSCORE = 0;
        static Database db;
        string gameType;

        public Score()
        {
            currentScore = NEWSCORE;
            db = new Database(gameType);
        }
       
        public static int getScore()
        {
            return currentScore;
        }

        public static void incrementScore(int increment)
        {
            currentScore += increment;
        }

        public static void resetScore()
        {
            currentScore = NEWSCORE;
        }

        public static List<HighScore> getHighScore()
        {
            return db.getHighSCore();
        }

        public static void setHighScore(int highScore)
        {
            if (db.setHighScore(highScore) == false)
            {
                throw new System.Exception("Database fail");
            }
        }
    }
}