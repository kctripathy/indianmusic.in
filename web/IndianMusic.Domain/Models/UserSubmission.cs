using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class UserSubmission
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? FileUrl { get; set; }

    public string? Status { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual User? User { get; set; }
}
