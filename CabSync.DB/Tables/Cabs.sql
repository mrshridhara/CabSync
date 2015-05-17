CREATE TABLE [dbo].[Cabs]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [RegistrationNumber] NVARCHAR(12) NULL, 
    [DriverId] INT NULL, 
    [DepotLocationId] INT NULL, 
    CONSTRAINT [FK_Cabs_ToDrivers] FOREIGN KEY ([DriverId]) REFERENCES [Drivers]([Id]), 
    CONSTRAINT [FK_Cabs_ToPointOfInterests] FOREIGN KEY ([DepotLocationId]) REFERENCES [PointOfInterests]([Id])
)
