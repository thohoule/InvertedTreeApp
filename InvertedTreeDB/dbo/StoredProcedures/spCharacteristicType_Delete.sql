CREATE PROCEDURE [dbo].[spCharacteristicType_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[CharacteristicType]
	where ID = @Id;
end
