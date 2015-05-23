CREATE TABLE [dbo].[PointOfInterests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NULL, 
    [Coordinates] NVARCHAR(50) NULL
)
