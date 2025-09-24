using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Tala
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Beats { get; set; }

    public string Talis { get; set; } = null!;

    public string? Khalis { get; set; }

    public string? Bol { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();
}
