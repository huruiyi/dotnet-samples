
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2022 16:41:55
-- Generated from EDMX file: D:\Work\Github\Programming-in-CSharp\CSharpExample\MVCDemo\MVC.Sample\Models\AuthorizationModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Permission_PermissionType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permission] DROP CONSTRAINT [FK_Permission_PermissionType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permission];
GO
IF OBJECT_ID(N'[dbo].[PermissionType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermissionType];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[UserPermission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserPermission];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Permission'
CREATE TABLE [dbo].[Permission] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(50)  NOT NULL,
    [PermissionTypeId] bigint  NOT NULL,
    [OrderNumer] int  NOT NULL,
    [IfDel] tinyint  NOT NULL,
    [IfValid] tinyint  NOT NULL
);
GO

-- Creating table 'PermissionType'
CREATE TABLE [dbo].[PermissionType] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Remark] nvarchar(200)  NOT NULL,
    [IfDel] tinyint  NOT NULL,
    [IfValid] tinyint  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] bigint  NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [JobNumber] nvarchar(50)  NOT NULL,
    [UserEmial] nvarchar(50)  NOT NULL,
    [IfDel] tinyint  NOT NULL,
    [IfValid] tinyint  NOT NULL
);
GO

-- Creating table 'UserPermission'
CREATE TABLE [dbo].[UserPermission] (
    [Id] bigint  NOT NULL,
    [UserId] bigint  NOT NULL,
    [PermissionsId] bigint  NOT NULL,
    [IfDel] tinyint  NOT NULL,
    [IfValid] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [PK_Permission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermissionType'
ALTER TABLE [dbo].[PermissionType]
ADD CONSTRAINT [PK_PermissionType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserPermission'
ALTER TABLE [dbo].[UserPermission]
ADD CONSTRAINT [PK_UserPermission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PermissionTypeId] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [FK_Permission_PermissionType]
    FOREIGN KEY ([PermissionTypeId])
    REFERENCES [dbo].[PermissionType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Permission_PermissionType'
CREATE INDEX [IX_FK_Permission_PermissionType]
ON [dbo].[Permission]
    ([PermissionTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------