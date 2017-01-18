using System;
using BusinessLayer;

namespace Snake
{
    class Program
    {
        private const int GameStepMilliseconds = 100;

        private static bool ExitGame = false;
        private static string UserReplay;
        static int gameMode;
        static bool gameSelected = false;

        static void Main(string[] args)
        {
            initialMenuLoad();

            // Game engine = new game engine
            Engine gameEngine = new Engine(mode: gameMode);
            int[,] Maze = gameEngine.initializeGame();
            int[,] updateMaze = Maze;

            Draw(Maze);

            do
            {
                int score = Score.getScore();
                drawScore(score);

                KeyListner keyListner = new KeyListner(); 
                ConsoleKeyInfo keyInfo = keyListner.ReadKey(GameStepMilliseconds);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        updateMaze = gameEngine.updateGame(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        updateMaze = gameEngine.updateGame(Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        updateMaze = gameEngine.updateGame(Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        updateMaze = gameEngine.updateGame(Direction.Left);
                        break;
                    case ConsoleKey.Q:
                        ExitGame = true;
                        break;
                    default:
                        updateMaze = gameEngine.updateGame(Direction.Unchanged);
                        break;
                }

                if (updateMaze[0, 0] == 5)
                {
                    ExitGame = true;
                }
                System.Console.Clear();
                Draw(updateMaze);
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
            if (UserReplay.Equals("r", StringComparison.CurrentCultureIgnoreCase)) 
            {
                ExitGame = false;
                Console.Clear();
                Main(null);
            }
        }

        static void initialMenuLoad()
        {
            do
            {
                
                Style.menuImage();
                try
                {
                    gameMode = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine();
                }

                if (gameMode == 1)
                {
                    gameSelected = true;
                }
                Console.Clear();
            }
            while (gameSelected == false);
        }
    }
}