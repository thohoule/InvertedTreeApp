CREATE PROCEDURE [dbo].[spProperty_Insert]
	@Name nvarchar(50),
	@Type nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Property] (Name, Type, Description, State)
	values (@Name, @Type, @Description, @State)
end
