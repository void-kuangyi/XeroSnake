namespace DatabaseLayer
{
    public class HighScore
    {
        public int score { get; set; }
        public string name { get; set; }

        public HighScore()
        {
            score = 0;
            name = "";
        }
    }
}