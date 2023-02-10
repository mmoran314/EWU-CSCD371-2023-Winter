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
    public override string Name { get; } = FullName.Name;
}


