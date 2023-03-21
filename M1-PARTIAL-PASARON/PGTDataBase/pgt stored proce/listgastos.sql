CREATE PROCEDURE [dbo].[listgastos]
AS
begin

	SELECT [g].[Id], [g].[GastosName], [g].[GastosType], [g].[Remarks],
	[g].[dateAdded], [g].[Price], [g].[Code], [g].[Brand], [u].[username]

	FROM dbo.pgtgastos g
	INNER JOIN dbo.pgtuser u
	ON g.userId = u.Id

	end

