using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual Language? Language { get; set; }
}
