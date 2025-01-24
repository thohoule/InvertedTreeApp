CREATE PROCEDURE [dbo].[spHeritage_GetCharacteristicTypeOption]
	@heritageID int
AS
begin
	select *
	from dbo.[CharacteristicType] left outer join 
	(select *
	from dbo.[CharacteristicTypeOption]
	where HeritageId = @heritageID) as temp
	on temp.CharacteristicTypeId = Id
	WHERE (temp.HeritageId IS NOT NULL)
end