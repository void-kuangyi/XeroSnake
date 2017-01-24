using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class Laser_Test
    {
        [TestMethod]
        public void Move_Test_if_Laser_Moves_Down()
        {

            BusinessLayer.Laser testLaser = new BusinessLayer.Laser(2,2, BusinessLayer.Direction.Down);

            testLaser.Move();

            Assert.IsTrue(testLaser.returnX() == 3);
            Assert.IsTrue(testLaser.returnY() == 2);
        }

        [TestMethod]
        public void Move_Test_if_Laser_Moves_Up()
        {

            BusinessLayer.Laser testLaser = new BusinessLayer.Laser(2, 2, BusinessLayer.Direction.Up);

            testLaser.Move();

            Assert.IsTrue(testLaser.returnX() == 1);
            Assert.IsTrue(testLaser.returnY() == 2);
        }

        [TestMethod]
        public void Move_Test_if_Laser_Moves_Right()
        {

            BusinessLayer.Laser testLaser = new BusinessLayer.Laser(2, 2, BusinessLayer.Direction.Right);

            testLaser.Move();

            Assert.IsTrue(testLaser.returnX() == 2);
            Assert.IsTrue(testLaser.returnY() == 3);
        }

        [TestMethod]
        public void Move_Test_if_Laser_Moves_Left()
        {

            BusinessLayer.Laser testLaser = new BusinessLayer.Laser(2, 2, BusinessLayer.Direction.Left);

            testLaser.Move();

            Assert.IsTrue(testLaser.returnX() == 2);
            Assert.IsTrue(testLaser.returnY() == 1);
        }
    }


}
