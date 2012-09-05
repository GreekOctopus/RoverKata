using System;

namespace RoverKata.Model
{
    public interface IRoverController
    {
        void DeployRover(string deployCommand);
        void CommandRover(string directions);
        string ReportRoverPositionAndDirection();
    }

    public class RoverController : IRoverController
    {       
        private readonly IRover _rover;

        public RoverController(IRover rover)
        {
            _rover = rover;
        }

        public void DeployRover(string deployCommand)
        {
            var parameters = deployCommand.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var mapX = Int32.Parse(parameters[0]);
            var mapY = Int32.Parse(parameters[1]);

            var map = new Map(mapX, mapY);

            var roverX = Int32.Parse(parameters[2]);
            var roverY = Int32.Parse(parameters[3]);

            _rover.Land(map, roverX, roverY, ConvertOrientation(parameters[4]));
        }

        public void CommandRover(string directions)
        {
            foreach(var direction in directions)
            {
                switch (direction)
                {
                    case 'L':
                        _rover.RotateLeft();
                        break;
                    case 'R':
                        _rover.RotateRight();
                        break;
                    case 'M':
                        _rover.Move();
                        break;
                }
            }
        }

        public string ReportRoverPositionAndDirection()
        {
            return _rover.X + " " + _rover.Y + " " + _rover.Direction.ToString().Substring(0,1);
        }

        private static CompassPoint ConvertOrientation(string orientation)
        {
            switch (orientation)
            {
                case "N":
                    return CompassPoint.North;
                case "E":
                    return CompassPoint.East;
                case "S":
                    return CompassPoint.South;
                case "W":
                    return CompassPoint.West;
            }
            return CompassPoint.North;
        }
    }
}