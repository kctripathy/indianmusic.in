using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class MusicType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SubCategoryId { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    public virtual SubCategory? SubCategory { get; set; }
}
