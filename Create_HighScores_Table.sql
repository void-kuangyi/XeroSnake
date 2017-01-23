CREATE TABLE HighScores (
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
GameType VARCHAR(13) NOT NULL CHECK (GameType IN('Basic', 'Intermediate', 'Advanced')),
Score INT NOT NULL,
Name NVARCHAR(50)
)
GO