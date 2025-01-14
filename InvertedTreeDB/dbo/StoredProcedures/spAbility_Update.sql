CREATE PROCEDURE [dbo].[spAbility_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	update dbo.[Ability]
	set Name = @Name, Description = @Description, State = @State
	where Id = @Id;
end
