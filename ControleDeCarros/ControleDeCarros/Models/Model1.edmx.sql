
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/04/2017 19:42:33
-- Generated from EDMX file: C:\Users\JoãoPaulo\Source\Repos\AspNetAulas\ControleDeCarros\ControleDeCarros\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ControleCarros];
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

-- Creating table 'VeiculosSet'
CREATE TABLE [dbo].[VeiculosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Modelo] nvarchar(max)  NOT NULL,
    [AnoFab] int  NOT NULL,
    [AnoMod] int  NOT NULL,
    [Motor] nvarchar(max)  NOT NULL,
    [Cor] nvarchar(max)  NOT NULL,
    [ValorPago] float  NOT NULL,
    [Financiado] bit  NOT NULL,
    [CategoriasId] int  NOT NULL,
    [MarcasId] int  NOT NULL
);
GO

-- Creating table 'CategoriasSet'
CREATE TABLE [dbo].[CategoriasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MarcasSet'
CREATE TABLE [dbo].[MarcasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GastosSet'
CREATE TABLE [dbo].[GastosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] float  NOT NULL,
    [Data] datetime  NOT NULL,
    [SubTiposGastosId] int  NOT NULL,
    [VeiculosId] int  NOT NULL
);
GO

-- Creating table 'SubTiposGastosSet'
CREATE TABLE [dbo].[SubTiposGastosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [TiposGastosId] int  NOT NULL
);
GO

-- Creating table 'TiposGastosSet'
CREATE TABLE [dbo].[TiposGastosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VeiculosSet'
ALTER TABLE [dbo].[VeiculosSet]
ADD CONSTRAINT [PK_VeiculosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriasSet'
ALTER TABLE [dbo].[CategoriasSet]
ADD CONSTRAINT [PK_CategoriasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarcasSet'
ALTER TABLE [dbo].[MarcasSet]
ADD CONSTRAINT [PK_MarcasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GastosSet'
ALTER TABLE [dbo].[GastosSet]
ADD CONSTRAINT [PK_GastosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubTiposGastosSet'
ALTER TABLE [dbo].[SubTiposGastosSet]
ADD CONSTRAINT [PK_SubTiposGastosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TiposGastosSet'
ALTER TABLE [dbo].[TiposGastosSet]
ADD CONSTRAINT [PK_TiposGastosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TiposGastosId] in table 'SubTiposGastosSet'
ALTER TABLE [dbo].[SubTiposGastosSet]
ADD CONSTRAINT [FK_TiposGastosSubTiposGastos]
    FOREIGN KEY ([TiposGastosId])
    REFERENCES [dbo].[TiposGastosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiposGastosSubTiposGastos'
CREATE INDEX [IX_FK_TiposGastosSubTiposGastos]
ON [dbo].[SubTiposGastosSet]
    ([TiposGastosId]);
GO

-- Creating foreign key on [SubTiposGastosId] in table 'GastosSet'
ALTER TABLE [dbo].[GastosSet]
ADD CONSTRAINT [FK_GastosSubTiposGastos]
    FOREIGN KEY ([SubTiposGastosId])
    REFERENCES [dbo].[SubTiposGastosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastosSubTiposGastos'
CREATE INDEX [IX_FK_GastosSubTiposGastos]
ON [dbo].[GastosSet]
    ([SubTiposGastosId]);
GO

-- Creating foreign key on [VeiculosId] in table 'GastosSet'
ALTER TABLE [dbo].[GastosSet]
ADD CONSTRAINT [FK_VeiculosGastos]
    FOREIGN KEY ([VeiculosId])
    REFERENCES [dbo].[VeiculosSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VeiculosGastos'
CREATE INDEX [IX_FK_VeiculosGastos]
ON [dbo].[GastosSet]
    ([VeiculosId]);
GO

-- Creating foreign key on [CategoriasId] in table 'VeiculosSet'
ALTER TABLE [dbo].[VeiculosSet]
ADD CONSTRAINT [FK_VeiculosCategorias]
    FOREIGN KEY ([CategoriasId])
    REFERENCES [dbo].[CategoriasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VeiculosCategorias'
CREATE INDEX [IX_FK_VeiculosCategorias]
ON [dbo].[VeiculosSet]
    ([CategoriasId]);
GO

-- Creating foreign key on [MarcasId] in table 'VeiculosSet'
ALTER TABLE [dbo].[VeiculosSet]
ADD CONSTRAINT [FK_MarcasVeiculos]
    FOREIGN KEY ([MarcasId])
    REFERENCES [dbo].[MarcasSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarcasVeiculos'
CREATE INDEX [IX_FK_MarcasVeiculos]
ON [dbo].[VeiculosSet]
    ([MarcasId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------