using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ShortDesc { get; set; }

    public string? Bio { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? DeathDate { get; set; }

    public int? RegionId { get; set; }

    public string? PhotoUrl { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual ICollection<ArtistCategory> ArtistCategories { get; set; } = new List<ArtistCategory>();

    public virtual Language? Language { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    public virtual Region? Region { get; set; }
}
