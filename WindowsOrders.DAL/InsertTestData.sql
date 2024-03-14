use [WindowsOrders]
go 

DECLARE @stateId INT 
DECLARE @outId1 INT
DECLARE @outId2 INT 

SELECT @stateId =  id 
FROM dbo.states WITH(NOLOCK) 
WHERE code = 'NY'

IF (@@ROWCOUNT > 0)
BEGIN
	
	INSERT INTO [dbo].[ORDERS] ([states_id], [name], [create_date])
	VALUES (@stateId, 'New York Building 1', GETDATE())

	SET @outId1 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ORDERS_WINDOWS] ([orders_id], [name], [quantity], [create_date])
	VALUES (@outId1, 'A51', 4, GETDATE())
	
	SET @outId2 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ORDERS_WINDOWS_ITEMS] 
		([orders_windows_id], [order], [type_id], [width], [height], [create_date])
	VALUES
		 (@outId2, 1, 1, 1200, 1850, GETDATE())
		,(@outId2, 2, 2, 800, 1850, GETDATE())
		,(@outId2, 3, 2, 700, 1850, GETDATE())
	
		
	INSERT INTO [dbo].[ORDERS_WINDOWS] ([orders_id], [name], [quantity], [create_date])
	VALUES (@outId1, 'C Zone 5', 2, GETDATE())
	
	SET @outId2 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ORDERS_WINDOWS_ITEMS] 
		([orders_windows_id], [order], [type_id], [width], [height], [create_date])
	VALUES
		 (@outId2, 1, 2, 1500, 2000, GETDATE())
END 


SELECT @stateId =  id 
FROM dbo.states WITH(NOLOCK) 
WHERE code = 'CA'


IF (@@ROWCOUNT > 0)
BEGIN
	INSERT INTO [dbo].[ORDERS] ([states_id], [name], [create_date])
	VALUES (@stateId, 'California Hotel AJK', GETDATE())

	SET @outId1 = SCOPE_IDENTITY()

		
	INSERT INTO [dbo].[ORDERS_WINDOWS] ([orders_id], [name], [quantity], [create_date])
	VALUES (@outId1, 'GLB', 3, GETDATE())
	
	SET @outId2 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ORDERS_WINDOWS_ITEMS] 
		([orders_windows_id], [order], [type_id], [width], [height], [create_date])
	VALUES
		 (@outId2, 1, 1, 1400, 2200, GETDATE())
		,(@outId2, 2, 2, 600, 2200, GETDATE())

	INSERT INTO [dbo].[ORDERS_WINDOWS] ([orders_id], [name], [quantity], [create_date])
	VALUES (@outId1, 'OHF', 10, GETDATE())
	
	SET @outId2 = SCOPE_IDENTITY()

	INSERT INTO [dbo].[ORDERS_WINDOWS_ITEMS] 
		([orders_windows_id], [order], [type_id], [width], [height], [create_date])
	VALUES
		 (@outId2, 1, 2, 1500, 2000, GETDATE())
		,(@outId2, 1, 2, 1500, 2000, GETDATE())


END 