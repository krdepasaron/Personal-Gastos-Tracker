CREATE PROCEDURE [dbo].[login]
	@username nvarchar(50),
	@password nvarchar(50)

AS
begin

	set nocount on;

	SELECT [Id], [username], [firstname], [lastname], [password]
	FROM dbo.pgtuser
	WHERE username = @username
	AND password = @password;

	end 
