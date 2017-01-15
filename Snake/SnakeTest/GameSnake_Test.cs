using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class GameSnake_Test
    {
        [TestMethod]

        public void First_Snake_Created_at_Correct_Location()
        {
            //create new snake 
            BusinessLayer.GameSnake testSnake = new BusinessLayer.GameSnake();
            List<BusinessLayer.Point> testSnakeList;
            testSnakeList = testSnake.createFirstSnake(40, 40, 3);


            //Assert.IsTrue(testSnakeList.);
            Assert.IsTrue(testSnakeList.Count()==3);
            // Assert.IsTrue(testSnakeList.in)
            Assert.IsTrue(testSnakeList.ElementAt(0).returnX() == 20);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnY() == 20);
        }


        [TestMethod]

        public void Snake_Moves_Right_Correctly()
        {
            //create new snake 
            BusinessLayer.GameSnake testSnake = new BusinessLayer.GameSnake();
            List<BusinessLayer.Point> testSnakeList;
            testSnakeList = testSnake.createFirstSnake(20, 40, 3);

            //tested moving right with having eaten food
            testSnakeList = testSnake.snakeMove(0, true);
            Assert.IsTrue(testSnakeList.Count() == 4);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnX() == 11);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnY() == 20);
            Assert.IsTrue(testSnakeList.ElementAt(1).returnX() == 10);
            Assert.IsTrue(testSnakeList.ElementAt(1).returnY() == 20);

        }

        [TestMethod]

        public void Snake_Moves_Down_Correctly()
        {
            //create new snake 
            BusinessLayer.GameSnake testSnake = new BusinessLayer.GameSnake();
            List<BusinessLayer.Point> testSnakeList;
            testSnakeList = testSnake.createFirstSnake(60, 40, 4);

            testSnakeList = testSnake.snakeMove(1, false);
            Assert.IsTrue(testSnakeList.Count() == 4);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnX() == 30);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnY() == 19);
            Assert.IsTrue(testSnakeList.ElementAt(3).returnX() == 28);
            Assert.IsTrue(testSnakeList.ElementAt(3).returnY() == 20);

        }

        [TestMethod]

        public void Snake_Moves_Up_Correctly()
        {
            //create new snake 
            BusinessLayer.GameSnake testSnake = new BusinessLayer.GameSnake();
            List<BusinessLayer.Point> testSnakeList;
            testSnakeList = testSnake.createFirstSnake(20, 20, 2);
            Assert.IsTrue(testSnakeList.Count() == 2);

            //tested moving up having eaten food
            testSnakeList = testSnake.snakeMove(3, true);
            Assert.IsTrue(testSnakeList.Count() == 3);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnX() == 10);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnY() == 11);

        }

        [TestMethod]
        public void Snake_Moves_Left_Correctly()
        {
            //create new snake 
            BusinessLayer.GameSnake testSnake = new BusinessLayer.GameSnake();
            List<BusinessLayer.Point> testSnakeList;
            testSnakeList = testSnake.createFirstSnake(15, 15, 5);
            Assert.IsTrue(testSnakeList.Count() == 5);

            //tested moving left without having eaten food
            testSnakeList = testSnake.snakeMove(2, false);
            Assert.IsTrue(testSnakeList.Count() == 5);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnX() == 6);
            Assert.IsTrue(testSnakeList.ElementAt(0).returnY() == 7);

        }


    }
}
