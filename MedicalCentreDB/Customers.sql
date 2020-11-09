CREATE TABLE [dbo].[Customers]
(
	[CustomerID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [BirthDate] DATE NULL, 
    [LoginID] INT NOT NULL, 
    [Address] VARCHAR(50) NULL, 
    [City] VARCHAR(50) NULL, 
    [Province] VARCHAR(50) NULL, 
    [PostalCode] VARCHAR(50) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [MSP] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Customers_LoginInfo] FOREIGN KEY ([LoginID]) REFERENCES [LoginInfo]([LoginID])
)
