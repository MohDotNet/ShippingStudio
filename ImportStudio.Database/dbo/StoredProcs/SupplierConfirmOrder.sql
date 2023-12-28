/*
 CREATED BY : MOHAMED I AMEERODIEN
 DESCRIPTION: This stored procedure is called when the supplier confirms the order.
 This will update the order with an official INDENT number.
 It will also update the check list history.
 */
CREATE PROCEDURE SupplierConfirmOrder @OrderId int, @IndentNumber NVARCHAR(50)
AS
BEGIN
	DECLARE 
		@CheckListCount INT = 0,
		@CheckListId int = 0,
		@OrderDate DATETIME = GetDate()

	SELECT @OrderDate = OrderDate FROM dbo.Orders WHERE id = @OrderId

	IF @@ROWCOUNT > 0
	BEGIN
		UPDATE dbo.Orders
		SET IndentNumber = @IndentNumber
		WHERE Id = @OrderId

		-- Check how many Checklist items there are linked to order number.
		SET @CheckListCount = (SELECT COUNT(ID) FROM dbo.CheckList WHERE OrderId = @OrderId)

		IF @CheckListCount > 0
		BEGIN 
			SET @CheckListId = (SELECT Max(Id) FROM dbo.CheckList WHERE (OrderId = @OrderId) AND (IndentReceived IS NULL) AND (IndentNumber IS NULL))
		END

		-- If there is no record in check list, create one.
		IF @CheckListCount = 0 OR @CheckListCount is null 
		BEGIN
			INSERT INTO DBO.CheckList
			(OrderId, IndentNumber, PurchaseOrderCreated, PurchaseOrderDate, IndentReceived, IndentReceivedDate)
			VALUES(@OrderId, @IndentNumber, 1, @OrderDate, 1, GETDATE())
		END
		ELSE
		BEGIN
			UPDATE dbo.CheckList
			SET IndentReceived = 1, IndentReceivedDate = GETDATE(), IndentNumber = @IndentNumber
			WHERE Id = @CheckListId
		END

		SELECT 
			'0' AS Code, 
			[Message] = 'Order successfully confirmed.'
	END;
	ELSE
	BEGIN
		SELECT
			'500' AS Code, 
			'Order Does not exist or cannot be found, check order Id.' AS [Message]
	END;
END






