using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

[Index("Name", Name = "UQ__Roles__737584F62E5BA02D", IsUnique = true)]
public partial class Role
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [ForeignKey("LanguageId")]
    [InverseProperty("Roles")]
    public virtual Language? Language { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
