using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
