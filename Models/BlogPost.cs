using System;
using System.Collections.Generic;

namespace BlogApplication1.Models;

public partial class BlogPost
{
    public short Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateOnly? PublicationDate { get; set; }

    public string? Author { get; set; }

    public short AuthorId { get; set; }
}
