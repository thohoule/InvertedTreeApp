CREATE PROCEDURE [dbo].[spProperty_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Property]
	where ID = @Id;
end
