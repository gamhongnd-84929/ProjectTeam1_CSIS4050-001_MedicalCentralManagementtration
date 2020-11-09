CREATE TABLE [dbo].[Payment_Types]
(
	[PaymentTypeID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PaymentType] VARCHAR(50) NOT NULL, 
    [PaymentTypeDetail] VARCHAR(100) NULL
)
