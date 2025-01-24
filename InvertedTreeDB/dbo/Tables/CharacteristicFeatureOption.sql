CREATE TABLE [dbo].[CharacteristicFeatureOption]
(
	[CharacteristicId] INT NOT NULL , 
    [FeatureId] INT NOT NULL, 
    PRIMARY KEY ([CharacteristicId], [FeatureId])
)
