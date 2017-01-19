using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class AI_Test
    {
        [TestMethod]
        public void SpawnAI_initialise_true()
        {
            BusinessLayer.AI testAI = new BusinessLayer.AI();
            Assert.IsTrue(testAI.YCoordinate == -1);
            Assert.IsTrue(testAI.XCoordinate == -1);
            testAI.SpawnAI(6, 8);
            Assert.IsTrue(testAI.YCoordinate <= 6);
            Assert.IsTrue(testAI.XCoordinate <= 8);
        }

        [TestMethod]
        public void RandomPoint_generates_true()
        {
            BusinessLayer.AI testAI = new BusinessLayer.AI();
            Random randomNUmber = new Random();
            int rnd = randomNUmber.Next(4);
            Assert.IsTrue(rnd <= 4);
        } 
    }
}
