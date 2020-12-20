CREATE PROCEDURE sp_AddReminderItem
    @p_id UNIQUEIDENTIFIER,
    @p_datetime DATETIMEOFFSET,
    @p_statusid INT,
    @p_message NVARCHAR(512),
    @p_chatid VARCHAR(32)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @contactid UNIQUEIDENTIFIER
    SET @contactid = (SELECT Id FROM [Contact] WHERE [ChatId]=@p_chatid);

    IF @contactid IS NULL
    BEGIN
        SET @contactid = NEWID();
        INSERT INTO [Contact] (Id, ChatId) VALUES(@contactid, @p_chatid)
    END 

    INSERT INTO [ReminderItem] (Id, [DateTime], StatusId, [Message], ContactId, CreatedDateTime, ModifiedDateTime) 
    VALUES(@p_id, @p_datetime, @p_statusid, @p_message, @contactid, SYSDATETIMEOFFSET(), SYSDATETIMEOFFSET());
END 
GO


CREATE PROCEDURE sp_UpdateReminderItem
    @p_id UNIQUEIDENTIFIER,
    @p_statusid INT,
    @p_message NVARCHAR(512)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [ReminderItem]
    SET
        StatusId = @p_statusid,
        [Message] = @p_message,
        ModifiedDateTime = SYSDATETIMEOFFSET()
END 
GO


CREATE PROCEDURE sp_GetReminderItem(
    @p_id UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT 
        RI.Id,
        RI.DateTime,
        RI.StatusId AS Status,
        RI.Message,
        RC.ChatId AS ContactId
    FROM [ReminderItem] RI
    JOIN [ReminderContact] RC
        ON RI.ContactId = RC.Id
    WHERE RI.Id = @p_id
END
GO


CREATE PROCEDURE sp_FindBy(
    @p_datetime DATETIMEOFFSET,
    @p_statusid INT
)
AS
BEGIN
    DECLARE @query VARCHAR(300)
    SET @query = 'SELECT RI.Id, RI.DateTime, RI.StatusId AS Status, RI.Message, RC.ChatId AS ContactId FROM [ReminderItem] RI ';
    SET @query += 'JOIN [ReminderContact] RC ON RI.ContactId = RC.Id';

    IF @p_datetime IS NOT NULL OR @p_statusid IS NOT NULL
    BEGIN
        SET @query += ' WHERE';

        IF @p_datetime IS NOT NULL AND @p_statusid IS NOT NULL
            SET @query += ' RI.DateTime >= @datetime AND RI.StatusId = @status'
        ELSE
        BEGIN
            IF @p_datetime IS NOT NULL
                SET @query += ' RI.DateTime >= @datetime'
            
            IF @p_statusid IS NOT NULL
                SET @query += ' RI.StatusId = @status'
        END
    END

    EXECUTE(@query)
END
GO

