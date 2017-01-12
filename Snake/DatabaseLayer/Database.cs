using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void setHighScore(int highScore)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FILENAME, FileMode.Create)))
            {
                writer.Write(highScore);
            }
        }

    }
}