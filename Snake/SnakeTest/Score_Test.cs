using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class Score_Test
    {
        [TestMethod]
        public void Constructor_Score_Initialised_To_Zero()
        {
            BusinessLayer.Score score;
            int initialisedScore;

            score = new Score();
            initialisedScore = score.getScore();

            Assert.IsTrue(initialisedScore == 0, "Score not initialised to zero at the start");
        }

        [TestMethod]
        public void incrementScore_Increments_The_Score()
        {
            BusinessLayer.Score score = new Score();
            int incrementValue = 30;
            int incrementedScore;

            score.incrementScore(incrementValue);
            incrementedScore = score.getScore();

            Assert.IsTrue(incrementedScore == incrementValue, "Error in incrementing score");
        }
    }
}
