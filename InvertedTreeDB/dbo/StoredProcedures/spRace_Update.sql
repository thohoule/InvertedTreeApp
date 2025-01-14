CREATE PROCEDURE [dbo].[spRace_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	update dbo.[Race]
	set Name = @Name, Description = @Description, State = @State
	where Id = @Id;
end
