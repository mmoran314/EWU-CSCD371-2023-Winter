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
    public void TestSortedListOfUniqueStates()
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
}

    
