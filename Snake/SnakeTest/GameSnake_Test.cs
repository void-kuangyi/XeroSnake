using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SnakeTest
{
    [TestClass]
    class GameSnake_Test
    {
        [TestMethod]

        public void First_Snake_Created_at_Correct_Location()
        {
            //create new snake 
            BusinessLayer.GameSnake testSnake = new BusinessLayer.GameSnake();
            List<BusinessLayer.Point> testSnakeList;
            testSnakeList = testSnake.createFirstSnake(40, 40, 3);

            Assert.IsTrue(testSnakeList.Count() == 3);

        }



    }
}
