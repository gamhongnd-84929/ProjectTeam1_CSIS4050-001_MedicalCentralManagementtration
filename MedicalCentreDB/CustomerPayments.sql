CREATE TABLE [dbo].[CustomerPayments]
(
	[CustomerID] INT NOT NULL , 
    [PaymentID] int NOT NULL , 
    CONSTRAINT [PK_CustomerPayments] PRIMARY KEY CLUSTERED ([CustomerID] ASC, [PaymentID] ASC),
    CONSTRAINT [FK_CustomerPayments_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]), 
    CONSTRAINT [FK_CustomerPayments_Payments] FOREIGN KEY ([PaymentID]) REFERENCES [Payments]([PaymentID]),


)
