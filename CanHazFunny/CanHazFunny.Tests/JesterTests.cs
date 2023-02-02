using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
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
        public void CreateJester_Failure()
        {
            // Arrange
            ReallyCoolJokeOutput reallyCoolJokeOutput = new ReallyCoolJokeOutput();
            JokeService jokeService = new JokeService();

            //Act
            Jester jester = new Jester(null!, null!); // use null forgiveness here to test argument null exception
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

        //[TestMethod]
        //public void TestJokeNotChuckNorris()
        //{
        //    //Arrange
        //    Jester jester = new Jester(new ReallyCoolJokeOutput(), new JokeService());
        //    var mock = new Mock<IJokeService>();
        //    mock.Setup(x => x.GetJoke())

        //        .Returns("Chuck Norris");
                


        //    var stringWriter = new StringWriter();
        //    Console.SetOut(stringWriter);

        //    //Act
        //    jester.TellJoke();

        //    //Assert

        //}

        [TestMethod]
        public void TestJokeConsoleOutputNotChuckNorris()
        {
            //Arrange
            Jester jester = new Jester(new ReallyCoolJokeOutput(), new JokeService());
            var stringWriter = new StringWriter();

            //Act
            Console.SetOut(stringWriter);
            string testJoke = jester.GetJoke();
            jester.WriteJoke(testJoke);
            

            //Assert
            Assert.IsFalse(stringWriter.ToString().Contains("Chuck Norris"));
        }
    }
}
