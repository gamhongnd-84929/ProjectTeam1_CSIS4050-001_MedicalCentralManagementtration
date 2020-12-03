CREATE TABLE [dbo].[Users]
(
	[UserID] INT NOT NULL  IDENTITY(1,1),
	[FirstName] VARCHAR(50) NOT NULL, 
    [Birthdate] DATE  NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(50) NULL, 
    [City] VARCHAR(50) NULL, 
    [Province] VARCHAR(50) NULL, 
    [PostalCode] VARCHAR(50) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
     CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC),
)
