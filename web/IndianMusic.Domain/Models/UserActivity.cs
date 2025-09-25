using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class UserActivity
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ActivityName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActivityDate { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? Notes { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("UserActivities")]
    public virtual Language? Language { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserActivities")]
    public virtual User? User { get; set; }
}
