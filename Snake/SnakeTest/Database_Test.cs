using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseLayer;
using System.IO;

namespace SnakeTest
{
    [TestClass]
    public class Database_Test
    {
        [TestMethod]
        public void getHighSCore_Database_Will_Write_Score()
        {
            Database db = new Database();
            int sampleHighScore = 30;

            bool checkCompleted = db.setHighScore(sampleHighScore);

            Assert.IsTrue(checkCompleted, "Score not written");
        }

        [TestMethod]
        public void setHighSCore_Database_Will_Store_Score()
        {
            Database db = new Database();
            int highScore;
            int sampleHighScore = 30;
            db.setHighScore(sampleHighScore);

            using (BinaryReader reader = new BinaryReader(File.Open("highscores.txt", FileMode.Open)))
            {
                highScore = reader.ReadInt32();
            }

            Assert.IsTrue(highScore == 30, "Invalid Score");
        }

        [TestMethod]
        public void setHighSCore_Database_Will_Replace_Score()
        {
            Database db = new Database();
            int highScore;
            int sampleHighScore1 = 30;
            int sampleHighScore2 = 50;
            db.setHighScore(sampleHighScore1);
            db.setHighScore(sampleHighScore2);

            using (BinaryReader reader = new BinaryReader(File.Open("highscores.txt", FileMode.Open)))
            {
                highScore = reader.ReadInt32();
            }

            Assert.IsTrue(highScore == 50, "Invalid Score");
        }
    }
}
