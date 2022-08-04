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
ORDER BY
    [Nome]
GO

--Tota de Categorias
SELECT 
    COUNT(*) AS [Total de Categorias]
FROM
    [Categoria]
GO

--Total de cursos por Categoria
SELECT
    [Categoria].[Id],
    [Categoria].[Nome],
    COUNT([Curso].[Id]) AS [Total de Cursos]
FROM
    [Categoria]
    INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY
    [Categoria].[Id],
    [Categoria].[Nome]
GO

--Menor Id em Curso
SELECT TOP 100
    MIN([Id]) AS [Primeiro Id de Curso]
FROM
    [Curso]
GO

--Maior Id em Curso
SELECT TOP 100
    MAX([Id]) AS [Ultimo Id de Curso]
FROM
    [Curso]
GO

-- Update
-- BEGIN TRANSACTION
    UPDATE 
        [Curso]
    SET 
        [Nome] = 'Sintax Básica SqlServe'
    WHERE
        [Curso].[Id] = 4
GO
-- ROLLBACK
SELECT * FROM vwCurso

-- Delete
DELETE FROM 
    [Curso]
WHERE
    [Id] = 4
GO

-- Nesse caso vai dar erro pois tem um referentecia de Chave Estrageira
DELETE FROM
    [Categoria]
WHERE
    [Id] = 4
GO

--Like
SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Nome] LIKE '%s' -- Termina com 
GO

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Nome] LIKE 'v%' -- Começa com 
GO

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Nome] LIKE '%ia%' -- Contem 
GO