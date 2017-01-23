using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseLayer;
using BusinessLayer;
using System.IO;
using System.Collections.Generic;
using System;

namespace SnakeTest
{
    [TestClass]
    public class Database_Test
    {
        private const string testMazeLevel = "DBTest";
        [TestMethod]
        public void getHighSCore_Database_Will_Write_Score()
        {
            Database db = new Database(testMazeLevel);
            HighScore highSCore = new HighScore();
            highSCore.score = 10;
            highSCore.name = "Test_DB_Will_Write_Score";
            List<HighScore> highScoreList = new List<HighScore>();

            bool checkCompleted = db.setHighScore(highScoreList);

            Assert.IsTrue(checkCompleted, "Score not written");
        }

        [TestMethod]
        public void setHighSCore_Database_Will_Store_Score()
        {
            Database db = new Database(testMazeLevel);
            HighScore highSCore = new HighScore();
            highSCore.score = Int16.MaxValue;
            highSCore.name = "Test_DB_Will_Save_Score";
            List<HighScore> highScoreList = new List<HighScore>();
            highScoreList.Add(highSCore);
            db.setHighScore(highScoreList);

            highScoreList = db.getHighSCore();
            highScoreList.Sort((a, b) => -1 * a.score.CompareTo(b.score)); // Sort descending

            Assert.IsTrue(highScoreList[0].score == Int16.MaxValue, "Invalid Score");
        }

        [TestMethod]
        public void setHighSCore_Database_Will_Replace_Score()
        {
            Database db = new Database(MazeLevel.Hard.ToString());
            int sampleHighScore1 = Int16.MaxValue - 1;
            int sampleHighScore2 = Int16.MaxValue;
            HighScore highSCore1 = new HighScore();
            HighScore highSCore2 = new HighScore();
            highSCore1.name = "Test_DB_Will_Replace_Score_1";
            highSCore1.score = sampleHighScore1;
            highSCore2.name = "Test_DB_Will_Replace_Score_2";
            highSCore2.score = sampleHighScore2;
            List<HighScore> highScoreList = new List<HighScore>();
            highScoreList.Add(highSCore1);
            highScoreList.Add(highSCore2);
            db.setHighScore(highScoreList);

            highScoreList = db.getHighSCore();
            highScoreList.Sort((a, b) => -1 * a.score.CompareTo(b.score)); // Sort descending

            Assert.IsTrue(highScoreList[0].score == Int16.MaxValue, "Invalid Score");
        }
    }
}
