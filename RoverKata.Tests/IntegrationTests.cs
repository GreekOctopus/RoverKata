using NUnit.Framework;
using Rhino.Mocks;
using RoverKata.Model;

namespace RoverKata.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [TestCase("5 5 1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("5 5 3 3 E", "MMRMMRMRRM", "5 1 E")]
        [TestCase("5 5 4 3 E", "MMRMMRMRRM", "5 1 E")]
        [TestCase("5 5 4 4 E", "MMRMMRMRRM", "5 2 E")]
        public void Given_Command_Then_RoverNavigatesToCorrectLocation(string initialPosition, string command, string finalPosition)
        {
            var rover = new Rover();
            var roverController = new RoverController(rover);

            roverController.DeployRover(initialPosition);
            roverController.CommandRover(command);

            Assert.That(roverController.ReportRoverPositionAndDirection(), Is.EqualTo(finalPosition));
        }
    }
}
