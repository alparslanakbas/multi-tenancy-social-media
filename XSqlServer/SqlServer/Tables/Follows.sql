CREATE TABLE [dbo].[Follows]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FollowerUserId] UNIQUEIDENTIFIER NULL, 
    [FollowingUserId] UNIQUEIDENTIFIER NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [FK_Follows_FollowerUserId] FOREIGN KEY (FollowerUserId) REFERENCES [Users](Id),
    CONSTRAINT [FK_Follows_FollowingUserId] FOREIGN KEY (FollowingUserId) REFERENCES [Users](Id)
)
