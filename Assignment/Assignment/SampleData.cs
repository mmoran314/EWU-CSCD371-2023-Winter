using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

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
        public IEnumerable<IPerson> People 
        {
            get
            {
                List<Person> persons = new List<Person>();
                foreach (string row in CsvRows)
                {
                    string[] personInfo = row.Split(",");
                    string first = personInfo[1];
                    string last = personInfo[2];
                    string email = personInfo[3];
                    string streetAddress = personInfo[4];
                    string city = personInfo[5];
                    string state = personInfo[6];
                    string zip = personInfo[7];

                    Address personAddress = new(streetAddress, city, state, zip);
                    Person person = new(first, last, personAddress, email);

                    persons.Add(person);
                }
                return persons.OrderBy(person => person.Address.State);
            }
        }



        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            //IEnumerable<(string, string)> filtered = People.Where(person => filter(person.EmailAddress)).ToList();
            List<IPerson> filtered = People.Where(person => filter(person.EmailAddress)).ToList();
            List<(string, string)> personList = new List<(string, string)>();
            foreach (IPerson person in filtered)
            {
                personList.Add((person.FirstName, person.LastName));
            }
            return personList;
        }
            
        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            IEnumerable<string> states = People.Select(p => p.Address.State).Distinct();
            StringBuilder statesString = states.Aggregate(new StringBuilder(), (a, b) => {
                if (a.Length > 0)
                {
                    a.Append(", ");
                }
                a.Append(b);
                return a;
            });
            return statesString.ToString();
        }
    }
}
