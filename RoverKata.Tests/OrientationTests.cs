using NUnit.Framework;
using RoverKata.Model;

namespace RoverKata.Tests
{
    [TestFixture]
    class OrientationTests
    {
        private Map map;
        private Rover rover;

        [TestCase("North", "West")]
        [TestCase("West", "South")]
        [TestCase("South", "East")]
        [TestCase("East", "North")]
        public void Given_leftCommand_Then_orientationIsUpdated(string initialDirection, string expectedDirection)
        {
            SetupRover(initialDirection);
            var finalDirection = ParseCompassPoint(expectedDirection);

            rover.RotateLeft();

            Assert.That(rover.Direction, Is.EqualTo(finalDirection));
        }

        [TestCase("North", "East")]
        [TestCase("East", "South")]
        [TestCase("South", "West")]
        [TestCase("West", "North")]
        public void Given_rightCommand_Then_orientationIsUpdated(string initialDirection, string expectedDirection)
        {
            SetupRover(initialDirection);
            var finalDirection = ParseCompassPoint(expectedDirection);

            rover.RotateRight();

            Assert.That(rover.Direction, Is.EqualTo(finalDirection));
        }

        private void SetupRover(string initialDirection)
        {
            const int maxX = 10;
            const int maxY = 10;
            var givenDirection = ParseCompassPoint(initialDirection);

            map = new Map(maxX, maxY);
            rover = new Rover();
            rover.Land(map, 0, 0, givenDirection);
        }

        private CompassPoint ParseCompassPoint(string stringCompassPoint)
        {
            CompassPoint givenDirection;
            Assert.That(CompassPoint.TryParse(stringCompassPoint, false, out givenDirection), Is.Not.False);

            return givenDirection;
        }
    }
}
