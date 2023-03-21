CREATE TABLE [dbo].[pgtuser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] NVARCHAR(MAX) NOT NULL, 
    [firstname] NVARCHAR(50) NOT NULL, 
    [lastname] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL,
)
