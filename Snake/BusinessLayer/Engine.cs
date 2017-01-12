using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Engine
    {
        private int mazeLength { get; set; }
        private int mazeWidth { get; set; }
        private int[][] mazeArray { get; }
        private enum gameMode
        {
            basic
        }
        gameMode currentMde = gameMode.basic;


        public Engine(int length, int width, int mode)
        {
            mazeLength = length;
            mazeWidth = width;
            initializeGame();
        }

        private int[][] initializeGame()
        {
            // new Maze
            // new Snake
            return mazeArray;
        }
    }
}
