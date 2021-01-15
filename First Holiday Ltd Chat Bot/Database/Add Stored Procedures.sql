USE HolidayDestinations

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetDestinationByType
	@type varchar(255) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Destinations WHERE HolidayType = @type;
END
GO
