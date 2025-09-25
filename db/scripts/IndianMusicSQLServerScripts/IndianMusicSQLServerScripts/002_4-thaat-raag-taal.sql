

INSERT INTO Thatas ([Name], [Description], [Aroh], [Avroh]) VALUES
(N'Bilawal', N'Equivalent of Ionian scale (Major)', N'S R G M P D N ?', N'? N D P M G R S'),
(N'Kalyan', N'Has Teevra Madhyam, soothing and auspicious, evening thaat', N'S R G ? P d n ?', N'? N D P ? G R S'),
(N'Khamaj', N'Romantic, uses Komal Nishad', N'S R G M P D n ?', N'? n D P M G R S'),
(N'Bhairav', N'Uses Komal Rishabh and Komal Dhaivat, devotional and austere, morning thaat', N'S r G M P d N ?', N'? N d P M G r S'),
(N'Poorvi', N'Intensely sober, uses Komal Dhaivat and Teevra Madhyam, evening', N'S R G ? P d N ?', N'? N d P ? G R S'),
(N'Marwa', N'Combination of Komal Rishabh and Teevra Madhyam, nervous mood, evening', N'S r G ? P D N ?', N'? N D P ? G r S'),
(N'Kafi', N'Uses Komal Gandhar and Komal Nishad, late evening, spring season', N'S R g M P D n ?', N'? n D P M g R S'),
(N'Asavari', N'Blend of Komal Dhaivat, Komal Gandhar, and Komal Nishad, late morning', N'S R g M P d n ?', N'? n d P M g R S'),
(N'Bhairavi', N'All Komal swaras except Pa, conveys devotion, early morning', N'S r g M P d n ?', N'? n d P M g r S'),
(N'Todi', N'King of all thaats, uses Komal Rishabh, Gandhar, Dhaivat, and Teevra Madhyam, late morning', N'S r g ? P d n ?', N'? n d P ? g r S');
SELECT * FROM Thatas

INSERT INTO Ragas 
([Name], [RaagaDesc1], [Jati], [TimeOfDay], [Mood], [Aroh], [Avroh], [Pakad], [Vadi], [Samvadi], [Nyasa], [ThaatID]) VALUES

-- Bilawal Thaat (1)
('Bhupali', 'Bright pentatonic morning raga.', 'Audav', 'Morning', 'Joyful', N'S R G P D ?', N'? D P G R S', N'G P D P G R S', 'G', 'D', 'R', 1),
('Alhaiya Bilaval', 'Bright and cheerful morning raga.', 'Sampoorna', 'Morning', 'Peaceful, joyful', N'S R G M P D N ?', N'? N D P M G R S', 'R G M P D M G R', 'G', 'D', 'S', 1),
('Bihag', 'Romantic and devotional.', 'Sampoorna', 'Evening', 'Serene, devotional', N'S G M P N ?', N'? N D P M G R S', 'M P D n D P M G R', 'P', 'S', 'N', 1),
('Durga', 'Simple and serene, evokes devotion.', 'Sampoorna', 'Morning', 'Calm', N'S R M P D ?', N'? D P M R S', 'M P D P M R', 'M', 'S', 'D', 1),
('Deshkar', 'Folk-inspired joyful raga.', 'Sampoorna', 'Afternoon', 'Cheerful', N'S R G M D P N ?', N'? N D P M G R S', 'G M P D N', 'G', 'D', 'S', 1),
('Shankara', 'Meditative and devotional.', 'Sampoorna', '2nd Prahar of the night (9 PM to 12 AM)', 'Devotion, Serene, Introspective', N'S R G M P D N ?', N'? N D P M G R S', N'? N P G P, R G R S', 'G', 'D', 'M', 1),

-- Kalyan Thaat (2)
('Yaman', 'Soothing and spiritual evening raga.', 'Sampoorna', 'Evening', 'Calm, devotional', N'N R G ? D N ?', N'? N D P ? G R S', N'R G ? D N S', N'?', 'S', 'D', 2),
('Hameer', 'Late evening dignified raga.', 'Sampoorna', 'Late Evening', 'Majestic', N'N R G ? P D N ?', N'? N D P ? G R S', N'P D N ?', 'P', 'N', 'D', 2),
('Kedar', 'Majestic and meditative.', 'Sampoorna', 'Evening', 'Meditative', N'S R M P N ?', N'? N D P M R S', N'M P N S', 'M', 'P', 'N', 2),
('Kamod', 'Joyful and lyrical.', 'Sampoorna', 'Late Night', 'Joyful', N'S R M P N ?', N'? N D P M R S', 'M P N S', 'M', 'P', 'S', 2),

-- Khamaj Thaat (3)
('Khamaj', 'Light romantic raga used in thumri.', 'Sampoorna', 'Evening', 'Romantic', N'S G M P D N ?', N'? N D P M G R S', 'D P M G R S', 'G', 'D', 'S', 3),
('Desh', 'Devotional and sentimental.', 'Sampoorna', 'Late Evening', 'Sentimental', N'S R G M P D n ?', N'? n D P M G R S', 'G P D P M G R', 'P', 'S', 'D', 3),
('Tilang', 'Soft and romantic.', 'Audav-Sampoorna', 'Evening', 'Soft', N'S G M P N ?', N'? N D P M G R S', 'G M P N S', 'G', 'P', 'N', 3),
('Jayjayanti', 'Lyrical and peaceful.', 'Sampoorna', 'Evening', NULL, N'S R G M P D N ?', N'? N D P M G R S', 'G M P N D', 'G', 'D', 'S', 3),
('Bageshri', 'Melancholic and romantic.', 'Audav', 'Midnight', 'Melancholic', N'S g M P d n ?', N'? n d P M g R S', 'M P d n S', 'D', 'M', 'S', 3),

-- Bhairav Thaat (4)
('Bhairav', 'Devotional morning raga.', 'Sampoorna', 'Morning', 'Devotional', N'S R g M P D n ?', N'? n D P M g R S', 'R g M P', 'R', 'P', 'M', 4),
('Ahir Bhairav', 'Meditative morning raga.', 'Sampoorna', 'Morning', 'Meditative', N'S R g M P D n ?', N'? n D P M g R S', 'R g M P', 'R', 'D', 'G', 4),
('Nat Bhairav', 'Austere and solemn.', 'Sampoorna', 'Morning', NULL, N'S R g M P D n ?', N'? n D P M g R S', 'R g M P', 'G', 'D', 'P', 4),
('Gauri', 'Serious and devotional.', 'Sampoorna', 'Morning', 'Devotional', N'S R g M P D n ?', N'? n D P M g R S', 'M P D n', 'M', 'D', 'N', 4),
('Jogiya', 'Solemn and meditative.', 'Sampoorna', 'Morning', 'Solemn', N'S R g M P d N ?', N'? N d P M g R S', 'M d N S', 'M', 'D', 'S', 4),

-- Poorvi Thaat (5)
('Poorvi', 'Serious evening raga.', 'Sampoorna', 'Evening', 'Serious', N'S R g ? P D n ?', N'? n D P ? g R S', '? P D n', '?', 'D', 'P', 5),
('Lalit', 'Strong evening raga.', 'Sampoorna', 'Evening', 'Strong', N'S R g ? P D N ?', N'? N D P ? g R S', 'R g ? D N', 'R', 'N', 'D', 5),
('Shree', 'Soulful and introspective.', 'Sampoorna', 'Evening', 'Serene', N'S R g ? P D n ?', N'? n D P ? g R S', '? P D n S', 'P', '?', 'N', 5),
('Paraj', 'Devotional.', 'Sampoorna', 'Evening', 'Devotional', N'S R g ? P D n ?', N'? n D P ? g R S', '? D n S', '?', 'D', 'N', 5),
('Puriya Dhanashri', 'Deeply meditative.', 'Sampoorna', 'Evening', 'Meditative', N'S R g ? P D n ?', N'? n D P ? g R S', '? D n S', '?', 'D', 'N', 5),

-- Marwa Thaat (6)
('Marwa', 'Nervous, tense evening raga.', 'Sampoorna', 'Evening', 'Tense', N'S R g ? P D N ?', N'? N D P ? g R S', 'R g ? P D', 'R', '?', 'N', 6),
('Sohini', 'Mysterious and delicate.', 'Sampoorna', 'Evening', 'Delicate', N'S R g ? P D N ?', N'? N D P ? g R S', 'D P ? R', 'D', '?', 'P', 6),
('Bhankar', 'Devotional and earnest.', 'Sampoorna', 'Evening', 'Devotional', N'S R g ? P D N ?', N'? N D P ? g R S', '? P D N', '?', 'D', 'N', 6),
('Puriya', 'Deep and complex.', 'Sampoorna', 'Evening', 'Complex', N'S R g ? P D N ?', N'? N D P ? g R S', 'R g ? P', 'R', '?', 'P', 6),
('Puriya Kalyan', 'Majestic and solemn.', 'Sampoorna', 'Evening', 'Solemn', N'S R g ? P D N ?', N'? N D P ? g R S', 'R g ? P', '?', 'D', 'P', 6),

-- Kafi Thaat (7)
('Kafi', 'Soft and romantic.', 'Sampoorna', 'Evening', 'Romantic', N'S R g M P D n ?', N'? n D P M g R S', 'P D n S', 'G', 'D', 'N', 7),
('Bageshri', 'Melancholic and emotive.', 'Sampoorna', 'Night', 'Melancholic', N'S g M P d n ?', N'? n d P M g R S', 'M P d n S', 'D', 'M', 'S', 7),
('Bhimpalasi', 'Lonely and yearning.', 'Sampoorna', 'Afternoon', 'Sentimental', N'S R g M P d n ?', N'? n d P M g R S', 'P M d n', 'D', 'G', 'S', 7),
('Peelu', 'Solace-bringing evening raga.', 'Sampoorna', 'Evening', NULL, N'S R g M P d n ?', N'? n d P M g R S', 'P D N S', 'G', 'D', 'S', 7),
('Bahar', 'Spring raga, joyous.', 'Sampoorna', 'Spring', 'Joyous', N'S R g M P d n ?', N'? n d P M g R S', 'P D n S', 'G', 'D', 'S', 7),

-- Asavari Thaat (8)
('Asavari', 'Somber and devotional raga.', 'Sampoorna', 'Morning', 'Devotional', N'S R g M P d n ?', N'? n d P M g R S', 'D n S D P M', 'D', 'G', 'S', 8),
('Jounpuri', 'Deep and serious.', 'Sampoorna', 'Evening', 'Deep', N'S R g M P d n ?', N'? n d P M g R S', 'n S D P M g', 'D', 'M', 'G', 8),
('Jaunpuri', 'Earnest and touching.', 'Sampoorna', 'Evening', 'Soulful', N'S R g M P d n ?', N'? n d P M g R S', 'D P M G R', 'D', 'M', 'G', 8),
('Sarang', 'Calm and devotion.', 'Sampoorna', 'Afternoon', 'Soothing', N'S R M P N ?', N'? N P M R S', 'R M P N S', 'M', 'P', 'N', 8),
('Malhiya', 'Expressive and devotional.', 'Sampoorna', 'Morning', 'Expressive', N'S R g M P d n ?', N'? n d P M g R S', 'D P M', 'D', 'G', 'M', 8),

-- Bhairavi Thaat (9)
('Bhairavi', 'Devotional early morning raga.', 'Sampoorna', 'Morning', 'Devotion', N'S r g M P d n ?', N'? n d P M g r S', 'd n S r g', 'S', 'P', 'M', 9),
('Malkauns', 'Solemn and meditative.', 'Sampoorna', 'Late Night', 'Meditative', N'S r g d N ?', N'? N d g r S', 'r g d N S', 'S', 'N', 'D', 9),
('Jogiya', 'Meditative and solemn.', 'Sampoorna', 'Morning', 'Solemn', N'S r g M d N ?', N'? N d M g r S', 'M d N S r', 'M', 'D', 'S', 9),
('Bageshri', 'Expressive and longing.', 'Audav', 'Midnight', 'Expressive', N'S g M P d n ?', N'? n d P M g R S', 'M P d n S', 'D', 'M', 'S', 9),
('Todi', 'Deep and complex.', 'Sampoorna', 'Late Morning', 'Complex', N'S r g ? P d N ?', N'? N d P ? g r S', 'r g ? d N S', 'D', 'S', 'N', 9),

-- Todi Thaat (10)
('Todi', 'Pathos and expression.', 'Sampoorna', 'Late Morning', 'Expressive', N'S r g ? P d N ?', N'? N d P ? g r S', 'r g ? d N S', 'D', 'S', 'N', 10),
('Bageshri Todi', 'Serious and emotional.', 'Sampoorna', 'Late Morning', 'Emotional', N'S r g ? P d N ?', N'? N d P ? g r S', '? d N S', '?', 'D', 'N', 10),
('Gujaari Todi', 'Contemplative.', 'Sampoorna', 'Late Morning', 'Contemplative', N'S r g ? P d N ?', N'? N d P ? g r S', 'r g ? d N', 'D', '?', 'S', 10),
('Hameer Todi', 'Solemn and grand.', 'Sampoorna', 'Evening', 'Majestic', N'S r g ? P d N ?', N'? N d P ? g r S', 'P D N S', 'P', 'D', '?', 10),
('Zilla Todi', 'Complex and evocative.', 'Sampoorna', 'Morning', NULL, N'S r g ? P d N ?', N'? N d P ? g r S', 'D P ? S', 'D', '?', 'S', 10);

SELECT * FROM Ragas;
