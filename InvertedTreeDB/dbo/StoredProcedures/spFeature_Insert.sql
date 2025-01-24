CREATE PROCEDURE [dbo].[spFeature_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Feature] (Name, Description, State)
	values (@Name, @Description, @State)
end
