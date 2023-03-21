CREATE TABLE [dbo].[pgtgastos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [userId] INT NOT NULL, 
    [GastosName] NVARCHAR(50) NOT NULL, 
    [Price] INT NOT NULL, 
    [Remarks] TEXT NULL, 
    [dateAdded] DATETIME2 NOT NULL, 
    [GastosType] NVARCHAR(50) NOT NULL,
    [Code] NVARCHAR(50) NULL, 
    [Brand] NVARCHAR(50) NULL, 
    CONSTRAINT [fk_gastos_user] FOREIGN KEY (UserId) REFERENCES pgtuser(Id)
)
