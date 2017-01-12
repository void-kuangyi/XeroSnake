using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class Food_Test
    {
        [TestMethod]
        public void generateFoodTestOutsideBoundaryXAxis()
        {
            BusinessLayer.Food food = new BusinessLayer.Food();

            bool result = food.generateFood(-1, 40);

            Assert.IsFalse(result, "Accepted Invalid X input");

        }

        [TestMethod]
        public void generateFoodTestOutsideBoundaryYAxis()
        {
            BusinessLayer.Food food = new BusinessLayer.Food();

            bool result = food.generateFood(26, -3);


            Assert.IsFalse(result, "Accepted Invalid X input");

        }

        [TestMethod]
        public void generateFoodTestInsideBoundaryYAxis()
        {
            BusinessLayer.Food food = new BusinessLayer.Food();

            bool result = food.generateFood(26, 22);

            Assert.IsTrue(result, "Wrong Return");

        }
    }
}
