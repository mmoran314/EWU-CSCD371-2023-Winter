using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Reflection;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        private readonly Jester _jester;
        private readonly Mock<IJokeService> _jokeServiceMock = new Mock<IJokeService>();
        private readonly Mock<IJokeOutput> _outputMock = new Mock<IJokeOutput>();

        public JesterTests()
        {
            _jester = new Jester(_outputMock.Object, _jokeServiceMock.Object);
        }

        [TestMethod]
        public void CreateJester_Success()
        {
            //Arrange
            ReallyCoolJokeOutput reallyCoolJokeOutput = new ReallyCoolJokeOutput();
            JokeService jokeService = new JokeService();
            // Act
            Jester jester = new Jester(reallyCoolJokeOutput, jokeService);

            // Assert
            Assert.IsNotNull(jester);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateJester_FailureGivenNullJokeOutput()
        {
            // Arrange
            ReallyCoolJokeOutput reallyCoolJokeOutput = new ReallyCoolJokeOutput();
            JokeService jokeService = new JokeService();

            //Act
            Jester jester = new Jester(null!, jokeService); // use null forgiveness here to test argument null exception
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateJester_FailureGivenNullJokeServicet()
        {
            // Arrange
            ReallyCoolJokeOutput reallyCoolJokeOutput = new ReallyCoolJokeOutput();
            JokeService jokeService = new JokeService();

            //Act
            Jester jester = new Jester(reallyCoolJokeOutput, null!); // use null forgiveness here to test argument null exception
        }

        [TestMethod]
        public void TestWriteJokeIsNotNull() 
        {
            //Arrange
            Jester jester = new Jester(new ReallyCoolJokeOutput(), new JokeService());

            //Act
            string testJoke = jester.GetJoke();

            //Assert
            Assert.IsNotNull(testJoke);
        }

        [TestMethod]
        public void TestWriteJokeConsoleOutput() // Extra credit attempted
        {
            //Arrange
            Jester jester = new Jester(new ReallyCoolJokeOutput(), new JokeService());
            var stringWriter = new StringWriter();

            //Act
            Console.SetOut(stringWriter);
            string testJoke = jester.GetJoke();
            jester.WriteJoke(testJoke);

            //Assert
            Assert.AreEqual<string>(testJoke, stringWriter.ToString());
        }
        [TestMethod]
        public void TestChuckNorrisFilterMock()
        {
            //Arrange
            
            _jokeServiceMock.SetupSequence(x => x.GetJoke())
                .Returns("Chuck Norris")
                .Returns("He who shall not be named");

            //Act
            
            string testJoke = _jester.TellJoke();

            //Assert
            Assert.AreEqual<string>("He who shall not be named", testJoke);

        }
        [TestMethod]
        public void TestMockedJokeOutput()
        {
            //Arrange

            _jokeServiceMock.SetupSequence(x => x.GetJoke())
        
                .Returns("This is a joke");

            //Act

            string testJoke = _jester.TellJoke();

            //Assert
            Assert.AreEqual<string>("This is a joke", testJoke);

        }


        [TestMethod]
        public void TestJokeConsoleOutputNotChuckNorris()
        {
            //Arrange
            Jester jester = new Jester(new ReallyCoolJokeOutput(), new JokeService());
            var stringWriter = new StringWriter();

            //Act
            Console.SetOut(stringWriter);
            string testJoke = jester.TellJoke();
            jester.WriteJoke(testJoke);
            

            //Assert
            Assert.IsFalse(stringWriter.ToString().Contains("Chuck Norris"));
        }
    }
}
