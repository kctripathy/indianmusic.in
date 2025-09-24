using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    public virtual ICollection<MusicType> MusicTypes { get; set; } = new List<MusicType>();

    public virtual ICollection<Raga> Ragas { get; set; } = new List<Raga>();
}
