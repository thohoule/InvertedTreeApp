CREATE PROCEDURE [dbo].[spHeritage_GetExcludedCharacteristicTypeOptions]
	@heritageId int
AS
begin
	select *
	from dbo.[CharacteristicType] left outer join
	(select *
	from dbo.[CharacteristicTypeOption]
	where HeritageId = @heritageId) as temp 
	on temp.CharacteristicTypeId = Id
	where temp.CharacteristicTypeId is null
end
