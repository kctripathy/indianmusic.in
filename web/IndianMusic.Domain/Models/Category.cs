using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Category
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

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

    [Column("ParentID")]
    public int? ParentId { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [InverseProperty("Category")]
    public virtual ICollection<ArtistCategory> ArtistCategories { get; set; } = new List<ArtistCategory>();

    [InverseProperty("Category")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    [InverseProperty("Parent")]
    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    [ForeignKey("LanguageId")]
    [InverseProperty("Categories")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual Category? Parent { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Raga> Ragas { get; set; } = new List<Raga>();
}
