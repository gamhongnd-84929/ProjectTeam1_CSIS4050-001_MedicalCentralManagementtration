CREATE TABLE [dbo].[UserType]
(
	[UserTypeID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserType] VARCHAR(50) NOT NULL, 
    [UserTypeDescription] VARCHAR(100) NULL,
)
