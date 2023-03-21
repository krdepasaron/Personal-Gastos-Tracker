CREATE PROCEDURE [dbo].[register]
	@username nvarchar(MAX),
	@firstname nvarchar(50),
	@lastname nvarchar(50),
	@password nvarchar(50)
AS
begin
	
	set nocount on;

	INSERT INTO dbo.pgtuser
	(username, firstname, lastname, password)
	VALUES (@username, @firstname, @lastname, @password)


	end