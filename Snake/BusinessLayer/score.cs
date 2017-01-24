using DatabaseLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Score
    {
        private static int currentScore;
        private const int NEWSCORE = 0;
        static Database db;
        string mazeLevel;

        public Score(MazeLevel mazeLevel)
        {
            currentScore = NEWSCORE;
            this.mazeLevel = mazeLevel.ToString();
            db = new Database();
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
            highScoreList = db.GetHighScore(mazeLevel).OrderBy(hs => hs.score).ToList();

            if (highScoreList.Count < 5 && currentScore != 0)
            {
                HighScore hs = new HighScore();
                hs.name = currentName;
                hs.score = currentScore;
                highScoreList.Add(hs);

                db.SetHighScore(highScoreList, mazeLevel);
            }
            else if (currentScore > highScoreList[0].score)
            {
                highScoreList[0].score = currentScore;
                highScoreList[0].name = currentName;

                db.SetHighScore(highScoreList, mazeLevel);
            }
        }

        internal List<string> getHighScoreList()
        {
            List<string> highScoreStringList = new List<string>();
            List<HighScore> highScoreList = new List<HighScore>();
            highScoreList = db.GetHighScore(mazeLevel).OrderByDescending(hs => hs.score).ToList();
            
            foreach (HighScore highScore in highScoreList)
            {
                highScoreStringList.Add(highScore.name + "  " + highScore.score.ToString());
            }

            return highScoreStringList;
        }
    }
}