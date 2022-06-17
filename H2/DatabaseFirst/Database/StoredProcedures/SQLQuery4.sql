USE [Lufthavn]
GO
/****** Object:  StoredProcedure [dbo].[spCompanyAndRoute_Create]    Script Date: 17-06-2022 11:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Benjamin>
-- Create date: <16-06-2022>
-- Description:	<Creates company and route>
-- =============================================
ALTER PROCEDURE [dbo].[spCompanyAndRoute_Create]
@CompanyName VARCHAR(64)

AS
BEGIN
	EXEC spCompany_Create @Name = @CompanyName

	DECLARE
	@CompanyCompanyId INT
	SELECT @CompanyCompanyId = MAX(CompanyId) FROM Company

	EXEC spRoute_Create @CompanyId = @CompanyCompanyId
END
