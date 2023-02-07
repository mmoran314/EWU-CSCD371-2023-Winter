﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
// Abstract base class
public abstract record class Entity : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public abstract string Name { get;}
}
