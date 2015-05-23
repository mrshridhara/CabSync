CREATE TABLE [dbo].[RequestDays]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RequesterId] INT NOT NULL, 
    [DayOfWeek] NVARCHAR(12) NULL, 
    [LoginTime] TIME NULL, 
    [LogoutTime] TIME NULL, 
    CONSTRAINT [FK_RequestDays_ToRequesters] FOREIGN KEY ([RequesterId]) REFERENCES [Requesters]([Id])
)
