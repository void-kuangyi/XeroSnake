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
        static string UserReplay;
        enum Direction { right, down, left, up };

        static void Main(string[] args)
        {

            // Game engine = new game engine
            Engine gameEngine = new Engine(20, 70, 1);
            int[,] Maze = gameEngine.initializeGame();
            int[,] UpdateMaze = Maze;

            Draw(Maze);

            do
            {
                int score = Score.getScore(); // Get score from business layer
                drawScore(score);


                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        UpdateMaze = gameEngine.updateGame(direction.up);
                        break;
                    case ConsoleKey.DownArrow:
                        UpdateMaze = gameEngine.updateGame(direction.down);
                        break;
                    case ConsoleKey.RightArrow:
                        UpdateMaze = gameEngine.updateGame(direction.right);
                        break;
                    case ConsoleKey.LeftArrow:
                        UpdateMaze = gameEngine.updateGame(direction.left);
                        break;
                    case ConsoleKey.Q:
                        ExitGame = true;
                        break;
                    default:
                        break;
                }

                System.Console.Clear();
                Draw(UpdateMaze);
                System.Threading.Thread.Sleep(1);
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
                            Console.Write("*"); //border  
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
                        case 5:
                            Console.Write("Game Over"); //food
                            break;
                        default:
                            Console.Write("Should not reach here. Unexpected error!"); //Error 
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

            UserReplay = Console.ReadLine().ToString();
            if (UserReplay == "R" || UserReplay == "r")
            {
                // todo: replay
            }
        }
    }
}