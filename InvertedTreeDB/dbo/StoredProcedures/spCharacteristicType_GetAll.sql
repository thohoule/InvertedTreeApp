CREATE PROCEDURE [dbo].[spCharacteristicType_GetAll]
AS
begin
	select *
	from dbo.[CharacteristicType]
end