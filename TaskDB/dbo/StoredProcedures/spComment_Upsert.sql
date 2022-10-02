CREATE PROCEDURE [dbo].[spComment_Upsert]
	@id int = 0,
	@created datetime2(7) ,
	@reminderDate datetime2(7),
	@commentType int,
	@commentText nvarchar(MAX),
	@taskId int,
	@createdBy int
AS
	IF NOT EXISTS (SELECT 1 FROM Comments WHERE Id=@id)
		BEGIN
			INSERT INTO Comments (Created,ReminderDate,CommentType,CommentText,TaskId,CreatedBy)
			VALUES (@created,@reminderDate,@commentType,@commentText,@taskId,@createdBy)
		END
	ELSE
		BEGIN
			UPDATE Comments SET 
				ReminderDate=@reminderDate,
				CommentText=@commentText,
				CommentType=@commentType
			WHERE Id=@id
		END
RETURN 0
