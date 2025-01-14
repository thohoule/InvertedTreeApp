CREATE TABLE [dbo].[Material]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Name] NVARCHAR(50) NOT NULL , 
    [Description] NVARCHAR(MAX) NULL, 
    [State] INT NOT NULL DEFAULT 0
)
