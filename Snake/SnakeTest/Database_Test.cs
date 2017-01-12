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
        public void Database_Will_Write_Score()
        {
            Database db = new Database();
            int sampleHighScore = 30;

            bool checkCompleted = db.setHighScore(sampleHighScore);

            Assert.IsTrue(checkCompleted, "Score not written");
        }

        [TestMethod]
        public void Database_Will_Store_Score()
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
    }
}
