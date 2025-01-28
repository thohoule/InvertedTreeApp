CREATE PROCEDURE [dbo].[spCharacteristic_GetFeatureOptions]
	@characteristicID int
AS
begin
	select *
	from dbo.[Feature] left outer join 
	(select *
	from dbo.[CharacteristicFeatureOption]
	where CharacteristicId = @characteristicID) as temp
	on temp.FeatureId = Id
	WHERE (temp.CharacteristicId IS NOT NULL)
end
