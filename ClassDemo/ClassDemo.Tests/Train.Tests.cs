using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo.Tests;

public class TrainTests
{
    [TestMethod]
    public void Create_Trainwith5Carriages_Success()
    {
        //Arrange
        Train train = new(carriages: 5,"Steam");

        //Assert
        Assert.AreEqual(5, train.Carriages);
    }

    [TestMethod]
    public void Create_GivenTrain_IsVehicle()
    {
        //Arrange
        Train train = new(6,"Steam");

        //Assert
        Assert.IsTrue(train is Vehicle);
    }

    [TestMethod]
    public void Create_CarriagesAndModel_Success()
    {
        //Arrange
        Train train = new(6, "Bullet");

        //Assert
        Assert.AreEqual("Bullet", train.Model);
    }

    [TestClass]
    public void Create_GivenNoCarriage_CarriagesEquals42()
    {
        Train train = new("Bullet");
        Assert.AreEqual(42, train.Carriages);
    }
   
}
