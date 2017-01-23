using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public class Database
    {
        private const int MaxNoOfScores = 5;
        private SqlConnection sqlConnection;
        private SqlCommand cmd;
        private SqlDataReader sqlDataReader;
        private string mazeLevel;

        public Database(string mazeLevel)
        {
            sqlConnection = new SqlConnection("Server= localhost; Database= SnakeHighScores; Integrated Security=True;");
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            this.mazeLevel = mazeLevel;
        }

        const string FILENAME = "highscores.txt";

        public List<HighScore> getHighSCore()
        {
            cmd.CommandText = "SELECT * FROM HighScores where GameType = '" + mazeLevel + "'";
            List<HighScore> highScoreList = new List<HighScore>(5);

            sqlConnection.Open();
            sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    HighScore tempHSObject = new HighScore();
                    tempHSObject.score = sqlDataReader.GetInt32(2);
                    tempHSObject.name = sqlDataReader.GetString(3);
                    highScoreList.Add(tempHSObject);
                }
            }

            sqlConnection.Close();

            return highScoreList;
        }

        public bool setHighScore(List<HighScore> highScoreList)
        {
            cmd.CommandText = "DELETE FROM HighScores where GameType='" + mazeLevel + "'";
            sqlConnection.Open();
            sqlDataReader = cmd.ExecuteReader();
            sqlConnection.Close();

            foreach (HighScore highScore in highScoreList)
            {
                sqlConnection.Open();
                cmd.CommandText = "INSERT INTO HighScores VALUES ( '" 
                                + mazeLevel
                                + "', " 
                                + highScore.score 
                                + ", '"
                                + highScore.name
                                + "')";
                
                cmd.ExecuteReader();
                sqlConnection.Close();
            }

            return true;
        }

    }
}