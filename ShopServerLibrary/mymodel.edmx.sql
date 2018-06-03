-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2018 19:34:16
-- Generated from EDMX file: D:\DnetPrac5\ShopServerLibrary\mymodel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ShopDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductInventory1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventorySet] DROP CONSTRAINT [FK_ProductInventory1];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerInventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerSet] DROP CONSTRAINT [FK_CustomerInventory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[InventorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventorySet];
GO
IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [ProductId] INT NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [amount] int  NOT NULL
);
GO

-- Creating table 'InventorySet'
CREATE TABLE [dbo].[InventorySet] (
    [InventoryId] int NOT NULL,
    [Amount] bigint  NOT NULL,
    [ProductId] int  NOT NULL,
	[CustomerId] int not null
);
GO

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [CustomerId] int NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Balance] float  NOT NULL
   
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProductId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [InventoryId] in table 'InventorySet'
ALTER TABLE [dbo].[InventorySet]
ADD CONSTRAINT [PK_InventorySet]
    PRIMARY KEY CLUSTERED ([InventoryId] ASC);
GO

-- Creating primary key on [CustomerId] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductId] in table 'InventorySet'
ALTER TABLE [dbo].[InventorySet]
ADD CONSTRAINT [FK_ProductInventory1]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CustomerId] in table 'InventorySet'
ALTER TABLE [dbo].[InventorySet]
ADD CONSTRAINT [FK_CustomerInventory1]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[CustomerSet]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_ProductInventory1'
CREATE INDEX [IX_FK_ProductInventory1]
ON [dbo].[InventorySet]
    ([ProductId]);
GO



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------