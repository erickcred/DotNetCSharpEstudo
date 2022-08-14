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

select NEWID()

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
-- UPDATE
--     [StudentCourse]
-- SET
--     [LastUpdateDate] = '2022-20-07'
-- WHERE
--     [StudentCourse].[StudentId] = 'cc8cf1b7-7671-4595-a519-610e2a74b167'
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

-- Progreasso do aluno 
CREATE OR ALTER PROC [spStudentProgress] (
    @StudentId UNIQUEIDENTIFIER
)
AS
SELECT TOP 100
    [StudentCourse].[StartDate],
    [StudentCourse].[LastUpdateDate] AS [Last Access],
    [Student].[Name] AS [Student],
    [Course].[Title] AS [Course],
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
EXEC [spStudentProgress] '7ba36361-3f24-4c21-9a24-915674037e71'

-- Listando cursos mesmo sem alunos
SELECT TOP 100
    [Student].[Name] AS [Student],
    [Course].[Title] AS [Course],
    [StudentCourse].[Progress] AS [Progress],
    [StudentCourse].[LastUpdateDate] AS [Las Access]
FROM
    [Course]
    LEFT JOIN [StudentCourse] ON [StudentCourse].[CourseId] = [Course].[Id]
    LEFT JOIN [Student] ON [Student].[Id] = [StudentCourse].[StudentId]
GO


-- Excluindo conta do aluno
CREATE OR ALTER PROCEDURE [spDeleteStudent] (
    @StudentId UNIQUEIDENTIFIER
)
AS
-- DECLARE @StudentId UNIQUEIDENTIFIER = '7ba36361-3f24-4c21-9a24-915674037e71'
BEGIN TRANSACTION
    DELETE FROM
        [StudentCourse]
    WHERE
        [StudentId] = @StudentId
    DELETE FROM
        [Student]
    WHERE
        [Id] = @StudentId
COMMIT
GO
EXEC [spDeleteStudent] '7ba36361-3f24-4c21-9a24-915674037e71'

select * from [Category]
GO

CREATE OR ALTER PROC [spGetCourseByCategory]
    @Categoryid UNIQUEIDENTIFIER
AS
    SELECT * FROM [Course] WHERE [CategoryId] = @Categoryid
GO

EXEC [spGetCourseByCategory] 'af3407aa-11ae-4621-a2ef-2028b85507c4'GO


CREATE OR ALTER VIEW [vwListCategories] AS
    SELECT
        *
    FROM
        [Category]
GO
SELECT * FROM [vwListCategories]






SELECT
    *
FROM
    [Career]
    INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
WHERE
    [Career].[Title] LIKE '%Front%'