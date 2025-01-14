CREATE PROCEDURE [dbo].[spHeritage_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	update dbo.[Heritage]
	set Name = @Name, Description = @Description, State = @State
	where Id = @Id;
end
