CREATE PROCEDURE [dbo].[spRace_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Race]
	where ID = @Id;
end
