using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class IndianMusicDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public IndianMusicDbContext(DbContextOptions<IndianMusicDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<ArtistCategory> ArtistCategories { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MusicNotation> MusicNotations { get; set; }

    public virtual DbSet<MusicPiece> MusicPieces { get; set; }

    public virtual DbSet<Raga> Ragas { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SimilarRaga> SimilarRagas { get; set; }

    public virtual DbSet<Tala> Talas { get; set; }

    public virtual DbSet<Thata> Thatas { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivity> UserActivities { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserSubmission> UserSubmissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articles__3214EC27F926B9E1");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.AuthorId).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);
            entity.Property(e => e.PublishDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Author).WithMany(p => p.Articles).HasConstraintName("FK_Articles_AuthorID_Authors");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles).HasConstraintName("FK_Articles_CategoryID_Categories");

            entity.HasOne(d => d.Language).WithMany(p => p.Articles).HasConstraintName("FK_Articles_LanguageID_Languages");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Artists__3214EC27BF0EE76F");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Artists).HasConstraintName("FK_Artists_LanguageID_Languages");

            entity.HasOne(d => d.Region).WithMany(p => p.Artists).HasConstraintName("FK_Artists_RegionID_Regions");
        });

        modelBuilder.Entity<ArtistCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ArtistCa__3214EC2716948E8D");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Artist).WithMany(p => p.ArtistCategories).HasConstraintName("FK_ArtistCategories_ArtistID_Artists");

            entity.HasOne(d => d.Category).WithMany(p => p.ArtistCategories).HasConstraintName("FK_ArtistCategories_CategoryID_Categories");

            entity.HasOne(d => d.Language).WithMany(p => p.ArtistCategories).HasConstraintName("FK_ArtistCategories_LanguageID_Languages");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.DisplayName).HasDefaultValue("");
            entity.Property(e => e.ProfileImageUrl).HasDefaultValue("");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC27372A418F");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Authors).HasConstraintName("FK_Authors_LanguageID_Languages");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27D8ECFA91");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Categories).HasConstraintName("FK_Categories_LanguageID_Languages");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("FK_Categories_ParentID");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC2789D0DAD0");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Category).WithMany(p => p.Events).HasConstraintName("FK_Events_CategoryID_Categories");

            entity.HasOne(d => d.Language).WithMany(p => p.Events).HasConstraintName("FK_Events_LanguageID_Languages");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instrume__3214EC27CC32DB80");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Instruments).HasConstraintName("FK_Instruments_LanguageID_Languages");

            entity.HasOne(d => d.Region).WithMany(p => p.Instruments).HasConstraintName("FK_Instruments_RegionID_Regions");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC27A62245AF");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC27988C9E7E");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.MovieLanguages).HasConstraintName("FK_Movies_LanguageID_Languages");

            entity.HasOne(d => d.MovieLanguage).WithMany(p => p.MovieMovieLanguages).HasConstraintName("FK_Movies_MovieLanguageID_Languages");
        });

        modelBuilder.Entity<MusicNotation>(entity =>
        {
            entity.HasKey(e => e.NotationId).HasName("PK__MusicNot__7BD5D7EDD74882FD");

            entity.HasOne(d => d.Music).WithMany(p => p.MusicNotations).HasConstraintName("FK_MusicNotations_MusicID_MusicPieces");
        });

        modelBuilder.Entity<MusicPiece>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MusicPie__3214EC276D29FB5C");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Artist).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_ArtistID_Artists");

            entity.HasOne(d => d.Category).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_SubcategoryID_Subcategories");

            entity.HasOne(d => d.Instrument).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_InstrumentID_Instruments");

            entity.HasOne(d => d.Language).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_LanguageID_Languages");

            entity.HasOne(d => d.Movie).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_MovieID_Movies");

            entity.HasOne(d => d.Raga).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_RaagaID_Ragas");

            entity.HasOne(d => d.Region).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_RegionID_Regions");

            entity.HasOne(d => d.Tala).WithMany(p => p.MusicPieces).HasConstraintName("FK_MusicPieces_TalaID_Talas");
        });

        modelBuilder.Entity<Raga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ragas__3214EC27F53761FB");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Category).WithMany(p => p.Ragas).HasConstraintName("FK_Ragas_CategoryID_Subcategories");

            entity.HasOne(d => d.Language).WithMany(p => p.Ragas).HasConstraintName("FK_Ragas_LanguageID_Languages");

            entity.HasOne(d => d.Thaat).WithMany(p => p.Ragas).HasConstraintName("FK_Ragas_ThaatID_Thatas");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Regions__ACD844439A029E1A");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Regions).HasConstraintName("FK_Regions_LanguageID_Languages");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27B18283B1");

            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Roles).HasConstraintName("FK_Roles_LanguageID_Languages");
        });

        modelBuilder.Entity<SimilarRaga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SimilarR__3214EC273827A134");

            entity.HasOne(d => d.Raga).WithMany(p => p.SimilarRagaRagas).HasConstraintName("FK_SimilarRagas_RagaID_Ragas");

            entity.HasOne(d => d.SimilarRagaNavigation).WithMany(p => p.SimilarRagaSimilarRagaNavigations).HasConstraintName("FK_SimilarRagas_SimilarRagaID_Ragas");
        });

        modelBuilder.Entity<Tala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Talas__3214EC27C5CF50B8");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Talas).HasConstraintName("FK_Talas_LanguageID_Languages");
        });

        modelBuilder.Entity<Thata>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Thatas__3214EC2702150359");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Thata).HasConstraintName("FK_Thatas_LanguageID_Languages");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27E54E409B");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.Users).HasConstraintName("FK_Users_LanguageID_Languages");
        });

        modelBuilder.Entity<UserActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserActi__3214EC27DB4711FB");

            entity.Property(e => e.ActivityDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);

            entity.HasOne(d => d.Language).WithMany(p => p.UserActivities).HasConstraintName("FK_UserActivities_LanguageID_Languages");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivities).HasConstraintName("FK_UserActivities_UserID_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A5506B65CEA");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasConstraintName("FK_UserRoles_RoleID_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasConstraintName("FK_UserRoles_UserID_Users");
        });

        modelBuilder.Entity<UserSubmission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSubm__3214EC27D6A10E2C");

            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);
            entity.Property(e => e.Status).HasDefaultValue("Pending");
            entity.Property(e => e.SubmittedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Language).WithMany(p => p.UserSubmissions).HasConstraintName("FK_UserSubmissions_LanguageID_Languages");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubmissions).HasConstraintName("FK_UserSubmissions_UserID_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
