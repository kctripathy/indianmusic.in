using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Tala
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int Beats { get; set; }

    [StringLength(20)]
    public string Talis { get; set; } = null!;

    [StringLength(20)]
    public string? Khalis { get; set; }

    [StringLength(1500)]
    public string? Bol { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Talas")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Tala")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();
}
