using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadLines("People.csv").Skip(1);
       
        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            ////IEnumerable<string> states = new List<string>();
            //foreach (var row in CsvRows) 
            //{
                
            //}
            return CsvRows.Select(row => row.Split(",")[6]).Distinct().ToImmutableSortedSet();
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> sortedStateList = GetUniqueSortedListOfStatesGivenCsvRows();
            string[] states = sortedStateList.ToArray();

            return string.Join(", ", states);
        }
            

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();


        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
