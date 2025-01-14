CREATE PROCEDURE [dbo].[spMaterial_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Material]
	where ID = @Id;
end
