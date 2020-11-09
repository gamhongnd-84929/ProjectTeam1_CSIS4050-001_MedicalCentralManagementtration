CREATE TABLE [dbo].[Admins]
(
	[AdminID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [LoginID] INT NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Admins_LoginInfo] FOREIGN KEY ([LoginID]) REFERENCES [LoginInfo]([LoginID])
)
