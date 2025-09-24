using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Raga
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? RaagaDesc1 { get; set; }

    public string? RaagaDesc2 { get; set; }

    public string Aroh { get; set; } = null!;

    public string Avroh { get; set; } = null!;

    public string? Pakad { get; set; }

    public string Vadi { get; set; } = null!;

    public string Samvadi { get; set; } = null!;

    public string? Nyasa { get; set; }

    public string? Jati { get; set; }

    public string? TimeOfDay { get; set; }

    public string? Mood { get; set; }

    public int? ThaatId { get; set; }

    public int? SubcategoryId { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public int? LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    public virtual ICollection<SimilarRaga> SimilarRagaRagas { get; set; } = new List<SimilarRaga>();

    public virtual ICollection<SimilarRaga> SimilarRagaSimilarRagaNavigations { get; set; } = new List<SimilarRaga>();

    public virtual SubCategory? Subcategory { get; set; }

    public virtual Thata? Thaat { get; set; }
}
