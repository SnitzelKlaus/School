USE [Lufthavn]
GO
/****** Object:  StoredProcedure [dbo].[spCompany_Create]    Script Date: 17-06-2022 11:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Benjamin Hoffmeyer>
-- Create date: <15-06-2022>
-- Description:	<Creates a company>
-- =============================================

ALTER PROCEDURE [dbo].[spCompany_Create]
	@Name VARCHAR(64)

AS
BEGIN
	SET NOCOUNT ON;	

	--Creates company
	INSERT INTO Company(CompanyName) VALUES(@Name)
END