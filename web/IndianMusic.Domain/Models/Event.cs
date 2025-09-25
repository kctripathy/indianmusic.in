using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Event
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(200)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [StringLength(150)]
    public string? Location { get; set; }

    public DateOnly? EventDate { get; set; }

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
    [InverseProperty("Events")]
    public virtual Category? Category { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Events")]
    public virtual Language? Language { get; set; }
}
