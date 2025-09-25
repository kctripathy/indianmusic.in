using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class UserSubmission
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [Column("FileURL")]
    [StringLength(300)]
    public string? FileUrl { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SubmittedAt { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("UserSubmissions")]
    public virtual Language? Language { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserSubmissions")]
    public virtual User? User { get; set; }
}
