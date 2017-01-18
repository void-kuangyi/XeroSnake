using BusinessLayer.FoodFolder;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class Food_Test
    {
        [TestMethod]
        public void generateFoodTypeIsDeterministic()
        {
            Food food;
            FoodGenerator foodGenerator = new FoodGenerator();

            food = foodGenerator.generateFood(1,1);

            Assert.IsTrue(food is BasicFood || food is AdvancedFood, "Food type not determined");
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException),
    "Invalid coordinates passed to generateFood function.")]
        public void generateFoodOutsideBoundaryThrowsException()
        {
            Food food;
            FoodGenerator foodGenerator = new FoodGenerator();
         
            food = foodGenerator.generateFood(-1, -1);
        }
    }
}
