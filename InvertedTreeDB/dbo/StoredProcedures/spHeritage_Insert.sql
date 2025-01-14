CREATE PROCEDURE [dbo].[spHeritage_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Heritage] (Name, Description, State)
	values (@Name, @Description, @State)
end
