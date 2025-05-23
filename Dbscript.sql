USE [InventoryDb]
GO
CREATE TABLE [dbo].[InventoryItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] varchar(20) NOT NULL,
	[Description] varchar(50) NULL,
	[Unit] varchar(5) NOT NULL,
	[Qty] decimal(10, 2) NOT NULL,
	[Price] decimal(10, 2) NOT NULL,
	[InventoryMasterId] int NOT NULL,
	[MasterId] int NOT NULL,
 CONSTRAINT [PK_InventoryItems] PRIMARY KEY(Id))
 GO


CREATE TABLE [dbo].[InventoryMasters](
	[Id] [int] NOT NULL,
	[Name] varchar(20) NOT NULL,
	[Description] varchar(50) NULL,
 CONSTRAINT [PK_InventoryMasters] PRIMARY KEY (Id))
GO

ALTER TABLE [dbo].[InventoryItems] ADD  DEFAULT ((0)) FOR [MasterId]
GO

ALTER TABLE [dbo].[InventoryItems]  WITH CHECK ADD  CONSTRAINT [FK_InventoryItems_InventoryMasters_InventoryMasterId] FOREIGN KEY([InventoryMasterId])
REFERENCES [dbo].[InventoryMasters] ([Id])
ON DELETE CASCADE
GO
