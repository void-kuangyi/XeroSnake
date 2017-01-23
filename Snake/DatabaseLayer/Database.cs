using System.IO;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public class Database
    {
        SqlConnection sqlConnection;
        SqlCommand cmd;
        SqlDataReader sqlDataReader;
        string gameType;

        public Database(string gameType)
        {
            sqlConnection = new SqlConnection("Server= localhost; Database= SnakeHighScores; Integrated Security=True;");
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            this.gameType = gameType;
        }

        const string FILENAME = "highscores.txt";

        public int getHighSCore()
        {
            int highScore = 100;

            cmd.CommandText = "SELECT * FROM HighScores where GameType = '" + gameType + "'";

            List<int> highScoreList = new List<int>();
            List<string> nameList = new List<string>();

            sqlConnection.Open();
            sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    highScoreList.Add(sqlDataReader.GetInt32(2));
                    nameList.Add(sqlDataReader.GetString(3));
                }
            }

            sqlConnection.Close();

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