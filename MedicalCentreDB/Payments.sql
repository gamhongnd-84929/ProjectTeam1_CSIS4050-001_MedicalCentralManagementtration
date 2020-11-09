CREATE TABLE [dbo].[Payments]
(
	[PaymentID] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CustomerID] INT NOT NULL, 
    [BookingID] INT NOT NULL, 
    [PaymentTypeID] INT NOT NULL, 
    [Time] TIME NULL, 
    [Date] NCHAR(10) NULL, 
    [TotalAmountPaid] DECIMAL NULL, 
    [PaymentStatus] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Payments_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([BookingID]), 
    CONSTRAINT [FK_Payments_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]), 
    CONSTRAINT [FK_Payments_Payment_Types] FOREIGN KEY ([PaymentTypeID]) REFERENCES [Payment_Types]([PaymentTypeID])
)
