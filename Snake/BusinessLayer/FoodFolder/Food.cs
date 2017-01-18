namespace BusinessLayer.FoodFolder
{
    public abstract class Food
    {
        public int yLocation { get; set; }
        public int xLocation { get; set; }
        public int pointsWorth { get; protected set; }

        public Food()
        {
            xLocation = -1;
            yLocation = -1;
        }
    }
}