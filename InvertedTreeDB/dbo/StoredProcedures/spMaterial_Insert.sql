CREATE PROCEDURE [dbo].[spMaterial_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Material] (Name, Description, State)
	values (@Name, @Description, @State)
end
