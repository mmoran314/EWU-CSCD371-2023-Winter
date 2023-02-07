using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class RecordTests
{
    FullName testFullName = new FullName("John", "Doe");
    FullName testFullNameMiddle = new FullName("Donald", "Trump", "John");
    
    [TestMethod]
    public void CreateBook_Success()
    {
        //Arrange
        Book book = new Book(testFullName, "My Book", "1234-5678");

        //Assert
        Assert.IsNotNull(book);
    }

    [TestMethod]
    public void CreateStudent_Success()
    {
        //Arrange
        Student student = new Student(testFullName, "Junior", "Accounting");

        //Assert
        Assert.IsNotNull(student);
    }

    [TestMethod]
    public void CreateEmployee_Success() 
    {
        //Arrange
        Employee employee = new Employee(testFullName, 65000, "Manager");

        //Assert
        Assert.IsNotNull(employee);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateBook_Failure()
    {
        //Arrange
        Book book = new Book(testFullName, null!, null!);// Null forgiveness to test failure with null input

    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateStudent_Failure()
    {
        //Arrange
        Student student = new Student(testFullName, null!, null!);// Null forgiveness to test failure with null input

    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateEmployee_Failure()
    {
        //Arrange
        Employee employee = new Employee(testFullName, 50000, null!); // Null forgiveness to test failure with null input
    }
    }
