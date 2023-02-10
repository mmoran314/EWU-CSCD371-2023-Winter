using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class FullNameTests
{
    [TestMethod]
    public void CreateFullName_Success()
    {
        //Arrange
        FullName fullName = new FullName("Donald", "Trump", "John");

        //Assert
        Assert.IsNotNull(fullName);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateFullName_FailureFirstNameNull()
    {
        //Arrange
        FullName fullName = new FullName(null!, "Trump", "John"); //Use null forgiveness to test null input
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateFullName_FailureLastNameNull()
    {
        //Arrange
        FullName fullName = new FullName("Donald", null!, "John");//Use null forgiveness to test null input

    }
    [TestMethod]
    public void CreateFullName_NoMiddle_Success() 
    {
        //Arrange
        FullName fullName = new FullName("Donald", "Trump");

        //Assert
        Assert.IsNotNull(fullName);

    }
    [TestMethod]
    public void FullName_ReturnsProperName()
    {
        //Arrange
        FullName fullName = new FullName("Donald", "Trump", "John");

        //Act
        string expectedName = "Donald John Trump";

        //Assert
        Assert.AreEqual<string>(fullName.Name, expectedName);
    }
    [TestMethod]
    public void FullName_ReturnsProperName_NoMiddle()
    {
        //Arrange
        FullName fullName = new FullName("Donald", "Trump", null);

        //Act
        string expectedName = "Donald Trump";

        //Assert
        Assert.AreEqual<string>(fullName.Name, expectedName);
    }
}
