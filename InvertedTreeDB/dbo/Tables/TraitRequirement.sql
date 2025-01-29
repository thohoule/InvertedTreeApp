CREATE TABLE [dbo].[TraitRequirement]
(
	[TraitId] INT NOT NULL , 
    [ElementType] NVARCHAR(50) NOT NULL, 
    [ElementID] INT NOT NULL, 
    CONSTRAINT [PK_TraitRequirement] PRIMARY KEY ([TraitId], [ElementID], [ElementType])
)
