using System;
using NUnit.Framework;
using Rhino.Mocks;
using RoverKata.Model;

namespace RoverKata.Tests
{
    [TestFixture]
    public class RoverControllerTests
    {
        [TestCase("5 5 1 2 N", 5, 5, 1, 2, "North")]
        [TestCase("0 0 2 3 S", 0, 0, 2, 3, "South")]
        public void Given_Command_Then_RoverIsDeployedToCorrectLocation(string deployCommand, int expectedMapX, int expectedMapY, int expectedStartX, int expectedStartY, string expectedOrientation)
        {
            var rover = MockRepository.GenerateStub<IRover>();
            var roverController = new RoverController(rover);

            roverController.DeployRover(deployCommand);

            rover.AssertWasCalled(r => r.Land(Arg<Map>.Matches(m => m.X == expectedMapX && m.Y == expectedMapY), Arg<int>.Is.Equal(expectedStartX), Arg<int>.Is.Equal(expectedStartY), Arg<CompassPoint>.Is.Equal(ParseCompassPoint(expectedOrientation))));
        }

        [TestCase("5 5 1 2 N", "LMLMLMLMM", 5, 4, 0)]
        [TestCase("5 5 3 3 E", "MMRMMRMRRM", 6, 0, 4)]
        public void Given_Command_Then_RoverMoveIsCalledTheCorrectAmmountOfTimes(string initialPosition, string command, int repeatMove, int repeatLeft, int repeatRight)
        {
            var rover = MockRepository.GenerateStub<IRover>();
            var roverController = new RoverController(rover);

            roverController.CommandRover(command);

            rover.AssertWasCalled(r => r.Move(), move => move.Repeat.Times(repeatMove));
            rover.AssertWasCalled(r => r.RotateLeft(), rotateLeft => rotateLeft.Repeat.Times(repeatLeft));
            rover.AssertWasCalled(r => r.RotateRight(), rotateRight => rotateRight.Repeat.Times(repeatRight));
        }

        private CompassPoint ParseCompassPoint(string stringCompassPoint)
        {
            CompassPoint givenDirection;
            Assert.That(Enum.TryParse(stringCompassPoint, false, out givenDirection), Is.Not.False);

            return givenDirection;
        }
    }
}
