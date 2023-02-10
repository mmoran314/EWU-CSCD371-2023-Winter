using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
// Decided to go with a struct/value type to compare the values incase names are shared.
public record struct FullName(string First, string Last, string? Middle = null)
{
    // The type should be immuatable as names should not change. 
    public string First { get; } = First ?? throw new ArgumentNullException(nameof(First));
    public string Last { get; } = Last ?? throw new ArgumentNullException(nameof(Last));
    // It is ok if Middle is null in this case as it is optional
    public string? Middle { get; } = Middle ?? null!;

    
    public string Name => Middle == null ? $"{First} {Last}" : $"{First} {Middle} {Last}";
}