CREATE TABLE [dbo].[Trips]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CabId] INT NULL, 
    [StartDateTime] DATETIME NULL, 
    [EndDateTime] DATETIME NULL, 
    [TripType] NVARCHAR(10) NULL, 
    CONSTRAINT [FK_Trips_ToCabs] FOREIGN KEY ([CabId]) REFERENCES [Cabs]([Id]) 
)
