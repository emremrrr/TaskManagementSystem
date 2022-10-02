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
