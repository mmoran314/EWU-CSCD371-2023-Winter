using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
// Implicitly implements IEntity
public abstract record class Person(FullName FullName) : Entity
{
    // Implicitly implements IEntity
    public override string Name { get; } = FullName.ToString();
}

public record class Book(FullName AuthorName, string BookTitle, string ISBN) : Entity 
{
    public string BookTitle { get;} = BookTitle ?? throw new ArgumentNullException(nameof(BookTitle));
    public string ISBN { get;} = ISBN ?? throw new ArgumentNullException(nameof(ISBN));
    public FullName AName { get;} = AuthorName;
    
    // Implicitly implements IEntity
    public override string Name => AName.Name;
}
public record class Student(FullName FullName, string AcademicStanding, string Major) : Person(FullName)
{
    public string AcademicStanding { get; } = AcademicStanding ?? throw new ArgumentNullException(nameof(AcademicStanding));
    public string Major { get; } = Major ?? throw new ArgumentNullException(nameof(Major));
}
public record class Employee(FullName FullName, int Salary, string Position) : Person(FullName)
{
    public int Salary { get; } = Salary;
    public string Position { get; } = Position ?? throw new ArgumentNullException(nameof(Position));
}