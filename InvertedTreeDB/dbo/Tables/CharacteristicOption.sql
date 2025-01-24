CREATE TABLE [dbo].[CharacteristicOption]
(
	[CharacteristicTypeId] INT NOT NULL , 
    [CharacteristicId] INT NOT NULL, 
    PRIMARY KEY ([CharacteristicTypeId], [CharacteristicId])
)
