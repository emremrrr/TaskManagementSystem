CREATE PROCEDURE [dbo].[spComments_Get]
	@taskId int,
	@searchText NVARCHAR(MAX)
AS

	DECLARE @query NVARCHAR(MAX)
	DECLARE @params NVARCHAR(MAX);

	
	SET @query=
	'SELECT 
		c.Id,
		c.CommentType,
		c.CommentText,
		c.ReminderDate,
		c.CreatedBy,
		u.Id,
		u.UserName UserName

	FROM Comments c
	INNER JOIN Users u ON  u.Id=c.CreatedBy
	WHERE c.TaskId=@taskId'

	IF(@searchText IS NOT NULL)
	BEGIN
		SET @query=@query+
		' AND CHARINDEX(@searchText, c.CommentText)>0'
		SET @params = N'@taskId INT, @searchText NVARCHAR';
		EXECUTE sp_executesql @query, N'@taskId INT, @searchText NVARCHAR' ,@taskId, @searchText
	END
	ELSE
	BEGIN
		SET @params = N'@taskId INT';
		EXECUTE sp_executesql @query, @params ,@taskId
	END

RETURN 0
