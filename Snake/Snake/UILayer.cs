using System;
using BusinessLayer;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        private const int GameStepMilliseconds = 100;
        private static bool ExitGame = false;
        static bool gameSelected = false;

        private static KeyListner keyListner = new KeyListner();
        private static gameMode currentGameMode;

        static void Main(string[] args)
        {
            initialMenuLoad();
            currentGameMode = gameMode.basic;
            MazeLevel mazeMode = ChooseMazeMode();

            using (Engine gameEngine = new Engine(gameMode.basic, mazeMode))
            {
                Elements[,] Maze = gameEngine.initializeGame();

                Elements[,] updateMaze = Maze;

                Draw(Maze);

                do
                {
                    int score = gameEngine.getScore();
                    drawScore(score);

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

                    if (updateMaze[0, 0] == Elements.snakeDeath)
                    {
                        ExitGame = true;
                    }
                    Console.Clear();
                    Draw(updateMaze);
                }
                while (ExitGame == false);

                Console.Write("Please enter your name: ");
                string highScoreName = keyListner.ReadKey(Int32.MaxValue).KeyChar.ToString() + Console.ReadLine();

                gameEngine.setName(highScoreName);
                gameEngine.handleHighSCore();

                EndGame(gameEngine.getScore(), gameEngine.getHighScoreList());
            }
        }

        public static void Draw(Elements[,] DynamicMaze)
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

        static void EndGame(int score, List<string> highScoreList)
        {
            Console.WriteLine("Your final score is " + score);
            Console.WriteLine("High Scores:");

            foreach (string str in highScoreList)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Enter r to replay. q key to quit.");

            do
            {
                ConsoleKeyInfo keyInfo = keyListner.ReadKey(Int32.MaxValue);
                if (keyInfo.KeyChar.ToString().Equals("r", StringComparison.OrdinalIgnoreCase))
                {
                    ExitGame = false;
                    Console.Clear();
                    Main(null);
                }
                else if (keyInfo.KeyChar.ToString().Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    Environment.Exit(0);
                }
            } while (true);
        }

        static void initialMenuLoad()
        {
            Style.menuImage();
            do
            {               
                try
                {
                    currentGameMode = (gameMode)Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine();
                }

                if (currentGameMode == gameMode.basic)
                {
                    gameSelected = true;
                }
            }
            while (gameSelected == false);
        }

        public static MazeLevel ChooseMazeMode()
        {
            MazeLevel mazeMode;

            Console.WriteLine("1. Beginner Mode : Simple Maze");
            Console.WriteLine("2. Easy Mode : Line Maze");
            Console.WriteLine("3. Medium Mode : Cross Maze");
            Console.WriteLine("4. Hard Mode : Grid Maze");

            do
            {
                Console.WriteLine();
                Console.Write("Please enter 1,2,3 or 4 : ");
                
            }
            while (!Enum.TryParse(keyListner.ReadKey(Int32.MaxValue).KeyChar.ToString(), out mazeMode) || !Enum.IsDefined(typeof(MazeLevel),mazeMode));

            Console.Clear();
            return mazeMode;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
