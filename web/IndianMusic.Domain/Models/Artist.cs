using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Artist
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(1500)]
    public string? ShortDesc { get; set; }

    public string? Bio { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? DeathDate { get; set; }

    [Column("RegionID")]
    public int? RegionId { get; set; }

    [Column("PhotoURL")]
    [StringLength(250)]
    public string? PhotoUrl { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [InverseProperty("Artist")]
    public virtual ICollection<ArtistCategory> ArtistCategories { get; set; } = new List<ArtistCategory>();

    [ForeignKey("LanguageId")]
    [InverseProperty("Artists")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Artist")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    [ForeignKey("RegionId")]
    [InverseProperty("Artists")]
    public virtual Region? Region { get; set; }
}
