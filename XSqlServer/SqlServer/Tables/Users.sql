CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(1000) NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [CreatedDate] DATETIME NOT NULL
)
