
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2017 21:59:13
-- Generated from EDMX file: D:\git\Programming-in-CSharp\CSharpExample\CSharpBasic\EFDemo\TXGLModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Lxrenb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lxrenb];
GO
IF OBJECT_ID(N'[dbo].[Lxrenlbb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lxrenlbb];
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------