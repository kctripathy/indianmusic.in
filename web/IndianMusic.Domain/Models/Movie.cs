using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Movie
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(4)]
    [Unicode(false)]
    public string? ReleaseYear { get; set; }

    [Column("MovieLanguageID")]
    public int? MovieLanguageId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("MovieLanguages")]
    public virtual Language? Language { get; set; }

    [ForeignKey("MovieLanguageId")]
    [InverseProperty("MovieMovieLanguages")]
    public virtual Language? MovieLanguage { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();
}
