using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Thata
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Aroh { get; set; } = null!;

    public string Avroh { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<Raga> Ragas { get; set; } = new List<Raga>();
}
