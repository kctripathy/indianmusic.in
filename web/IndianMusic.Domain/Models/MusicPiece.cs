using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class MusicPiece
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? SubcategoryId { get; set; }

    public int? ArtistId { get; set; }

    public int? RegionId { get; set; }

    public int? InstrumentId { get; set; }

    public int? MovieId { get; set; }

    public int? RagaId { get; set; }

    public int? TalaId { get; set; }

    public int? MusicTypeId { get; set; }

    public string? AudioUrl { get; set; }

    public string? VideoUrl { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Artist? Artist { get; set; }

    public virtual Instrument? Instrument { get; set; }

    public virtual Language? Language { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual ICollection<MusicNotation> MusicNotations { get; set; } = new List<MusicNotation>();

    public virtual MusicType? MusicType { get; set; }

    public virtual Raga? Raga { get; set; }

    public virtual Region? Region { get; set; }

    public virtual SubCategory? Subcategory { get; set; }

    public virtual Tala? Tala { get; set; }
}
