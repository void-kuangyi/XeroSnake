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


            const int width = 70;
            const int height = 20;
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
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if((x == 0) || (y == 0) || (x == height - 1) || (y == width - 1))
                    { 
                        if (resultingMaze[x, y] != expectedResult[x, y])
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }

        private Elements[,] createMaze(int width, int height)
        {
            Elements[,] maze = new Elements[height,width];
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    maze[x, y] = Elements.blank;
                }
            }

            for (int y = 0; y < width; y++)
            {
                maze[0, y] = Elements.mazeBody;
                maze[height - 1, y] = Elements.mazeBody;
            }
            for (int x = 0; x < height; x++)
            {
                maze[x, 0] = Elements.mazeBody;
                maze[x, width -1] = Elements.mazeBody;
            }

            return maze;
        }
    }
}