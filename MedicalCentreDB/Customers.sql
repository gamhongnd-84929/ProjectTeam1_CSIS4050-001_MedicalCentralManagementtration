CREATE TABLE [dbo].[Customers]
(
	[CustomerID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),  
    [UserID] INT NOT NULL, 
    [MSP] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Customers_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([UserID])
)
