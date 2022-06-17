USE [Lufthavn]
GO
/****** Object:  StoredProcedure [dbo].[spRoute_Create]    Script Date: 17-06-2022 11:31:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Benjamin Hoffmeyer>
-- Create date: <15-06-2022>
-- Description:	<Creates a route>
-- =============================================

ALTER PROCEDURE [dbo].[spRoute_Create]
	@CompanyId INT

AS
BEGIN
	SET NOCOUNT ON;	

	--Creates a route
	INSERT INTO Route(Company_CompanyId) VALUES(@CompanyId)
END
