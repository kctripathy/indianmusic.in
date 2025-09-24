using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class UserActivity
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ActivityName { get; set; }

    public DateTime? ActivityDate { get; set; }

    public string? Notes { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual User? User { get; set; }
}
