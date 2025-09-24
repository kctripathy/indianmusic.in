using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public int? ModifedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<ArtistCategory> ArtistCategories { get; set; } = new List<ArtistCategory>();

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();

    public virtual ICollection<Movie> MovieLanguages { get; set; } = new List<Movie>();

    public virtual ICollection<Movie> MovieMovieLanguages { get; set; } = new List<Movie>();

    public virtual ICollection<MusicPiece> MusicPieces { get; set; } = new List<MusicPiece>();

    public virtual ICollection<MusicType> MusicTypes { get; set; } = new List<MusicType>();

    public virtual ICollection<Raga> Ragas { get; set; } = new List<Raga>();

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    public virtual ICollection<Tala> Talas { get; set; } = new List<Tala>();

    public virtual ICollection<Thata> Thata { get; set; } = new List<Thata>();

    public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();

    public virtual ICollection<UserSubmission> UserSubmissions { get; set; } = new List<UserSubmission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
