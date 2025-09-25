using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

[Index("Name", Name = "UQ__Users__737584F6FE9CEA6B", IsUnique = true)]
[Index("Email", Name = "UQ__Users__A9D105346CBF8524", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(256)]
    public string? PasswordHash { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Users")]
    public virtual Language? Language { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    [InverseProperty("User")]
    public virtual ICollection<UserSubmission> UserSubmissions { get; set; } = new List<UserSubmission>();
}
