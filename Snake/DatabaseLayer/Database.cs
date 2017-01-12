using System.IO;

namespace DatabaseLayer
{
    public class Database
    {
        const string FILENAME = "highscores.txt";

        public int getHighSCore()
        {
            int highScore;

            if (File.Exists(FILENAME))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(FILENAME, FileMode.Open)))
                {
                    highScore = reader.ReadInt32();
                }
            }
            else
            {
                return 0;
            }

            return highScore;
        }

        public bool setHighScore(int highScore)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FILENAME, FileMode.Create)))
            {
                writer.Write(highScore);
            }
            return true;
        }

    }
}