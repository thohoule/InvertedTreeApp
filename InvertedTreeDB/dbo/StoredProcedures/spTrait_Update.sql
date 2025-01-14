CREATE PROCEDURE [dbo].[spTrait_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	update dbo.[Trait]
	set Name = @Name, Description = @Description, State = @State
	where Id = @Id;
end
