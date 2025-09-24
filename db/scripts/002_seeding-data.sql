-- ====================================
-- Languages
-- ====================================
INSERT INTO Languages ([Name], [Description]) VALUES
(N'Hindi', N'Widely spoken language in North India'),
(N'Bengali', N'Language of West Bengal and Bangladesh'),
(N'Tamil', N'South Indian language'),
(N'Marathi', N'Language of Maharashtra');

-- ====================================
-- Categories
-- ====================================
INSERT INTO Categories ([Name], Description, LanguageID) VALUES
(N'Hindustani Classical', N'North Indian classical music tradition', 1),
(N'Carnatic Classical', N'South Indian classical music tradition', 3),
(N'Film Music', N'Bollywood and regional film music', 1);

-- ====================================
-- SubCategories
-- ====================================
INSERT INTO SubCategories (CategoryID, [Name], Description, LanguageID) VALUES
(1, N'Vocal', N'Classical vocal music', 1),
(1, N'Instrumental', N'Classical instrumental music', 1),
(2, N'Veena', N'Carnatic Veena compositions', 3),
(3, N'Bollywood Songs', N'Hindi film songs', 1);

-- ====================================
-- MusicTypes
-- ====================================
INSERT INTO MusicTypes (SubCategoryID, [Name], Description, LanguageID) VALUES
(1, N'Khayal', N'Major vocal style of Hindustani classical', 1),
(1, N'Dhrupad', N'Ancient vocal style', 1),
(2, N'Flute Solo', N'Bansuri performance', 1),
(3, N'Veena Krithi', N'Carnatic Veena based compositions', 3),
(4, N'Playback Song', N'Film songs sung for movies', 1);

-- ====================================
-- Regions
-- ====================================
INSERT INTO Regions ([Name], Description, LanguageID) VALUES
(N'North India', N'Region where Hindustani music is practiced', 1),
(N'South India', N'Region where Carnatic music is practiced', 3),
(N'Maharashtra', N'Western Indian state', 4);

-- ====================================
-- Instruments
-- ====================================
INSERT INTO Instruments ([Name], Type, Description, RegionID, LanguageID) VALUES
(N'Bansuri', N'Wind', N'Indian bamboo flute', 1, 1),
(N'Sitar', N'String', N'Plucked string instrument', 1, 1),
(N'Mridangam', N'Percussion', N'Primary Carnatic percussion instrument', 2, 3),
(N'Veena', N'String', N'Veena used in Carnatic music', 2, 3),
(N'Tabla', N'Percussion', N'Main Hindustani percussion instrument', 1, 1);

-- ====================================
-- Artists
-- ====================================
INSERT INTO Artists ([Name], Bio, BirthDate, RegionID, LanguageID) VALUES
(N'Pt. Ravi Shankar', N'Sitar maestro and composer', '1920-04-07', 1, 1),
(N'Hariprasad Chaurasia', N'Legendary bansuri player', '1938-07-01', 1, 1),
(N'M. S. Subbulakshmi', N'Carnatic vocalist', '1916-09-16', 2, 3),
(N'Ustad Zakir Hussain', N'Tabla virtuoso', '1951-03-09', 1, 1);

-- ====================================
-- ArtistCategories
-- ====================================
INSERT INTO ArtistCategories (ArtistID, CategoryID) VALUES
(1, 1), -- Ravi Shankar ? Hindustani Classical
(2, 1), -- Hariprasad ? Hindustani Classical
(3, 2), -- MS Subbulakshmi ? Carnatic Classical
(4, 1); -- Zakir Hussain ? Hindustani Classical

-- ====================================
-- Thatas
-- ====================================
INSERT INTO Thatas ([Name], Description, LanguageID) VALUES
(N'Bilawal', N'Equivalent of Ionian scale (Major)', 1),
(N'Kafi', N'Similar to Dorian scale', 1),
(N'Asavari', N'Natural minor equivalent', 1);

-- ====================================
-- Ragas
-- ====================================
INSERT INTO Ragas ([Name], ThaatID, RaagaDesc1, LanguageID) VALUES
(N'Yaman', 1, N'Major evening raga', 1),
(N'Bhairav', 2, N'Morning raga with serious mood', 1),
(N'Durga', 3, N'Audava raga, devotional', 1);

-- ====================================
-- SimilarRagas
-- ====================================
INSERT INTO SimilarRagas (RagaID, SimilarRagaID) VALUES
(1, 2), -- Yaman similar to Bhairav
(2, 3); -- Bhairav similar to Durga

-- ====================================
-- Talas
-- ====================================
INSERT INTO Talas ([Name], Beats, Description, LanguageID) VALUES
(N'Teental', 16, N'Most common Hindustani tala', 1),
(N'Jhaptal', 10, N'10 beat tala', 1),
(N'Adi Tala', 8, N'Carnatic tala', 3);

-- ====================================
-- Movies
-- ====================================
INSERT INTO Movies ([Name], ReleaseYear, LanguageID) VALUES
(N'Shree 420', 1955, 1),
(N'Mughal-e-Azam', 1960, 1),
(N'Shala', 2011, 4);

-- ====================================
-- MusicPieces
-- ====================================
INSERT INTO MusicPieces ([Title], ArtistID, InstrumentID, RagaID, TalaID, MovieID, LanguageID) VALUES
(N'Raga Yaman Performance', 2, 1, 1, 1, NULL, 1), -- Hariprasad Chaurasia bansuri
(N'Tabla Solo', 4, 5, 2, 2, NULL, 1), -- Zakir Hussain tabla
(N'Veena Krithi in Adi Tala', 3, 4, 3, 3, NULL, 3), -- MS Subbulakshmi veena/carnatic
(N'Pyar Hua Ikrar Hua', 1, 2, NULL, NULL, 1, 1); -- Film song from Shree 420
