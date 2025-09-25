using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

[Index("ArtistId", "CategoryId", Name = "UQ_ArtistCategories", IsUnique = true)]
public partial class ArtistCategory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ArtistID")]
    public int? ArtistId { get; set; }

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

    [ForeignKey("ArtistId")]
    [InverseProperty("ArtistCategories")]
    public virtual Artist? Artist { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("ArtistCategories")]
    public virtual Category? Category { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("ArtistCategories")]
    public virtual Language? Language { get; set; }
}
