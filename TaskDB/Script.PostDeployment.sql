IF NOT EXISTS(SELECT 1 FROM Users)
BEGIN
	INSERT INTO Users (UserName)
	VALUES 
	('NeilD'),
	('GloriaG'),
	('PhillC'),
	('JohnnyC'),
	('LauraB')
END
IF NOT EXISTS(SELECT 1 FROM Tasks)
BEGIN
	INSERT INTO Tasks (Created,RequiredDate,TaskStatus,TaskType,AssignedTo,TaskDescription)
	VALUES 
	(GETDATE(),GETDATE(),1,1,1,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed viverra et augue sed ultricies. Phasellus condimentum arcu erat, volutpat ultrices ligula vestibulum vitae. Mauris et consequat massa. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Etiam varius egestas sapien.'),
	(GETDATE(),GETDATE(),2,2,2,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed viverra et augue sed ultricies. Phasellus condimentum arcu erat, volutpat ultrices ligula vestibulum vitae. Mauris et consequat massa. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Etiam varius egestas sapien.'),
	(GETDATE(),GETDATE(),3,3,3,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed viverra et augue sed ultricies. Phasellus condimentum arcu erat, volutpat ultrices ligula vestibulum vitae. Mauris et consequat massa. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Etiam varius egestas sapien.'),
	(GETDATE(),GETDATE(),2,2,4,'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed viverra et augue sed ultricies. Phasellus condimentum arcu erat, volutpat ultrices ligula vestibulum vitae. Mauris et consequat massa. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Etiam varius egestas sapien.')
END
