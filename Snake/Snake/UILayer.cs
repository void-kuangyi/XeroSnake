using System;
using BusinessLayer;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        private const int GameStepMilliseconds = 100;

        private static bool ExitGame = false;
        private static string UserReplay;
        static int gameMode;
        static bool gameSelected = false;

        enum mazeLevel{ easy = 1, medium, hard}

        static void Main(string[] args)
        {
            initialMenuLoad();

            int mazeMode = ChooseMazeMode();

            // Game engine = new game engine
            Engine gameEngine = new Engine(gameMode,mazeMode);
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
                if (row.Contains(" "))
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
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
            if (UserReplay.Equals("r", StringComparison.OrdinalIgnoreCase))
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
            }
            while (gameSelected == false);
        }




        public static int ChooseMazeMode()
        {
            int mazeMode;
            int inputValue;

            Console.WriteLine("1. Easy Mode : Line Maze");
            Console.WriteLine("2. Medium Mode : Cross Maze");
            Console.WriteLine("3. Hard Mode : Grid Maze");



            do
            {
                Console.Write("Please enter 1,2 or 3 : ");
            }
            while (!(int.TryParse(Console.ReadLine(), out inputValue)) || ! (Enum.IsDefined(typeof(mazeLevel),inputValue)));


            mazeMode = inputValue;


            Console.Clear();
            return mazeMode;

        }
    }
}