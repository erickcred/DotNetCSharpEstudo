USE [Course]
GO

CREATE OR ALTER VIEW vwCourses AS
    SELECT
        [Course].[Id],
        [Course].[CreateDate],
        [Course].[Tag],
        [Author].[Name] AS [Author],
        [Category].[Title] AS [Category],
        [Course].[Title],
        [Course].[Url],
        [Course].[Summary]
    FROM
        [Course]
        INNER JOIN [Category] ON [Course].[CategoryId] = [Category].[Id]
        INNER JOIN [Author] ON [Course].[AuthorId] = [Author].[Id]
    WHERE
        [Active] = 1
GO

CREATE OR ALTER VIEW vwCareers AS
    SELECT
        [Career].[Id],
        [Career].[Title],
        [Career].[Url],
        COUNT([CareerItem].[CourseId]) AS [Total Courses]
    FROM
        [Career]
        INNER JOIN [CareerItem] ON [Career].[Id] = [CareerItem].[CareerId]
    GROUP BY
        [Career].[Id],
        [Career].[Title],
        [Career].[Url]
GO

SELECT * FROM vwCareers
GO
SELECT * FROM [Course]
GO
SELECT * FROM [Student]
GO
SELECT * FROM [StudentCourse]
GO

-- INSERT INTO
--     [Student] ([Id], [Name], [Email], [Document], [Phone], [Birthdate], [CreateDate])
-- VALUES
--     ('7ba36361-3f24-4c21-9a24-915674037e71', 'Fulano da Silva', 'fulano@gmail.com', null, null, null, GETDATE()),
--     ('cc8cf1b7-7671-4595-a519-610e2a74b167', 'Siclano de Oliveira', 'siclano@gmail.com', null, null, null, GETDATE())
-- GO
-- INSERT INTO
--     [StudentCourse] ([CourseId], [StudentId], [Progress], [Favorite], [StartDate], [LastUpdateDate])
-- VALUES
--     ('5d8cf396-e717-9a02-2443-021b00000000', 'cc8cf1b7-7671-4595-a519-610e2a74b167', 50, 0, GETDATE(), NULL),
--     ('5c349848-e717-9a7d-1241-0e6500000000', '7ba36361-3f24-4c21-9a24-915674037e71', 10, 1, GETDATE(), NULL)
-- GO

CREATE OR ALTER VIEW vwStudentsProgress AS
    SELECT TOP 100
        [StudentCourse].[StartDate],
        [Student].[Name] AS [Student],
        [Course].[Title] AS [Course],
        [StudentCourse].[Progress]
    FROM
        [StudentCourse]
        INNER JOIN [Course] ON [Course].[Id] = [StudentCourse].[CourseId]
        INNER JOIN [Student] ON [Student].[Id] = [StudentCourse].[StudentId]
GO


DECLARE @StudentId UNIQUEIDENTIFIER = '7ba36361-3f24-4c21-9a24-915674037e71'
SELECT TOP 100
    [StudentCourse].[StartDate],
    [Student].[Name],
    [Course].[Title],
    [StudentCourse].[Progress]
FROM
    [StudentCourse]
    INNER JOIN [Course] ON [Course].[Id] = [StudentCourse].[CourseId]
    INNER JOIN [Student] ON [Student].[Id] = [StudentCourse].[StudentId]
WHERE
    [StudentCourse].[StudentId] = @StudentId
    AND [StudentCourse].[Progress] < 100
    AND [StudentCourse].[Progress] > 0
GO