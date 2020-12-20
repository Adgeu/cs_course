SELECT 
	DS.Id,
	D.Name AS DocumentName,
	D.Pages,
	CONCAT(S_Employee.Fullname, ', ', S_Pos.Name) AS Sender,
	CONCAT(S_City.Name, ', ', S_Address.Street,', ', S_Address.House) AS SenderAddress,
	CONCAT(R_Employee.Fullname, ', ', R_Pos.Name) AS Receiver,
	CONCAT(R_City.Name, ', ', R_Address.Street,', ', R_Address.House) AS ReceiverAddress,
	S.Name AS DocumentStatus,
	DS.DateTime
FROM [DocumentStatus] AS DS

JOIN [Document] AS D
	ON DS.DocumentId = D.Id

JOIN [Employee] AS S_Employee
	ON DS.SenderId = S_Employee.Id

JOIN [Position] AS S_Pos
	ON S_Employee.PositionId = S_Pos.Id

JOIN [Address] AS S_Address
	ON DS.SenderAddressId = S_Address.Id

JOIN [City] AS S_City
	ON S_Address.CityId = S_City.Id

JOIN [Employee] AS R_Employee
	ON DS.ReceiverId = R_Employee.Id

JOIN [Position] AS R_Pos
	ON R_Employee.PositionId = R_Pos.Id

JOIN [Address] AS R_Address
	ON DS.ReceiverAddressId = R_Address.Id

JOIN [City] AS R_City
	ON R_Address.CityId = R_City.Id

JOIN [Status] AS S
	ON DS.StatusId = S.Id