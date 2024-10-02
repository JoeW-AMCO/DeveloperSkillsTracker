using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperSkillsTracker;

namespace SkillsTrackerUnitTests
{
    [TestClass]
    public class AuthenticationTests
    {
        private StringReader _input;
        private StringWriter _output;
        private MyDbContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize common test setup
            _context = new MyDbContext();
            _output = new StringWriter();
            Console.SetOut(_output);
        }

        [TestMethod]
        public void ValidLoginPrintsWelcomeToConsole()
        {
            // Arrange
            _input = new StringReader("t\nt\n");
            Console.SetIn(_input);

            // Act
            Menus.MainMenu(_context);

            // Assert
            var consoleOutput = _output.ToString();
            Assert.IsTrue(consoleOutput.Contains("\nWelcome back, t!\n"));
        }

        [TestMethod]
        public void InvalidLoginPrintsInvalidToConsole()
        {
            // Arrange
            _input = new StringReader("\n\nt\nt\n");
            Console.SetIn(_input);

            // Act
            Menus.MainMenu(_context);

            // Assert
            var consoleOutput = _output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Invalid username or password. Please try again."));
        }
    }
}