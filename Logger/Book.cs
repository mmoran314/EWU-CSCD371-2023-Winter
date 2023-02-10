using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Book(FullName AuthorName, string BookTitle, string ISBN) : Entity
{
    public string BookTitle { get; } = BookTitle ?? throw new ArgumentNullException(nameof(BookTitle));
    public string ISBN { get; } = ISBN ?? throw new ArgumentNullException(nameof(ISBN));
    public FullName AuthorName { get; } = AuthorName;

    // Implicitly implements IEntity
    public override string Name => AuthorName.Name;
}
