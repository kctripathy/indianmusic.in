using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateOnly? EventDate { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Language? Language { get; set; }
}
