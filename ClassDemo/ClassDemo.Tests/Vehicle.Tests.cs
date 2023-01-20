namespace ClassDemo.Tests;

[TestClass]
public class VehicleTests
{
    [TestMethod]

    public void Model_GivenToyota_ReturnsToyota()
    {
        //Arrange
        Vehicle vehicle = new("Toyota");
        vehicle.Model = "Toyota";
        //Act
        string actual = vehicle.Model;

        //Assert
        Assert.AreEqual("Toyota", actual);
    }
    [TestMethod]
    public void Model_GivenNull_ThrowsException()
    {
        //Assert
        Vehicle vehicle = new("Toyota");

        ArgumentNullException? expectedException = null;
        //Act
        try
        {
            vehicle.Model = null!;
        }
        catch (ArgumentNullException ex)
        {

            expectedException = ex;
        }
        Assert.IsNotNull(expectedException);

        //Assert

    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Model_GivenEmptyString_ThrowsException()
    {
        //Arrange
        Vehicle vehicle = new("Toyota");
        vehicle.Model = "";


    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Model_GivenWhiteSpaceString_ThrowsException()
    {
        //Arrange
        Vehicle vehicle = new("Toyota");
        vehicle.Model = " ";
    }
    [TestMethod]
    public void Create_ValidModel_Success()
    {
        //Arrange
        Vehicle vehicle = new(model:"Corolla");
    }

}