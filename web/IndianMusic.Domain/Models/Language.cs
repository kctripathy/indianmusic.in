using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class Language
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    [InverseProperty("Language")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [InverseProperty("Language")]
    public virtual ICollection<ArtistCategory> ArtistCategories { get; set; } = new List<ArtistCategory>();

    [InverseProperty("Language")]
    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    [InverseProperty("Language")]
    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    [InverseProperty("Language")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    [InverseProperty("Language")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    [InverseProperty("Language")]
    public virtual ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();

    [InverseProperty("Language")]
    public virtual ICollection<Movie> MovieLanguages { get; set; } = new List<Movie>();

    [InverseProperty("MovieLanguage")]
    public virtual ICollection<Movie> MovieMovieLanguages { get; set; } = new List<Movie>();

    [InverseProperty("Language")]
    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    [InverseProperty("Language")]
    public virtual ICollection<Raga> Ragas { get; set; } = new List<Raga>();

    [InverseProperty("Language")]
    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();

    [InverseProperty("Language")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [InverseProperty("Language")]
    public virtual ICollection<Tala> Talas { get; set; } = new List<Tala>();

    [InverseProperty("Language")]
    public virtual ICollection<Thata> Thata { get; set; } = new List<Thata>();

    [InverseProperty("Language")]
    public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();

    [InverseProperty("Language")]
    public virtual ICollection<UserSubmission> UserSubmissions { get; set; } = new List<UserSubmission>();

    [InverseProperty("Language")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
