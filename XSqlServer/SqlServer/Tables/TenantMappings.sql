CREATE TABLE [dbo].[TenantMappings]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [TenantId] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [FK_TenantMappings_UserId] FOREIGN KEY (UserId) REFERENCES [Users](Id)
)
