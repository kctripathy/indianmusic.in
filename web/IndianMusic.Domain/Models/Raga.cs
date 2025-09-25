using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Raga
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string? RaagaDesc1 { get; set; }

    public string? RaagaDesc2 { get; set; }

    [StringLength(100)]
    public string Aroh { get; set; } = null!;

    [StringLength(100)]
    public string Avroh { get; set; } = null!;

    [StringLength(100)]
    public string? Pakad { get; set; }

    [StringLength(2)]
    public string Vadi { get; set; } = null!;

    [StringLength(2)]
    public string Samvadi { get; set; } = null!;

    [StringLength(20)]
    public string? Nyasa { get; set; }

    [StringLength(100)]
    public string? Jati { get; set; }

    [StringLength(100)]
    public string? TimeOfDay { get; set; }

    [StringLength(1000)]
    public string? Mood { get; set; }

    [Column("ThaatID")]
    public int? ThaatId { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Ragas")]
    public virtual Category? Category { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Ragas")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Raga")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    [InverseProperty("Raga")]
    public virtual ICollection<SimilarRaga> SimilarRagaRagas { get; set; } = new List<SimilarRaga>();

    [InverseProperty("SimilarRagaNavigation")]
    public virtual ICollection<SimilarRaga> SimilarRagaSimilarRagaNavigations { get; set; } = new List<SimilarRaga>();

    [ForeignKey("ThaatId")]
    [InverseProperty("Ragas")]
    public virtual Thata? Thaat { get; set; }
}
