CREATE TABLE [dbo].[Practitioners]
(
	[PractitionerID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [LoginID] INT NOT NULL, 
    [TypeID] INT NOT NULL, 
    [Address] VARCHAR(50) NULL, 
    [City] VARCHAR(50) NULL, 
    [Province] VARCHAR(50) NULL, 
    [PostalCode] VARCHAR(50) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Practitioners_LoginInfo] FOREIGN KEY ([LoginID]) REFERENCES [LoginInfo]([LoginID]), 
    CONSTRAINT [FK_Practitioners_Practitioner_Types] FOREIGN KEY ([TypeID]) REFERENCES [Practitioner_Types]([TypeID])
)
