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
            int initialisedScore;

            //score = new Score();
            initialisedScore = Score.getScore();

            Assert.IsTrue(initialisedScore == 0, "Score not initialised to zero at the start");
        }

        [TestMethod]
        public void incrementScore_Increments_The_Score()
        {
            int incrementValue1 = 30;
            int incrementValue2 = 30;
            int incrementedScore;
            
            Score.incrementScore(incrementValue1);
            Score.incrementScore(incrementValue2);
            incrementedScore = Score.getScore();

            Assert.IsTrue(incrementedScore == (incrementValue1 + incrementValue2), "Error in incrementing score");
        }
    }
}
