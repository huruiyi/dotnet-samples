
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/23/2017 18:01:13
-- Generated from EDMX file: D:\git\Programming\Programming-in-CSharp\CSharpExample\CSharpBasic\EFDemo\ExampleDbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ExampleDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MovieInfo_MovieType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieInfo] DROP CONSTRAINT [FK_MovieInfo_MovieType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Lxrenb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lxrenb];
GO
IF OBJECT_ID(N'[dbo].[Lxrenlbb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lxrenlbb];
GO
IF OBJECT_ID(N'[dbo].[MovieInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieInfo];
GO
IF OBJECT_ID(N'[dbo].[MovieType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Lxrenb'
CREATE TABLE [dbo].[Lxrenb] (
    [lxrenbh] int IDENTITY(1,1) NOT NULL,
    [xm] varchar(50)  NULL,
    [lbdm] tinyint  NULL,
    [sjhm] varchar(50)  NULL,
    [qq] varchar(50)  NULL,
    [xmsx] varchar(50)  NULL
);
GO

-- Creating table 'Lxrenlbb'
CREATE TABLE [dbo].[Lxrenlbb] (
    [lbdm] int IDENTITY(1,1) NOT NULL,
    [lbmc] varchar(50)  NULL
);
GO

-- Creating table 'MovieInfo'
CREATE TABLE [dbo].[MovieInfo] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Price] decimal(8,2)  NOT NULL,
    [MovieTypeId] bigint  NOT NULL
);
GO

-- Creating table 'MovieType'
CREATE TABLE [dbo].[MovieType] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [OrderNum] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [lxrenbh] in table 'Lxrenb'
ALTER TABLE [dbo].[Lxrenb]
ADD CONSTRAINT [PK_Lxrenb]
    PRIMARY KEY CLUSTERED ([lxrenbh] ASC);
GO

-- Creating primary key on [lbdm] in table 'Lxrenlbb'
ALTER TABLE [dbo].[Lxrenlbb]
ADD CONSTRAINT [PK_Lxrenlbb]
    PRIMARY KEY CLUSTERED ([lbdm] ASC);
GO

-- Creating primary key on [Id] in table 'MovieInfo'
ALTER TABLE [dbo].[MovieInfo]
ADD CONSTRAINT [PK_MovieInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovieType'
ALTER TABLE [dbo].[MovieType]
ADD CONSTRAINT [PK_MovieType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MovieTypeId] in table 'MovieInfo'
ALTER TABLE [dbo].[MovieInfo]
ADD CONSTRAINT [FK_MovieInfo_MovieType]
    FOREIGN KEY ([MovieTypeId])
    REFERENCES [dbo].[MovieType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieInfo_MovieType'
CREATE INDEX [IX_FK_MovieInfo_MovieType]
ON [dbo].[MovieInfo]
    ([MovieTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------