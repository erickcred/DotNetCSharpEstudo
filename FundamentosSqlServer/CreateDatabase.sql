-- CREATE DATABASE [Cursos]
-- GO

USE [Cursos]
GO

CREATE TABLE [Categoria] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
);
GO

CREATE TABLE [Curso] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([Id])
);
GO

-- Inserts --
-- INSERT INTO [Categoria] ([Nome]) VALUES
-- ('Fundamentos C#'),
-- ('Fundamentos OOP'),
-- ('Fundamentos .NET'),
-- ('Fundamentos SqlServer')
-- GO
SELECT top 100 * FROM [Categoria]

-- INSERT INTO [Curso] ([Nome], [CategoriaId]) VALUES
-- ('Variaveis', 1),
-- ('Strings', 1),
-- ('Pilares da OOP', 2),
-- ('Sintax basíca Sql', 4),
-- ('Criando Views', 4)
-- GO
SELECT TOP 100 * FROM [Curso]

-- Selects e Views --
CREATE OR ALTER VIEW vwCurso AS
    SELECT
        [Curso].[Id],
        [Curso].[Nome],
        [Categoria].[Nome] AS [Categoria]
    FROM
        [Curso]
        INNER JOIN [Categoria] ON [Categoria].[Id] = [Curso].[Id]
GO
SELECT * from vwCurso

SELECT TOP 100
    [Id], [Nome], [CategoriaId]
FROM
    [Curso]
WHERE
    -- [CategoriaId] = 1 OR
    [CategoriaId] IS NOT NULL
GO