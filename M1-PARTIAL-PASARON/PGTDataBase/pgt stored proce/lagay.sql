CREATE PROCEDURE [dbo].[lagay]
	@GastosName nvarchar(50),
	@GastosType nvarchar(50), 
	@Remarks text, 
	@dateAdded datetime2,
	@Price int,
	@brand nvarchar(50),
	@code nvarchar(50)
AS
begin
	INSERT INTO dbo.pgtgastos
	(GastosName, GastosType, Remarks, dateAdded, Price, Brand, Code)
	VALUES
	(@GastosName, @GastosType, @Remarks, @dateAdded, @Price, @brand, @code)

	end