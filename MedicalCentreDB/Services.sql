CREATE TABLE [dbo].[Services]
(
	[ServiceID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ServiceName] VARCHAR(50) NOT NULL, 
    [ServiceDescription] VARCHAR(50) NULL, 
    [ServicePrice] DECIMAL(18, 2) NOT NULL, 
    [PractitionerTypeID] int NOT NULL, 
    [MSPCoverage] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_Services_Practitioner_Types] FOREIGN KEY ([PractitionerTypeID]) REFERENCES [Practitioner_Types]([TypeID])
)
