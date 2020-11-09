CREATE TABLE [dbo].[LoginInfo]
(
	[LoginID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserName] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [NeedsChanged] TINYINT NOT NULL, 
    [UserTypeID] INT NOT NULL, 
    CONSTRAINT [FK_LoginInfo_UserType] FOREIGN KEY ([UserTypeID]) REFERENCES [UserType]([UserTypeID])
)
