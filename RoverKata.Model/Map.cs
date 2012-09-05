namespace RoverKata.Model
{
    public class Map
    {
        public Map(int x, int y)
        {
            Y = y;
            X = x;
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }
    }
}
