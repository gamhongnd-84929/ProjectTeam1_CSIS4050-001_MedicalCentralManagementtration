CREATE TABLE [dbo].[Practitioners]
(
	[PractitionerID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserID] INT NOT NULL, 
    [TypeID] INT NOT NULL, 
    CONSTRAINT [FK_Practitioners_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID]), 
    CONSTRAINT [FK_Practitioners_Practitioner_Types] FOREIGN KEY ([TypeID]) REFERENCES [Practitioner_Types]([TypeID])
)
