using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Region
{
    [Key]
    [Column("RegionID")]
    public int RegionId { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [InverseProperty("Region")]
    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    [InverseProperty("Region")]
    public virtual ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();

    [ForeignKey("LanguageId")]
    [InverseProperty("Regions")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Region")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();
}
