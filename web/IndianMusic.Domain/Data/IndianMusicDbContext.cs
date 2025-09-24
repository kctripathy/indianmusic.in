using IndianMusic.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Data;

public partial class IndianMusicDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    //public IndianMusicDbContext()
    //{
    //}

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

    public virtual DbSet<MusicType> MusicTypes { get; set; }

    public virtual DbSet<Raga> Ragas { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SimilarRaga> SimilarRagas { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Tala> Talas { get; set; }

    public virtual DbSet<Thata> Thatas { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivity> UserActivities { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserSubmission> UserSubmissions { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS_2022;Database=IndianMusic;User Id=sa;Password=maa@1234;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Load connection string from configuration or environment here if needed
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articles__3214EC27118D668B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.AuthorId)
                .HasDefaultValue(1)
                .HasColumnName("AuthorID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.PublishDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Author).WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Articles_AuthorID_Authors");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Articles_CategoryID_Categories");

            entity.HasOne(d => d.Language).WithMany(p => p.Articles)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Articles_LanguageID_Languages");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Artists__3214EC27A1015344");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(250)
                .HasColumnName("PhotoURL");
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.ShortDesc).HasMaxLength(1500);

            entity.HasOne(d => d.Language).WithMany(p => p.Artists)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Artists_LanguageID_Languages");

            entity.HasOne(d => d.Region).WithMany(p => p.Artists)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_Artists_RegionID_Regions");
        });

        modelBuilder.Entity<ArtistCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ArtistCa__3214EC27A4839D03");

            entity.HasIndex(e => new { e.ArtistId, e.CategoryId }, "UQ_ArtistCategories").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");

            entity.HasOne(d => d.Artist).WithMany(p => p.ArtistCategories)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_ArtistCategories_ArtistID_Artists");

            entity.HasOne(d => d.Category).WithMany(p => p.ArtistCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ArtistCategories_CategoryID_Categories");

            entity.HasOne(d => d.Language).WithMany(p => p.ArtistCategories)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_ArtistCategories_LanguageID_Languages");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.DisplayName).HasDefaultValue("");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.ProfileImageUrl).HasDefaultValue("");
            entity.Property(e => e.UserName).HasMaxLength(256);

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

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC273624915A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Language).WithMany(p => p.Authors)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Authors_LanguageID_Languages");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC2778197192");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Language).WithMany(p => p.Categories)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Categories_LanguageID_Languages");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC271A981912");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Location).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.Events)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Events_CategoryID_Categories");

            entity.HasOne(d => d.Language).WithMany(p => p.Events)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Events_LanguageID_Languages");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instrume__3214EC27060E3990");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Language).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Instruments_LanguageID_Languages");

            entity.HasOne(d => d.Region).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_Instruments_RegionID_Regions");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC2726FA1252");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC2757152B7F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.MovieLanguageId).HasColumnName("MovieLanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ReleaseYear)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.HasOne(d => d.Language).WithMany(p => p.MovieLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Movies_LanguageID_Languages");

            entity.HasOne(d => d.MovieLanguage).WithMany(p => p.MovieMovieLanguages)
                .HasForeignKey(d => d.MovieLanguageId)
                .HasConstraintName("FK_Movies_MovieLanguageID_Languages");
        });

        modelBuilder.Entity<MusicNotation>(entity =>
        {
            entity.HasKey(e => e.NotationId).HasName("PK__MusicNot__7BD5D7ED75A8C475");

            entity.Property(e => e.NotationId).HasColumnName("NotationID");
            entity.Property(e => e.LineType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.MusicId).HasColumnName("MusicID");
            entity.Property(e => e.Notation).HasMaxLength(10);

            entity.HasOne(d => d.Music).WithMany(p => p.MusicNotations)
                .HasForeignKey(d => d.MusicId)
                .HasConstraintName("FK_MusicNotations_MusicID_MusicPieces");
        });

        modelBuilder.Entity<MusicPiece>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MusicPie__3214EC2766285F8D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.AudioUrl)
                .HasMaxLength(300)
                .HasColumnName("AudioURL");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InstrumentId).HasColumnName("InstrumentID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.MusicTypeId).HasColumnName("MusicTypeID");
            entity.Property(e => e.RagaId).HasColumnName("RagaID");
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.SubcategoryId).HasColumnName("SubcategoryID");
            entity.Property(e => e.TalaId).HasColumnName("TalaID");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(300)
                .HasColumnName("VideoURL");

            entity.HasOne(d => d.Artist).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK_MusicPieces_ArtistID_Artists");

            entity.HasOne(d => d.Instrument).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK_MusicPieces_InstrumentID_Instruments");

            entity.HasOne(d => d.Language).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_MusicPieces_LanguageID_Languages");

            entity.HasOne(d => d.Movie).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK_MusicPieces_MovieID_Movies");

            entity.HasOne(d => d.MusicType).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.MusicTypeId)
                .HasConstraintName("FK_MusicPieces_MusicTypeID_MusicTypes");

            entity.HasOne(d => d.Raga).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.RagaId)
                .HasConstraintName("FK_MusicPieces_RaagaID_Ragas");

            entity.HasOne(d => d.Region).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_MusicPieces_RegionID_Regions");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.SubcategoryId)
                .HasConstraintName("FK_MusicPieces_SubcategoryID_Subcategories");

            entity.HasOne(d => d.Tala).WithMany(p => p.MusicPieces)
                .HasForeignKey(d => d.TalaId)
                .HasConstraintName("FK_MusicPieces_TalaID_Talas");
        });

        modelBuilder.Entity<MusicType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MusicTyp__3214EC271676B79B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

            entity.HasOne(d => d.Language).WithMany(p => p.MusicTypes)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_MusicTypes_LanguageID_Languages");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.MusicTypes)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK_MusicTypes_SubCategoryID_SubCategories");
        });

        modelBuilder.Entity<Raga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ragas__3214EC270DCA9A57");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.Aroh).HasMaxLength(100);
            entity.Property(e => e.Avroh).HasMaxLength(100);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Jati).HasMaxLength(100);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Mood).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Nyasa).HasMaxLength(20);
            entity.Property(e => e.Pakad).HasMaxLength(100);
            entity.Property(e => e.RaagaDesc1).HasMaxLength(1000);
            entity.Property(e => e.Samvadi).HasMaxLength(2);
            entity.Property(e => e.SubcategoryId).HasColumnName("SubcategoryID");
            entity.Property(e => e.ThaatId).HasColumnName("ThaatID");
            entity.Property(e => e.TimeOfDay).HasMaxLength(100);
            entity.Property(e => e.Vadi).HasMaxLength(2);

            entity.HasOne(d => d.Language).WithMany(p => p.Ragas)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Ragas_LanguageID_Languages");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Ragas)
                .HasForeignKey(d => d.SubcategoryId)
                .HasConstraintName("FK_Ragas_SubcategoryID_Subcategories");

            entity.HasOne(d => d.Thaat).WithMany(p => p.Ragas)
                .HasForeignKey(d => d.ThaatId)
                .HasConstraintName("FK_Ragas_ThaatID_Thatas");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Regions__ACD8444387262B9E");

            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Language).WithMany(p => p.Regions)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Regions_LanguageID_Languages");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27357B61D6");

            entity.HasIndex(e => e.Name, "UQ__Roles__737584F6C450CF09").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Language).WithMany(p => p.Roles)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Roles_LanguageID_Languages");
        });

        modelBuilder.Entity<SimilarRaga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SimilarR__3214EC27BE8C011D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RagaId).HasColumnName("RagaID");
            entity.Property(e => e.SimilarRagaId).HasColumnName("SimilarRagaID");

            entity.HasOne(d => d.Raga).WithMany(p => p.SimilarRagaRagas)
                .HasForeignKey(d => d.RagaId)
                .HasConstraintName("FK_SimilarRagas_RagaID_Ragas");

            entity.HasOne(d => d.SimilarRagaNavigation).WithMany(p => p.SimilarRagaSimilarRagaNavigations)
                .HasForeignKey(d => d.SimilarRagaId)
                .HasConstraintName("FK_SimilarRagas_SimilarRagaID_Ragas");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubCateg__3214EC27692EB21D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_SubCategories_CategoryID_Categories");

            entity.HasOne(d => d.Language).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_SubCategories_LanguageID_Languages");
        });

        modelBuilder.Entity<Tala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Talas__3214EC2776D17B99");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.Bol).HasMaxLength(1500);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Khalis).HasMaxLength(20);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Talis).HasMaxLength(20);

            entity.HasOne(d => d.Language).WithMany(p => p.Talas)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Talas_LanguageID_Languages");
        });

        modelBuilder.Entity<Thata>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Thatas__3214EC27FD856485");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.Aroh).HasMaxLength(100);
            entity.Property(e => e.Avroh).HasMaxLength(100);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Language).WithMany(p => p.Thata)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Thatas_LanguageID_Languages");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27C35C6D2A");

            entity.HasIndex(e => e.Name, "UQ__Users__737584F68D96CEC1").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053499F60B2C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);

            entity.HasOne(d => d.Language).WithMany(p => p.Users)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Users_LanguageID_Languages");
        });

        modelBuilder.Entity<UserActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserActi__3214EC27D6686F6E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActivityDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Language).WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_UserActivities_LanguageID_Languages");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserActivities_UserID_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A55D7C94C56");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserRoles_RoleID_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserRoles_UserID_Users");
        });

        modelBuilder.Entity<UserSubmission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSubm__3214EC2714365403");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy).HasDefaultValue(1);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(300)
                .HasColumnName("FileURL");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(1)
                .HasColumnName("LanguageID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.SubmittedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Language).WithMany(p => p.UserSubmissions)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_UserSubmissions_LanguageID_Languages");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubmissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserSubmissions_UserID_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
