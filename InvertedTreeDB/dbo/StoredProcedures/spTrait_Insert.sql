CREATE PROCEDURE [dbo].[spTrait_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Trait] (Name, Description, State)
	values (@Name, @Description, @State)
end
