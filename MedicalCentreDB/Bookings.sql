CREATE TABLE [dbo].[Bookings]
(
	[BookingID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CustomerID] INT NOT NULL, 
    [PractitionerID] INT NOT NULL, 
    [Time] TIME NOT NULL, 
    [Date] DATE NOT NULL, 
    [PractitionerComment] TEXT NULL, 
    [BookingPrice] DECIMAL NOT NULL, 
    [BookingStatus] INT NOT NULL, 
    CONSTRAINT [FK_Bookings_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]), 
    CONSTRAINT [FK_Bookings_Practitioners] FOREIGN KEY ([PractitionerID]) REFERENCES [Practitioners]([PractitionerID])
)
