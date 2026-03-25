CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Categories (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Courses (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    CategoryId UNIQUEIDENTIFIER,
    InstructorId UNIQUEIDENTIFIER,
    ThumbnailUrl NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (InstructorId) REFERENCES Users(Id)
);

CREATE TABLE Attempts (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER,
    CourseId UNIQUEIDENTIFIER,
    Score DECIMAL(5,2),
    Progress INT,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

CREATE PROCEDURE sp_CreateCourse
    @Id UNIQUEIDENTIFIER,
    @Title NVARCHAR(200),
    @Description NVARCHAR(MAX),
    @CategoryId UNIQUEIDENTIFIER,
    @InstructorId UNIQUEIDENTIFIER,
    @ThumbnailUrl NVARCHAR(255),
    @CreatedAt DATETIME
AS
BEGIN
    INSERT INTO Courses (Id,Title, Description, CategoryId, InstructorId, ThumbnailUrl, CreatedAt)
    VALUES (@Id, @Title, @Description, @CategoryId, @InstructorId, @ThumbnailUrl, @CreatedAt)
END


CREATE PROCEDURE sp_GetLeaderboard
AS
BEGIN
    SELECT 
        c.Name AS Category,
        u.Id,
        u.FirstName,
        u.LastName,
        MAX(a.Score) AS TopScore
    FROM Attempts a
    JOIN Users u ON a.UserId = u.Id
    JOIN Courses co ON a.CourseId = co.Id
    JOIN Categories c ON co.CategoryId = c.Id
    GROUP BY c.Name, u.Id, u.FirstName, u.LastName
    ORDER BY c.Name, TopScore DESC
END

INSERT INTO Categories (Name)
VALUES 
('Programming'),
('Data Science'),
('Design'),
('Business'),
('DevOps');

BULK INSERT dbo.Users
FROM 'C:\temp\USER_MOCK_DATA.csv'
WITH (
    FIRSTROW = 2,           
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n', 
    CODEPAGE = '65001',
    TABLOCK
);