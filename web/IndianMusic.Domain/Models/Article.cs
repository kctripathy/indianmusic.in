using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public int? AuthorId { get; set; }

    public DateTime? PublishDate { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Language? Language { get; set; }
}
