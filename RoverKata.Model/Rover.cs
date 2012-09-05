namespace RoverKata.Model
{
    public interface IRover
    {
        int X { get; }
        int Y { get; }
        CompassPoint Direction { get; }
        void Land(Map map, int x, int y, CompassPoint direction);
        void RotateLeft();
        void RotateRight();
        void Move();
    }

    public class Rover : IRover
    {
        private int _mapX;
        private int _mapY;

        public void Land(Map map, int x, int y, CompassPoint direction)
        {
            _mapX = map.X;
            _mapY = map.Y;
            X = x;
            Y = y;
            Direction = direction;
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

        public CompassPoint Direction
        {
            get;
            private set;
        }

        public void RotateLeft()
        {
            switch (Direction)
            {
                case CompassPoint.North:
                    Direction = CompassPoint.West;
                    break;
                case CompassPoint.West:
                    Direction = CompassPoint.South;
                    break;
                case CompassPoint.South:
                    Direction = CompassPoint.East;
                    break;
                case CompassPoint.East:
                    Direction = CompassPoint.North;
                    break;
            }
        }

        public void RotateRight()
        {
            switch (Direction)
            {
                case CompassPoint.North:
                    Direction = CompassPoint.East;
                    break;
                case CompassPoint.East:
                    Direction = CompassPoint.South;
                    break;
                case CompassPoint.South:
                    Direction = CompassPoint.West;
                    break;
                case CompassPoint.West:
                    Direction = CompassPoint.North;
                    break;
            }
        }

        public void Move()
        {
            switch (Direction)
            {
                case CompassPoint.North:
                    if (Y < _mapY)
                    {
                        Y++;
                    }
                    break;
                case CompassPoint.South:
                    if (Y > 0)
                    {
                        Y--;
                    }
                    break;
                case CompassPoint.East:
                    if (X < _mapX)
                    {
                        X++;
                    }
                    break;
                case CompassPoint.West:
                    if (X > 0)
                    {
                        X--;
                    }
                    break;
            }
        }
    }
}
