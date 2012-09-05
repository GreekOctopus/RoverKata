using NUnit.Framework;
using RoverKata.Model;

namespace RoverKata.Tests
{
    [TestFixture]
    public class InitialisationTests
    {
        [TestCase(0)]
        [TestCase(1)]
        public void When_reports_Xposition_then_Xposition_matches_initialX(int actualX)
        {
            var map = new Map(10, 10);
            var rover = new Rover();
            
            rover.Land(map, actualX, 0, CompassPoint.North);

            Assert.That(rover.X, Is.EqualTo(actualX));
        }

        [TestCase(0)]
        [TestCase(1)]
        public void When_reports_Yposition_then_Yposition_matches_initialY(int actualY)
        {
            var map = new Map(10, 10);
            var rover = new Rover();

            rover.Land(map, 0, actualY, CompassPoint.North);

            Assert.That(rover.Y, Is.EqualTo(actualY));
        }

        [TestCase("North")]
        [TestCase("South")]
        [TestCase("East")]
        [TestCase("West")]
        public void When_reports_Direction_then_Direction_matches_initialDirection(string direction)
        {
            var map = new Map(10, 10);
            var rover = new Rover();
            
            CompassPoint givenDirection;
            Assert.That(CompassPoint.TryParse(direction, false, out givenDirection), Is.Not.False);

            rover.Land(map, 0, 0, givenDirection);

            Assert.That(rover.Direction, Is.EqualTo(givenDirection));
        }
    }
}
