using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace Snake
{
    class Program
    {
          static void Main(string[] args)
        {
            bool ExitGame = false;
            string UserExitRequest;
            

            do
            {
                //This 2D Array is only for reference to check the Draw method
                int[,] Maze = new int[5, 5] { { 1, 1, 1, 1, 1 }, { 1, 6, 6, 6, 1 }, { 1, 6, 3, 6, 1 }, { 1, 6, 6, 6, 1 }, { 1, 1, 1, 1, 1 } };

                //Draw method for creading a new instance of the maze and its contents
                Draw(Maze);


                UserExitRequest = Console.ReadLine().ToString();
                if (UserExitRequest == "Q" || UserExitRequest == "q")
                {
                    ExitGame = true;
                }
            }
            while (ExitGame == false);

        }

        public static void Draw(int[,] DynamicMaze)
        {
            int rowLength = DynamicMaze.GetLength(0);
            int colLength = DynamicMaze.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    switch (DynamicMaze[i, j])
                    {
                        case 1:
                            Console.Write("*"); //border horizontal 
                            break;
                        case 3:
                            Console.Write("0"); //snake head
                            break;
                        case 4:
                            Console.Write("o"); //snake body
                            break;
                        case 5:
                            Console.Write("@"); //food
                            break;
                        case 6:
                            Console.Write("-"); //snake body
                            break;
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}