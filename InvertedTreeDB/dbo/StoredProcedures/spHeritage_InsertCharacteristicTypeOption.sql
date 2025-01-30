CREATE PROCEDURE [dbo].[spHeritage_InsertCharacteristicTypeOption]
	@HeritageID int,
	@CharacteristicTypeID int
AS
begin
	if not exists (select * from dbo.[CharacteristicTypeOption]
					where HeritageId = @HeritageID
					and CharacteristicTypeId = @CharacteristicTypeID)
	begin
		insert into dbo.[CharacteristicTypeOption] (HeritageId, CharacteristicTypeID)
		values (@HeritageID, @CharacteristicTypeID)
	end
end
