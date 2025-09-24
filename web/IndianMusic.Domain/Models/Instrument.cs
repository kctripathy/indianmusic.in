using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Instrument
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string? Description { get; set; }

    public int? RegionId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    public virtual Region? Region { get; set; }
}
