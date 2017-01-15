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
        
        static bool ExitGame = false;
        static string UserExitRequest;

        static void Main(string[] args)
        {
            // Game engine = new game engine
            Engine gameEngine = new Engine(20, 40, 1);
            int[,] Maze = gameEngine.initializeGame();
            // Pass scoreObj to game engine

            do
            {
                //This 2D Array is only for reference to check the Draw method
                //int[,] Maze = new int[5, 5] { { 1, 1, 1, 1, 1 }, { 1, 6, 6, 6, 1 }, { 1, 6, 3, 6, 1 }, { 1, 6, 6, 6, 1 }, { 1, 1, 1, 1, 1 } };
                //Belongs in a test file
                
                //Draw method for creading a new instance of the maze and its contents
                Draw(Maze);

                int score = Score.getScore(); // Get score from business layer
                drawScore(score); 

                UserExitRequest = Console.ReadLine().ToString();
                if (UserExitRequest == "Q" || UserExitRequest == "q")
                {
                    ExitGame = true;
                }

                System.Console.Clear();

                System.Threading.Thread.Sleep(500);
            }
            while (ExitGame == false);

            // GameSnake temp = new GameSnake(3);

            endGame();
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
                        case 0:
                            Console.Write(" "); //Empty cell
                            break;
                        case 1:
                            Console.Write("*"); //border horizontal 
                            break;
                        case 2:
                            Console.Write("0"); //snake head
                            break;
                        case 3:
                            Console.Write("o"); //snake body
                            break;
                        case 4:
                            Console.Write("@"); //food
                            break;
                        default:
                            Console.Write("Should not reach here. Unexpected error!"); //food
                            break;
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }

        public static void drawScore(int score)
        {
            System.Console.WriteLine("Score: " + score);
        }

        static void endGame()
        {
            System.Console.WriteLine("Your final score is " + Score.getScore());
            System.Console.WriteLine("The high score is " + Score.getHighScore());
            System.Console.WriteLine("Enter r to replay.");

            UserExitRequest = Console.ReadLine().ToString();
            if (UserExitRequest == "R" || UserExitRequest == "r")
            {
                // replay
            }
        } 
    }
}