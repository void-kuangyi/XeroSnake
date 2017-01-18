using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Style
    {
        public void StyleMaze(int[,] maze)
        {
            System.Console.Clear();

            string designedMaze = "";
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    designedMaze += StyleMazeElement(maze[i,j]);
                }
                designedMaze += "\n";
            }
            Console.Write(designedMaze);

        }
        public string StyleMazeElement(int mazeElement)
        {
            
            switch (mazeElement)
            {
                case 0:
                    return " ";
                case 1:
                    return "█";

                case 2:
                    return "Ö";

                case 3:
                    return "▓";

                case 4:
                    return "☻";

                case 5:
                    return "ô";

                case 6:
                    return "G";

                default:
                    throw new System.Exception("Invalid Game Element Processed!");
            }
        }
    }
}
            
