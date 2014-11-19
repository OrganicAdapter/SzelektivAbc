
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 11/15/2014 11:31:13
-- Generated from EDMX file: e:\GitHub\SzelektivABC\SzelektivABC\Models\ProductModels.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Items'
CREATE TABLE [Items] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL,
    [Description] nvarchar(4000)  NOT NULL,
    [Image] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'Pictograms'
CREATE TABLE [Pictograms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(4000)  NOT NULL,
    [Image] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'ItemPictogram'
CREATE TABLE [ItemPictogram] (
    [Items_Id] int  NOT NULL,
    [Pictograms_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Items'
ALTER TABLE [Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'Pictograms'
ALTER TABLE [Pictograms]
ADD CONSTRAINT [PK_Pictograms]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Items_Id], [Pictograms_Id] in table 'ItemPictogram'
ALTER TABLE [ItemPictogram]
ADD CONSTRAINT [PK_ItemPictogram]
    PRIMARY KEY ([Items_Id], [Pictograms_Id] );
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Items_Id] in table 'ItemPictogram'
ALTER TABLE [ItemPictogram]
ADD CONSTRAINT [FK_ItemPictogram_Item]
    FOREIGN KEY ([Items_Id])
    REFERENCES [Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pictograms_Id] in table 'ItemPictogram'
ALTER TABLE [ItemPictogram]
ADD CONSTRAINT [FK_ItemPictogram_Pictogram]
    FOREIGN KEY ([Pictograms_Id])
    REFERENCES [Pictograms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemPictogram_Pictogram'
CREATE INDEX [IX_FK_ItemPictogram_Pictogram]
ON [ItemPictogram]
    ([Pictograms_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------