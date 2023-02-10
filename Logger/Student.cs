using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Student(FullName FullName, string AcademicStanding, string Major) : Person(FullName)
{
    public string AcademicStanding { get; } = AcademicStanding ?? throw new ArgumentNullException(nameof(AcademicStanding));
    public string Major { get; } = Major ?? throw new ArgumentNullException(nameof(Major));
}