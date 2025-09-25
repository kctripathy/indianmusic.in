using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class MusicPiece
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column("ArtistID")]
    public int? ArtistId { get; set; }

    [Column("RegionID")]
    public int? RegionId { get; set; }

    [Column("InstrumentID")]
    public int? InstrumentId { get; set; }

    [Column("MovieID")]
    public int? MovieId { get; set; }

    [Column("RagaID")]
    public int? RagaId { get; set; }

    [Column("TalaID")]
    public int? TalaId { get; set; }

    [Column("MusicTypeID")]
    public int? MusicTypeId { get; set; }

    [Column("AudioURL")]
    [StringLength(300)]
    public string? AudioUrl { get; set; }

    [Column("VideoURL")]
    [StringLength(300)]
    public string? VideoUrl { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("ArtistId")]
    [InverseProperty("MusicPieces")]
    public virtual Artist? Artist { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("MusicPieces")]
    public virtual Category? Category { get; set; }

    [ForeignKey("InstrumentId")]
    [InverseProperty("MusicPieces")]
    public virtual Instrument? Instrument { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("MusicPieces")]
    public virtual Language? Language { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("MusicPieces")]
    public virtual Movie? Movie { get; set; }

    [InverseProperty("Music")]
    public virtual ICollection<MusicNotation> MusicNotations { get; set; } = new List<MusicNotation>();

    [ForeignKey("RagaId")]
    [InverseProperty("MusicPieces")]
    public virtual Raga? Raga { get; set; }

    [ForeignKey("RegionId")]
    [InverseProperty("MusicPieces")]
    public virtual Region? Region { get; set; }

    [ForeignKey("TalaId")]
    [InverseProperty("MusicPieces")]
    public virtual Tala? Tala { get; set; }
}
