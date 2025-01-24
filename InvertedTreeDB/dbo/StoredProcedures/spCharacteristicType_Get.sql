CREATE PROCEDURE [dbo].[spCharacteristicType_Get]
	@Id int
AS
begin
	select *
	from dbo.[CharacteristicType]
	where ID = @Id;
end
