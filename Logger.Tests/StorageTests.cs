using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    FullName testFullName = new FullName("Donald", "Trump", "John");
    
    
    [TestMethod]
    public void Test_Add()
    {
        //Arrange
        Book testBook = new Book(testFullName, "My Book", "1234-5678");
        Storage storage = new Storage();

        //Act
        storage.Add(testBook);

        //Assert
        Assert.IsTrue(storage.Contains(testBook));
    }

    [TestMethod]
    public void Test_Get()
    {
        //Arrange
        Book testBook = new Book(testFullName, "My Book", "1234-5678");
        Storage storage = new Storage();

        //Act
        storage.Add(testBook);
        IEntity testEntity = storage.Get(testBook.Id) ?? null!; // Test for success of get

        //Assert
        Assert.AreEqual<IEntity>(testBook, testEntity);
    }
    [TestMethod]
    public void Test_Remove()
    {
        //Arrange
        Book testBook = new Book(testFullName, "My Book", "1234-5678");
        Storage storage = new Storage();

        //Act
        storage.Add(testBook);
        storage.Remove(testBook);

        //Assert
        Assert.IsFalse(storage.Contains(testBook));
    }
}
