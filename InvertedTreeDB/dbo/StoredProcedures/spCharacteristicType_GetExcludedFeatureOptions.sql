CREATE PROCEDURE [dbo].[spCharacteristic_GetExcludedFeatureOptions]
	@characteristicID int
AS
begin
	select *
	from dbo.[CharacteristicType] left outer join
	(select *
	from dbo.[CharacteristicFeatureOption]
	where CharacteristicId = @characteristicID) as temp 
	on temp.CharacteristicId = Id
	where temp.CharacteristicId is null
end
