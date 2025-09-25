using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Instrument
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? Type { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Column("RegionID")]
    public int? RegionId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Instruments")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Instrument")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    [ForeignKey("RegionId")]
    [InverseProperty("Instruments")]
    public virtual Region? Region { get; set; }
}
