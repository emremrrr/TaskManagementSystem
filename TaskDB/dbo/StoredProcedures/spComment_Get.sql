CREATE PROCEDURE [dbo].[spComment_Get]
	@taskId int,
	@id int
AS
	SELECT 
		c.Id,
		c.CommentType,
		c.CommentText,
		c.ReminderDate,
		c.CreatedBy,
		u.Id,
		u.UserName UserName

	FROM Comments c
	INNER JOIN Users u ON  u.Id=c.CreatedBy
	WHERE c.TaskId=@taskId 
		AND c.Id=@id
RETURN 0