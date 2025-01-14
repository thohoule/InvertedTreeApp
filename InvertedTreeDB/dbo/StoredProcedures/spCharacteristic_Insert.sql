CREATE PROCEDURE [dbo].[spCharacteristic_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Characteristic] (Name, Description, State)
	values (@Name, @Description, @State)
end
