CREATE TABLE [dbo].[TripsRequesters]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TripId] INT NOT NULL, 
    [RequesterId] INT NOT NULL, 
    CONSTRAINT [FK_TripsRequesters_ToTrips] FOREIGN KEY ([TripId]) REFERENCES [Trips]([Id]), 
    CONSTRAINT [FK_TripsRequesters_ToRequesters] FOREIGN KEY ([RequesterId]) REFERENCES [Requesters]([Id])
)
