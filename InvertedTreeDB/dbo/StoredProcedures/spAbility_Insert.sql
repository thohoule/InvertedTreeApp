CREATE PROCEDURE [dbo].[spAbility_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Ability] (Name, Description, State)
	values (@Name, @Description, @State)
end
