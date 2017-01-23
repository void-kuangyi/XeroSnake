using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BusinessLayer;

namespace SnakeTest
{
    [TestClass]
    public class AI_Test
    {
        [TestMethod]
        public void SpawnAI_initialises_ai_at_3_3_when_random_returns_3()
        {
            Mock<Random> mockRandom = new Mock<Random>();

            mockRandom.Setup(r => r.Next(It.IsAny<int>())).Returns(3);

            BusinessLayer.AI testAI = new BusinessLayer.AI(mockRandom.Object);

            Assert.IsTrue(testAI.YCoordinate == -1);
            Assert.IsTrue(testAI.XCoordinate == -1);

            testAI.SpawnAI(6, 8);

            Assert.IsTrue(testAI.YCoordinate == 3);
            Assert.IsTrue(testAI.XCoordinate == 3);
        }

        [TestMethod]
        public void RandomPoint_generates_true()
        {
            Random random = new Random();
            BusinessLayer.AI testAI = new BusinessLayer.AI(random);
            Random randomNUmber = new Random();
            int rnd = randomNUmber.Next(4);
            Assert.IsTrue(rnd <= 4);
        }

        [TestMethod]

        public void SmartMove_moves_towards_snake()
        {
     
            Mock<Random> mockRandom = new Mock<Random>();
            mockRandom.Setup(r => r.Next(It.IsAny<int>())).Returns(0);

            BusinessLayer.AI testAI = new BusinessLayer.AI(mockRandom.Object);
            testAI.SpawnAI(3, 20);
            List<Point> snakePoints = new List<Point>();
            Point head = new Point(20, 20);
            snakePoints.Add(head);

            testAI.SmartMove(snakePoints);
            Assert.IsTrue(testAI.XCoordinate == 1);
            Assert.IsTrue(testAI.YCoordinate == 0);

        }

    }
}
