CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Created] DATETIME2 NOT NULL, 
    [CommentText] NVARCHAR(MAX) NOT NULL, 
    [CommentType] INT NOT NULL, 
    [ReminderDate] DATETIME2 NOT NULL, 
    [TaskId] INT NOT NULL, 
    [CreatedBy] INT NOT NULL
)
