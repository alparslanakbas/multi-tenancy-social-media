DECLARE 
    @userId1 UNIQUEIDENTIFIER = 'CA3990A0-6070-4BB2-A749-1FBCF9314F56',
    @userId2 UNIQUEIDENTIFIER = '46D0527F-4160-4C8D-933A-540A2B23E4F0';

IF NOT EXISTS(SELECT 1 FROM [dbo].[Users])
BEGIN
    INSERT INTO [dbo].[Users] (Id, CreatedDate, UserName, EmailAddress, Password)
    VALUES
        (@userId1, GETDATE(), 'alparslanakbas', 'bybluestht@gmail.com', 'password123'),
        (@userId2, GETDATE(), 'kayhanakbas', 'alparslanayt@gmail.com', 'password1234');
END;
