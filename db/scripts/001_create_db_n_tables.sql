-- ================================
-- DATABASE: IndianMusicDB
-- ================================
--CREATE DATABASE IndianMusic;
--GO

USE IndianMusic;
GO

-- ================================
-- Languages
-- ================================
CREATE TABLE Languages (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL
);

-- ================================
-- Categories
-- ================================
CREATE TABLE Categories (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Categories_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Subcategories
-- ================================
CREATE TABLE SubCategories (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CategoryID INT,
    [Name] NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_SubCategories_CategoryID_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(ID),
	CONSTRAINT FK_SubCategories_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- MusicTypes
-- ================================
CREATE TABLE MusicTypes (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100),
	SubCategoryID INT,
    Description NVARCHAR(500),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_MusicTypes_SubCategoryID_SubCategories FOREIGN KEY (SubCategoryID) REFERENCES SubCategories(ID),
	CONSTRAINT FK_MusicTypes_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Regions
-- ================================
CREATE TABLE Regions (
    RegionID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100),
    Description NVARCHAR(500),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Regions_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Instruments
-- ================================
CREATE TABLE Instruments (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50),
    Description NVARCHAR(500),
    RegionID INT,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Instruments_RegionID_Regions FOREIGN KEY (RegionID) REFERENCES Regions(RegionID),
	CONSTRAINT FK_Instruments_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Artists
-- ================================
CREATE TABLE Artists (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(150) NOT NULL,
	ShortDesc NVARCHAR(1500),
    Bio NVARCHAR(MAX),
    BirthDate DATE,
    DeathDate DATE,
    RegionID INT,
    PhotoURL NVARCHAR(250),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Artists_RegionID_Regions FOREIGN KEY (RegionID) REFERENCES Regions(RegionID),
	CONSTRAINT FK_Artists_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Artist-Categories (Many-to-Many)
-- ================================
CREATE TABLE ArtistCategories (
	ID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT,
    CategoryID INT,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT UQ_ArtistCategories UNIQUE(ArtistID, CategoryID),
	CONSTRAINT FK_ArtistCategories_ArtistID_Artists FOREIGN KEY (ArtistID) REFERENCES Artists(ID),
	CONSTRAINT FK_ArtistCategories_CategoryID_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(ID),
	CONSTRAINT FK_ArtistCategories_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Thatas
-- ================================
CREATE TABLE Thatas (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    Aroh NVARCHAR(100) NOT NULL,
    Avroh NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Thatas_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Ragas
-- ================================
CREATE TABLE Ragas (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
	RaagaDesc1 NVARCHAR(1000) NULL,
	RaagaDesc2 NVARCHAR(MAX),
	Aroh NVARCHAR(100) NOT NULL,
    Avroh NVARCHAR(100) NOT NULL,
	Pakad NVARCHAR(100) NULL,
    Vadi NVARCHAR(2) NOT NULL,
	Samvadi NVARCHAR(2) NOT NULL,
	Nyasa NVARCHAR(20) NULL,
	Jati NVARCHAR(100) NULL,
	TimeOfDay NVARCHAR(100) NULL,
	Mood NVARCHAR(1000) NULL,
    ThaatID INT NULL,
    SubcategoryID INT,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Ragas_ThaatID_Thatas FOREIGN KEY (ThaatID) REFERENCES Thatas(ID),
	CONSTRAINT FK_Ragas_SubcategoryID_Subcategories FOREIGN KEY (SubcategoryID) REFERENCES SubCategories(ID),
	CONSTRAINT FK_Ragas_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- SimilarRagas
-- ================================
CREATE TABLE SimilarRagas (
	ID INT PRIMARY KEY IDENTITY(1,1),
	RagaID INT,
	SimilarRagaID INT,
	CONSTRAINT FK_SimilarRagas_RagaID_Ragas FOREIGN KEY (RagaID) REFERENCES Ragas(ID),
    CONSTRAINT FK_SimilarRagas_SimilarRagaID_Ragas FOREIGN KEY (SimilarRagaID) REFERENCES Ragas(ID)
);

-- ================================
-- Talas
-- ================================
CREATE TABLE Talas (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
	Beats INT NOT NULL,
	Talis NVARCHAR(20) NOT NULL,
	Khalis NVARCHAR(20) NULL,
	Bol NVARCHAR(1500) NULL,
    Description NVARCHAR(MAX),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Talas_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Movies
-- ================================

CREATE TABLE Movies (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
	ReleaseYear VARCHAR(4),
    MovieLanguageID INT,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Movies_MovieLanguageID_Languages FOREIGN KEY (MovieLanguageID) REFERENCES Languages(ID),
	CONSTRAINT FK_Movies_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- MusicPieces
-- ================================
CREATE TABLE MusicPieces (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    SubcategoryID INT,
    ArtistID INT,
    RegionID INT,
    InstrumentID INT,
	MovieID INT NULL,
	RagaID INT NULL,
	TalaID INT NULL,
    MusicTypeID INT	NULL,
    AudioURL NVARCHAR(300),
    VideoURL NVARCHAR(300),
    ReleaseDate DATE,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_MusicPieces_SubcategoryID_Subcategories FOREIGN KEY (SubcategoryID) REFERENCES SubCategories(ID),
	CONSTRAINT FK_MusicPieces_ArtistID_Artists FOREIGN KEY (ArtistID) REFERENCES Artists(ID),
	CONSTRAINT FK_MusicPieces_RegionID_Regions FOREIGN KEY (RegionID) REFERENCES Regions(RegionID),
	CONSTRAINT FK_MusicPieces_InstrumentID_Instruments FOREIGN KEY (InstrumentID) REFERENCES Instruments(ID),
	CONSTRAINT FK_MusicPieces_MovieID_Movies FOREIGN KEY (MovieID) REFERENCES Movies(ID),
	CONSTRAINT FK_MusicPieces_RaagaID_Ragas FOREIGN KEY (RagaID) REFERENCES Ragas(ID),
	CONSTRAINT FK_MusicPieces_TalaID_Talas FOREIGN KEY (TalaID) REFERENCES Talas(ID),
	CONSTRAINT FK_MusicPieces_MusicTypeID_MusicTypes FOREIGN KEY (MusicTypeID) REFERENCES MusicTypes(ID),
	CONSTRAINT FK_MusicPieces_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- MusicNotations
-- ================================
CREATE TABLE MusicNotations (
    NotationID INT PRIMARY KEY IDENTITY(1,1), 
    MusicID INT,
	LineType VARCHAR(2),
    LineNumber INT NOT NULL,
	BitNumber INT NOT NULL,
	Notation NVARCHAR(10),
	CONSTRAINT FK_MusicNotations_MusicID_MusicPieces FOREIGN KEY (MusicID) REFERENCES MusicPieces(ID)
);

-- ================================
-- Authors
-- ================================
CREATE TABLE Authors (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(200) NOT NULL,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Authors_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Articles
-- ================================
CREATE TABLE Articles (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX),
    AuthorID INT DEFAULT(1),
    PublishDate DATETIME DEFAULT GETDATE(),
    CategoryID INT,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Articles_AuthorID_Authors FOREIGN KEY (AuthorID) REFERENCES Authors(ID),
	CONSTRAINT FK_Articles_CategoryID_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(ID),
	CONSTRAINT FK_Articles_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Users
-- ================================
CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(256),
    IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Users_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

CREATE TABLE Roles (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) UNIQUE NOT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Roles_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

CREATE TABLE UserRoles (
    UserRoleID INT PRIMARY KEY IDENTITY(1,1),
	UserID INT,
	RoleID INT,
	CONSTRAINT FK_UserRoles_UserID_Users FOREIGN KEY (UserID) REFERENCES Users(ID),
	CONSTRAINT FK_UserRoles_RoleID_Roles FOREIGN KEY (RoleID) REFERENCES Roles(ID)
);

CREATE TABLE UserActivities (
    ID INT PRIMARY KEY IDENTITY(1,1),
	UserID INT,
	ActivityName VARCHAR(100),
	ActivityDate DATETIME DEFAULT(GETDATE()),
	Notes VARCHAR(1000),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_UserActivities_UserID_Users FOREIGN KEY (UserID) REFERENCES Users(ID),
	CONSTRAINT FK_UserActivities_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

CREATE TABLE UserSubmissions (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    FileURL NVARCHAR(300),
    Status NVARCHAR(50) DEFAULT 'Pending',
    SubmittedAt DATETIME DEFAULT GETDATE(),
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_UserSubmissions_UserID_Users FOREIGN KEY (UserID) REFERENCES Users(ID),
	CONSTRAINT FK_UserSubmissions_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);

-- ================================
-- Events
-- ================================
CREATE TABLE [Events] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(200),
    Description NVARCHAR(MAX),
    Location NVARCHAR(150),
    EventDate DATE,
    CategoryID INT,
	IsActive BIT DEFAULT(1),
	AddedBy INT DEFAULT(1),
	DateAdded DATETIME DEFAULT(GETDATE()),
	ModifedBy INT NULL,
	ModifiedDate INT NULL,
	LanguageID INT DEFAULT(1),
	CONSTRAINT FK_Events_CategoryID_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(ID),
	CONSTRAINT FK_Events_LanguageID_Languages FOREIGN KEY (LanguageID) REFERENCES Languages(ID)
);
