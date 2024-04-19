using System;
using System.Collections.Generic;

namespace BlogApplication1.Models;

public partial class Author
{
    public short Id { get; set; }

    public string? AuthorName { get; set; }

    public string? AuthorEmail { get; set; }
}
