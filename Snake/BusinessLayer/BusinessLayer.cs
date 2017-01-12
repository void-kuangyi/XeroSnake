using DatabaseLayer;

namespace BusinessLayer
{
    class maze
    {
        public static int[,] CreateMaze(int w, int h)
        {
            int width, height;
            width = w;
            height = h;

            int[,] maze = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i, j] = 0;
                }

            }
            for (int i = 0; i < width; i++)
            {
                if (i == 0 || i == width - 1)
                {
                    for (int j = 0; j < height; j++)
                    {
                        maze[i, j] = 1;
                    }
                }
                else
                {
                    maze[i, 0] = 1;
                    maze[i, height - 1] = 1;
                }
            }
            return maze;
        }

    }
    class Score
    {
        private int currentScore;
        Database db = new Database();

        Score()
        {
       
            currentScore = 0;
        }
        public int getScore()
        {
            return currentScore;
        }

        public void incrementScore(int increment)
        {
            currentScore += increment;
        }

        public int getHighScore()
        {
            return db.getHighSCore();
        }

        public void setHighScore(int highScore)
        {
            if (db.setHighScore(highScore) == false)
            {
                throw new System.Exception("Database fail");
            }
        }
    }
}
