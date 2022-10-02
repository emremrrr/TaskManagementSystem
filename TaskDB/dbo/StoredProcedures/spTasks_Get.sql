CREATE PROCEDURE [dbo].[spTasks_Get]

AS
	SELECT 
		t.Id,
		t.TaskStatus,
		LEFT(t.TaskDescription,50) TaskDescription,
		t.RequiredDate,
		t.AssignedTo,
		u.Id,
		CASE WHEN u.UserName IS NULL THEN 'Not assigned' ELSE u.UserName END UserName
	FROM Tasks T
	LEFT JOIN Users u ON U.Id=t.AssignedTo
RETURN 0
