namespace BusinessLayer.FoodFolder
{
    public class Food
    {
        public int yLocation { get; set; }
        public int xLocation { get; set; }
        public int pointsWorth { get; set; }

        public Food()
        {
            xLocation = -1;
            yLocation = -1;
        }
    }
}