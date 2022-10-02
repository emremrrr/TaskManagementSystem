CREATE PROCEDURE [dbo].[spTask_Get]
	@id int 
AS
DECLARE @query NVARCHAR(MAX);
DECLARE @params NVARCHAR(MAX);

SET @params = N'@id int';

	SET @query= 'SELECT 
		t.Id,
		(Select min(ReminderDate) from comments where TaskId=t.Id)  NextActionDate,
		t.RequiredDate,
		t.TaskDescription,
		t.TaskStatus,
		t.TaskType,
		t.RequiredDate,
		t.AssignedTo,
		u.Id,
		CASE WHEN u.UserName IS NULL THEN ''Not assigned'' ELSE u.UserName END UserName
	FROM Tasks t
	LEFT JOIN Users u ON u.Id=t.AssignedTo
	WHERE t.Id=@id'

	EXECUTE sp_executesql @query, @params,@id ;
	exec spComments_Get @id,NULL
RETURN 0
