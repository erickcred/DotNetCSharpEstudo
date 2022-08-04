-- CREATE DATABASE [Curso]
-- GO

USE [Curso]
GO

-- DROP TABLE [Aluno]
CREATE TABLE [Aluno] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATETIME NULL,
    [Active] BIT DEFAULT(0) NOT NULL,
    
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email])
);
GO
SELECT TOP 100 * FROM [Aluno]
GO

-- Index
-- DROP INDEX [IX_Aluno_Email] ON [Aluno]
CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])
CREATE INDEX [IX_Aluno_Nome] ON [Aluno]([Nome])

-- DROP TABLE [Categoria]
CREATE TABLE [Categoria] (
    [Id] INT NOT NULL IDENTITY,
    [Nome] NVARCHAR(100),

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
);
GO
SELECT TOP 100 * FROM [Categoria]
GO

-- DROP TABLE [Curso]
CREATE TABLE [Curso] (
    [Id] INT  NOT NULL IDENTITY,
    [Nome] NVARCHAR(100) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([Id])
);
GO
SELECT TOP 100 * FROM [Curso]
GO

-- DROP TABLE [ProgressoCurso]
CREATE TABLE [ProgressoCurso] (
    [AlunoId] INT NOT NULL,
    [CursoId] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_ProgressoCurso] PRIMARY KEY([AlunoId], [CursoId])
);
GO
SELECT TOP 100 * FROM  [ProgressoCurso]
GO