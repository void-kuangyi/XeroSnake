using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public class Database
    {
        private const int MaxNoOfScores = 5;
        private SqlDataReader sqlDataReader;
        private const string connectionString = "Server= localhost; Database= SnakeHighScores; Integrated Security=True;";


        public List<HighScore> GetHighScore(string mazeLevel)
        {
            List<HighScore> highScoreList;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    sqlConnection.Open();
                    cmd.CommandText = "SELECT * FROM HighScores where GameType = '" + mazeLevel + "'";
                    sqlDataReader = cmd.ExecuteReader();
                }

                highScoreList = new List<HighScore>(5);
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
            }

            return highScoreList;
        }

        public bool SetHighScore(List<HighScore> highScoreList, string mazeLevel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM HighScores where GameType='" + mazeLevel + "'";
                    sqlDataReader = cmd.ExecuteReader();
                }

                sqlConnection.Close();

                foreach (HighScore highScore in highScoreList)
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = sqlConnection.CreateCommand())
                    {

                        cmd.CommandText = "INSERT INTO HighScores VALUES ( '"
                                        + mazeLevel
                                        + "', "
                                        + highScore.score
                                        + ", '"
                                        + highScore.name
                                        + "')";

                        cmd.ExecuteReader();
                    }
                    sqlConnection.Close();
                }

                sqlConnection.Close();
            }

            return true;
        }

    }
}