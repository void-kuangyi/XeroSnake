using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeTest
{
    [TestClass]
    public class Maze_Test
    {
        [TestMethod]
        public void IsTure_return_a_instance_of_type_of_2D_array_from_CreateMaze_function()
        {
            const int width = 10;
            const int height = 10;
            BusinessLayer.Maze maze = new BusinessLayer.Maze(width, height
                ,1);
            Elements[,] newMaze = maze.CreateMaze();

            Assert.IsInstanceOfType(newMaze, typeof(int[,]), "this is an instance of type int 2D array");


        }

        [TestMethod]

        public void Istrue_return_a_maze_with_border_from_CreateMaze_function()
        {
            const int width = 10;
            const int height = 10;

            BusinessLayer.Maze maze = new BusinessLayer.Maze(width, height,1);

            Elements[,] newMaze = maze.CreateMaze();

            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Assert.AreEqual(newMaze[i, j], Elements.mazeBody);
                    }
                }
                else
                {
                    Assert.AreEqual(newMaze[i, 0], Elements.mazeBody);
                    Assert.AreEqual(newMaze[i, width - 1], Elements.mazeBody);
                }

            }





        }

    }


}
