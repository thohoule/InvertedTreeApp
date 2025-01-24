CREATE PROCEDURE [dbo].[spProperty_Update]
	@Id int,
	@Name nvarchar(50),
	@Type nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	update dbo.[Property]
	set Name = @Name, Type = @Type, Description = @Description, State = @State
	where Id = @Id;
end
