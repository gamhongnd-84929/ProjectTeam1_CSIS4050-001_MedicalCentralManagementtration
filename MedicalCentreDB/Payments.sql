CREATE TABLE [dbo].[Payments]
(
	[PaymentID] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CustomerID] INT NOT NULL, 
    [BookingID] INT NOT NULL, 
    [PaymentTypeID] INT NOT NULL, 
    [Time] NVARCHAR(50) NOT NULL, 
    [Date] NVARCHAR(50) NOT NULL, 
    [TotalAmountPaid] DECIMAL(18, 2) NOT NULL, 
    [PaymentStatus] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Payments_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([BookingID]), 
    CONSTRAINT [FK_Payments_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]), 
    CONSTRAINT [FK_Payments_Payment_Types] FOREIGN KEY ([PaymentTypeID]) REFERENCES [Payment_Types]([PaymentTypeID])
)
