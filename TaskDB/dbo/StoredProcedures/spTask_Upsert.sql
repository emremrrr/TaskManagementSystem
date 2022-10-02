CREATE PROCEDURE [dbo].[spTask_Upsert]
	@id int = 0,
	@created datetime2(7) ,
	@requiredDate datetime2(7),
	@taskStatus int,
	@taskType int,
	@assignedTo int,
	@taskDescription nvarchar(MAX)
AS
	IF NOT EXISTS (SELECT 1 FROM Tasks WHERE Id=@id)
		BEGIN
			INSERT INTO Tasks (Created,RequiredDate,TaskStatus,TaskType,AssignedTo,TaskDescription)
			VALUES (@created,@requiredDate,@taskStatus,@taskType,@assignedTo,@taskDescription)
		END
	ELSE
		BEGIN
			UPDATE Tasks SET 
				RequiredDate=@requiredDate,
				TaskStatus=@taskStatus,
				TaskType=@taskType,
				AssignedTo=@assignedTo,
				TaskDescription=@taskDescription
			WHERE Id=@id
		END
RETURN 0
