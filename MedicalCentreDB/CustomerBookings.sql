CREATE TABLE [dbo].[CustomerBookings]
(
	[CustomerID] INT NOT NULL, 
    [BookingID] INT NOT NULL,
	 CONSTRAINT [PK_CustomerBookings] PRIMARY KEY CLUSTERED ([CustomerID] ASC, [BookingID] ASC),
	CONSTRAINT [FK_CustomerBookings_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]) ON DELETE CASCADE,
	CONSTRAINT [FK_CustomerBookings_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([BookingID]) ON DELETE CASCADE,


)
