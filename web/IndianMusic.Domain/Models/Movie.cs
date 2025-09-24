using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ReleaseYear { get; set; }

    public int? MovieLanguageId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual Language? MovieLanguage { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();
}
