using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class Engine_Test
    {
        private const int FOOD = 4;
        private const int SNAKEBODY = 3;
        private const int SNAKEHEAD = 2;
     
        [TestMethod]
        public void initializeGameTestBorder()
        {
            //note: checks only for borders. Uses default border as of the moment.
            // Since food is randomly generated. It is not checked. Snake is not yet checked 
            // because location is not yet finalized.

            const int width = 20;
            const int height = 40;
            int[,] expectedResult = createMaze(width, height);

            BusinessLayer.Engine engine = new BusinessLayer.Engine(width, height, 1);
            int[,] resultingMaze = engine.initializeGame();

            bool result = validateMaze(resultingMaze, expectedResult, width, height);
            Assert.IsTrue(result, "Valid maze generated");
        }

        public bool validateMaze(int[,] resultingMaze, int[,] expectedResult, int width, int height)
        {
            bool result = true;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if ((resultingMaze[x, y] != FOOD) && (resultingMaze[x, y] != SNAKEBODY) && (resultingMaze[x, y] != SNAKEHEAD))
                    {
                        if (resultingMaze[x, y] != expectedResult[x, y])
                        {
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

        private int[,] createMaze(int width, int height)
        {
            int[,] maze = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    maze[x, y] = 0;
                }
            }

            for (int y = 0; y < height; y++)
            {
                maze[0, y] = 1;
                maze[width - 1, y] = 1;
            }
            for (int x = 0; x < width; x++)
            {
                maze[x, 0] = 1;
                maze[x, height -1] = 1;
            }

            return maze;
        }
    }
}
