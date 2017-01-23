using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;

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
            Elements[,] expectedResult = createMaze(width, height);
            bool result;

            using (Engine engine = new Engine(gameMode.basic, MazeLevel.Easy, width, height))
            {
                
                Elements[,] resultingMaze = engine.initializeGame();

                result = validateMazeBorder(resultingMaze, expectedResult, width, height);

            }

            Assert.IsTrue(result, "Valid maze generated");
        }

        public bool validateMazeBorder(Elements[,] resultingMaze, Elements[,] expectedResult, int width, int height)
        {
            bool result = true;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if((x == 0) || (y == 0) || (x == (width -1)) || (x == (height - 1)))
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

        private Elements[,] createMaze(int width, int height)
        {
            Elements[,] maze = new Elements[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    maze[x, y] = Elements.blank;
                }
            }

            for (int y = 0; y < height; y++)
            {
                maze[0, y] = Elements.mazeBody;
                maze[width - 1, y] = Elements.mazeBody;
            }
            for (int x = 0; x < width; x++)
            {
                maze[x, 0] = Elements.mazeBody;
                maze[x, height -1] = Elements.mazeBody;
            }

            return maze;
        }
    }
}