CREATE TABLE [dbo].[Tweets]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Content] NVARCHAR(1000) NOT NULL, 
    [LikeCount] INT NULL, 
    [ViewCount] INT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [FK_Tweets_UserId] FOREIGN KEY (UserId) REFERENCES [Users](Id)
)
