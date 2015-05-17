CREATE TABLE [dbo].[Requesters]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL,
	[LastName] NVARCHAR(50) NULL, 
    [PhoneNo] NVARCHAR(10) NULL, 
    [RegistrationId] NVARCHAR(36) NULL, 
    [NodalPointId] INT NULL, 
    [UserId] NVARCHAR(10) NULL, 
    CONSTRAINT [FK_Requesters_ToPointOfInterests] FOREIGN KEY (NodalPointId) REFERENCES [PointOfInterests]([Id])
)
