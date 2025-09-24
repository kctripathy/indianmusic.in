using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();

    public virtual Language? Language { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();
}
