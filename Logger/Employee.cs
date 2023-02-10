using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Employee(FullName FullName, int Salary, string Position) : Person(FullName)
{
    public int Salary { get; } = Salary;
    public string Position { get; } = Position ?? throw new ArgumentNullException(nameof(Position));
}
