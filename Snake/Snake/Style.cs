using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Style
    {
        public const String ANSI_RESET = "\u001B[0m";
        public const String ANSI_BLACK = "\u001B[30m";
        public const String ANSI_RED = "\u001B[31m";
        public const String ANSI_GREEN = "\u001B[32m";
        public const String ANSI_YELLOW = "\u001B[33m";
        public const String ANSI_BLUE = "\u001B[34m";
        public const String ANSI_PURPLE = "\u001B[35m";
        public const String ANSI_CYAN = "\u001B[36m";
        public const String ANSI_WHITE = "\u001B[37m";
        public void StyleMaze(int[,] maze)
        {
            System.Console.Clear();

            string row = "";
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    row += StyleMazeElement(maze[i,j]);
                }
                row += "\n";
                Console.Write(row);
                Console.Write(Environment.NewLine);
            }

            
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
                    return "■";

                case 5:
                    return "Game Over";

                default:
                    throw new System.Exception("Invalid Game Element Processed!");
            }
        }
        //public void StyleMaze(int mazeElement)
        //{
        //    string test = "☻o{ô¢";
        //    Console.BackgroundColor = ConsoleColor.Blue;
        //    for (int x = 0; x< 10;  x++)
        //    {
        //        if(x%2 == 0)
        //        {

        //            Console.BackgroundColor = ConsoleColor.Blue;
        //            test = ANSI_BLUE + test;
        //        }
        //        else
        //        {
        //            Console.BackgroundColor = ConsoleColor.Black;
        //            test = ANSI_GREEN + test;
        //        }

        //    }

        //    Console.Write(test);

        //    switch (mazeElement)
        //    {
        //        case 0:
        //            DrawBlank();
        //            break;
        //        case 1:
        //            DrawMazeCharacter();
        //            break;
        //        case 2:
        //            DrawSnakeHead();
        //            break;
        //        case 3:
        //            DrawSnakeBody();
        //            break;
        //        case 4:
        //            DrawFood();
        //            break;
        //        case 5:
        //            Console.Write("Game Over");
        //            break;
        //        default:
        //            throw new System.Exception("Invalid Game Element Processed!");
        //    }
        //}

    }
}
            
