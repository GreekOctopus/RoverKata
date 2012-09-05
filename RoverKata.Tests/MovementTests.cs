using NUnit.Framework;
using RoverKata.Model;

namespace RoverKata.Tests
{
    [TestFixture]
    class MovementTests
    {
        private Map _map;

        [SetUp]
        public void SetUp()
        {
            _map = new Map(10,10);
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(10, 10)]
        public void Given_oneMoveNorth_Then_YPosition_Increments_IfWithinMap(int startY, int expectedY)
        {
            var rover = new Rover();
            rover.Land(_map, 0, startY, CompassPoint.North);

            rover.Move();

            Assert.That(rover.Y, Is.EqualTo(expectedY));
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(0, 0)]
        public void Given_oneMoveSouth_Then_YPosition_Decrements_IfWithinMap(int startY, int expectedY)
        {
            var rover = new Rover();
            rover.Land(_map, 0, startY, CompassPoint.South);

            rover.Move();

            Assert.That(rover.Y, Is.EqualTo(expectedY));
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(10, 10)]
        public void Given_oneMoveEast_Then_XPosition_Increments_IfWithinMap(int startX, int expectedX)
        {
            var rover = new Rover();
            rover.Land(_map, startX, 0, CompassPoint.East);

            rover.Move();

            Assert.That(rover.X, Is.EqualTo(expectedX));
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(0, 0)]
        public void Given_oneMoveWest_Then_XPosition_Decrements_IfWithinMap(int startX, int expectedX)
        {
            var rover = new Rover();
            rover.Land(_map, startX, 0, CompassPoint.West);

            rover.Move();

            Assert.That(rover.X, Is.EqualTo(expectedX));
        }
    }
}
