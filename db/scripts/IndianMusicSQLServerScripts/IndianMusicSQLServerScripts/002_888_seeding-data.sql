

-- ====================================
-- ArtistCategories
-- ====================================
--INSERT INTO ArtistCategories (ArtistID, CategoryID) VALUES
--(1, 1), -- Ravi Shankar ? Hindustani Classical
--(2, 1), -- Hariprasad ? Hindustani Classical
--(3, 2), -- MS Subbulakshmi ? Carnatic Classical
--(4, 1); -- Zakir Hussain ? Hindustani Classical

-- ====================================
-- Thatas
-- ====================================
--INSERT INTO Thatas ([Name], [Description]) VALUES
--(N'Bilawal', N'Equivalent of Ionian scale (Major)'),
--(N'Kalyan', N'Has Teevra Madhyam, soothing and auspicious, evening thaat'),
--(N'Khamaj', N'Romantic in nature, uses Komal Nishad'),
--(N'Bhairav', N'Uses Komal Rishabh and Komal Dhaivat, devotional and austere, morning thaat'),
--(N'Poorvi', N'Intensely sober, mixture of Komal Dhaivat, sunset thaat'),
--(N'Marwa', N'Combination of Komal Rishabh and Teevra Madhyam, nervous mood, sunset'),
--(N'Kafi', N'Uses Komal Gandhar and Komal Nishad, late evening, spring season'),
--(N'Asavari', N'Blend of Komal Dhaivat and Komal Gandhar, renunciation and sacrifice, late morning'),
--(N'Bhairavi', N'All Komal swaras except Pa, conveys devotion and compassion, early morning'),
--(N'Todi', N'King of all thaats, uses Komal Rishabh, Gandhar, Dhaivat, and Teevra Madhyam, late morning');

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
