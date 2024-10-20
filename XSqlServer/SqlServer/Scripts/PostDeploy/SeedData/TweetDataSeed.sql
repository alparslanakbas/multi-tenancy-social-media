IF NOT EXISTS(SELECT 1 FROM [dbo].[Tweets])
BEGIN
    INSERT INTO [dbo].[Tweets] (Id, UserId, Content, LikeCount, ViewCount, CreatedDate, ModifiedDate)
    VALUES
        (NEWID(), @userId1, 'This is Alparslan''s first tweet!', 10, 100, GETDATE(), NULL),
        (NEWID(), @userId2, 'Kayhan just posted his first tweet.', 5, 50, GETDATE(), NULL),
        (NEWID(), @userId1, 'Alparslan shares his second tweet.', 8, 80, GETDATE(), NULL),
        (NEWID(), @userId2, 'Kayhan is excited to tweet again!', 12, 150, GETDATE(), NULL);
END;
