CREATE DATABASE [Curso];
GO
DROP DATABASE [Curso];

-- DROP TABLE [Aluno]
CREATE TABLE [Aluno] (
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATETIME NULL,
    [Active] BIT DEFAULT(0) NOT NULL,
    
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email])
);
GO
SELECT * FROM [Aluno]
GO

ALTER TABLE [Aluno] 
    ADD [Document] NVARCHAR(11);
GO
ALTER TABLE [Aluno]
    DROP COLUMN [Document];
GO
ALTER TABLE [Aluno]
    ALTER COLUMN [Active] BIT NOT NULL;
GO

-- Deletar Database
USE [master];
DECLARE @kill varchar(8000) = '';
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id)
FROM sys.dm_exec_sessions
WHERE database_id = db_id('Curso')
EXEC(@kill);
DROP DATABASE [Curso]