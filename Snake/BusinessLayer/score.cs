using DatabaseLayer;

namespace BusinessLayer
{
    public class Score
    {
        private static int currentScore;
        static Database db = new Database();

        public Score()
        {
            currentScore = 0;
        }
       
        public static int getScore()
        {
            return currentScore;
        }

        public static void incrementScore(int increment)
        {
            currentScore += increment;
        }

        public static int getHighScore()
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
