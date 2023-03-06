using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;
using System.ComponentModel;

namespace Assignment;

[TestClass]
public class SampleDataTests
{
    private string filePath = "People.csv";
    SampleData sampleData = new SampleData();
    [TestMethod]
    public void IEnumerableCsvRows_GetsCSVRows()
    {
        //Arrange
        IEnumerable<string> expected = File.ReadLines(filePath).Skip(1);
       

        //Act
        IEnumerable<string> actual = sampleData.CsvRows;

        //Assert
        Assert.AreEqual<int>(expected.Count(), actual.Count());

        for (int i = 0; i < actual.Count(); i++)
        {
            Assert.AreEqual<string>(actual.ElementAt(i), expected.ElementAt(i));
        }
    }

    [TestMethod]
    public void TestSortedListOfUniqueStatesLINQ()
    {
        //Arrange
        IEnumerable<string> csv = File.ReadLines(filePath).Skip(1);
        IEnumerable<string> expected = csv.Select(row => row.Split(",")[6]).Distinct().ToImmutableSortedSet();
       
        //Act
        IEnumerable<string> actual = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        //Assert
        for (int i = 0; i < actual.Count(); i++)
        {
            Assert.AreEqual<string>(actual.ElementAt(i), expected.ElementAt(i));
        }

    }
    [TestMethod]
    public void TestUsingHardcodedAddressList()
    {
        //Arrange
        List<Address> addresses = new();
        addresses.Add(new Address("12345 E Dude St.", "Spokane", "WA", "99235"));
        addresses.Add(new Address("124", "Boise", "ID", "99943"));
        addresses.Add(new Address("456 Bro Ave", "Seattle", "WA", "89567"));

        List<string> states = new();
        for (int i = 0; i < addresses.Count(); i++) {
            states.Add(addresses[i].State);
        }
        IEnumerable<string> expected = new List<string>() { "ID", "WA" };

        //Act
        IEnumerable<string> statesSorted = states.Distinct().ToImmutableSortedSet();

        //Assert
        for (int i = 0; i < statesSorted.Count(); i++) 
        {
            Assert.AreEqual<string>(statesSorted.ElementAt(i), expected.ElementAt(i));
        }
    }

    [TestMethod]
    public void TestAggregateStateListReturnsProperString()
    {
        //Arrange
        IEnumerable<string> csv = File.ReadLines(filePath).Skip(1);
        IEnumerable<string> expected = csv.Select(row => row.Split(",")[6]).Distinct().ToImmutableSortedSet();
        
        //Act
        string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        //Assert
        Assert.AreEqual<string>(actual, "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY," +
            " OR, PA, SC, TN, TX, UT, VA, WA, WV");
    }

}

    
