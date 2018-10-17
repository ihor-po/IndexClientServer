
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2018 16:23:42
-- Generated from EDMX file: C:\Users\sobik\iCloudDrive\Step\NetworkProg\DZ\DZ1\server_une\Address_db.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Address];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PostIndex'
CREATE TABLE [dbo].[PostIndex] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PostI] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocalAddress] nvarchar(max)  NOT NULL,
    [PostIndexId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PostIndex'
ALTER TABLE [dbo].[PostIndex]
ADD CONSTRAINT [PK_PostIndex]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PostIndexId] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [FK_AddressPostIndex]
    FOREIGN KEY ([PostIndexId])
    REFERENCES [dbo].[PostIndex]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressPostIndex'
CREATE INDEX [IX_FK_AddressPostIndex]
ON [dbo].[Address]
    ([PostIndexId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

INSERT INTO dbo.PostIndex VALUES
('50000'),('50041'),('50054'),
('50040'),('50025'),('50007'),
('50034'),('50048'),('50022');

INSERT INTO dbo.Address VALUES
(   '�����������', 1),(   '���������� (����.)', 1),(   '��������', 1),(   '�������� ������', 1),
(   '��������', 2),(   '����������', 2),(   '����������', 2),
(   '����������', 3),(   '�������', 3),
(   '�����������', 4),(   '�������', 4),
(   '���������', 5),(   '���������', 5),(   '�������', 5),
(   '���������', 6),
(   '��������', 7),(   '������', 7),(   '������������', 7),(   '��������', 7),(   '����-��������', 7),
(   '����', 8),(   '���������', 8),(   '���������', 8),
(   '�������������', 9);