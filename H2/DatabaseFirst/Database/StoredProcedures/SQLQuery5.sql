USE [Lufthavn]
GO
/****** Object:  StoredProcedure [dbo].[spPlane_Create]    Script Date: 17-06-2022 11:31:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Benjamin Hoffmeyer>
-- Create date: <15-06-2022>
-- Description:	<Creates a plane>
-- =============================================

ALTER PROCEDURE [dbo].[spPlane_Create]
	@SerialNum VARCHAR(256), @CompanyId INT, @RouteId INT, @AITA VARCHAR(3)

AS
BEGIN
	SET NOCOUNT ON;	

	--Creates a plane
	INSERT INTO Plane(SerialNum, Company_CompanyId, Route_RouteId, Airport_IATA) VALUES(@SerialNum, @CompanyId, @RouteId, @AITA)
END
