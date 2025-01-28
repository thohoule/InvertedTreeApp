CREATE PROCEDURE [dbo].[spCharacteristic_GetExcludedFeatureOptions]
	@characteristicID int
AS
begin
	select *
	from dbo.[Feature] left outer join
	(select *
	from dbo.[CharacteristicFeatureOption]
	where CharacteristicId = @characteristicID) as temp 
	on temp.FeatureId = Id
	where temp.FeatureId is null
end