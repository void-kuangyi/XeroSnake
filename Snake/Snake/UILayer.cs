using System;
using BusinessLayer;

namespace Snake
{
    class Program
    {
        private const int GameStepMilliseconds = 100;

        private static bool ExitGame = false;
        private static string UserReplay;

        static void Main(string[] args)
        {
            int score;
            Engine gameEngine = new Engine(20, 70, 1);
            int[,] Maze = gameEngine.initializeGame();
            int[,] UpdateMaze = Maze;

            Draw(Maze);

            do
            {
                score = Score.getScore();
                drawScore(score);

                KeyListner keyListner = new KeyListner(); 
                ConsoleKeyInfo keyInfo = keyListner.ReadKey(GameStepMilliseconds);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        UpdateMaze = gameEngine.updateGame(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        UpdateMaze = gameEngine.updateGame(Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        UpdateMaze = gameEngine.updateGame(Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        UpdateMaze = gameEngine.updateGame(Direction.Left);
                        break;
                    case ConsoleKey.Q:
                        ExitGame = true;
                        break;
                    default:
                        UpdateMaze = gameEngine.updateGame(Direction.Unchanged);
                        break;
                }

                if (UpdateMaze[0, 0] == 5)
                {
                    ExitGame = true;
                }
                System.Console.Clear();
                Draw(UpdateMaze);
                System.Threading.Thread.Sleep(1);
            }
            while (ExitGame == false);

            endGame();
        }

        public static void Draw(int[,] DynamicMaze)
        {
            int rowLength = DynamicMaze.GetLength(0);
            int colLength = DynamicMaze.GetLength(1);
            Style style = new Style();
            for (int i = 0; i < rowLength; i++)
            {
                string row = "";
                for (int j = 0; j < colLength; j++)
                {
                    row += style.StyleMazeElement(DynamicMaze[i, j]);
                       
                }
                Console.Write(row);
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
                ExitGame = false;
                Console.Clear();
                Main(null);
            }
        }
    }
}