using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    public class Style
    {
        public void StyleMaze(int[,] maze)
        {
            System.Console.Clear();

            StringBuilder designedMaze = new StringBuilder();
            //string designedMaze = string.Empty;
            int rowLength = maze.GetLength(0);
            int coloumnLength = maze.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < coloumnLength; j++)
                {
                    designedMaze.Append(StyleMazeElement(maze[i, j]));
                }
                designedMaze.Append(Environment.NewLine);
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
                    return "\u058D";

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
            
