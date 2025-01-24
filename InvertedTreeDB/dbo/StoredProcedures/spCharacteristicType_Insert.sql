CREATE PROCEDURE [dbo].[spCharacteristicType_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[CharacteristicType] (Name, Description, State)
	values (@Name, @Description, @State)
end
