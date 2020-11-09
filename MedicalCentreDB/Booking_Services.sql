CREATE TABLE [dbo].[Booking_Services]
(
	[ServiceID] INT NOT NULL, 
    [BookingID] INT NOT NULL,
	CONSTRAINT [PK_Booking_Services] PRIMARY KEY CLUSTERED ([ServiceID] ASC, [BookingID] ASC),
	CONSTRAINT [FK_Booking_Services_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([BookingID]) ON DELETE CASCADE,
	CONSTRAINT [FK_Booking_Services_Services] FOREIGN KEY ([ServiceID]) REFERENCES [Services]([ServiceID]) ON DELETE CASCADE
	
)
