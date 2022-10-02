CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Created] DATETIME2 NOT NULL, 
    [RequiredDate] DATETIME2 NOT NULL, 
    [TaskStatus] INT NOT NULL, 
    [TaskType] INT NOT NULL, 
    [AssignedTo] INT NULL, 
    [TaskDescription] NVARCHAR(MAX) NOT NULL
)
