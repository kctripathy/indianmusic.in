using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Article
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    [Column("AuthorID")]
    public int? AuthorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PublishDate { get; set; }

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

    [ForeignKey("AuthorId")]
    [InverseProperty("Articles")]
    public virtual Author? Author { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Articles")]
    public virtual Category? Category { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Articles")]
    public virtual Language? Language { get; set; }
}
