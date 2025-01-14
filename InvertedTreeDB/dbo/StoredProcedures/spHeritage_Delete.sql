CREATE PROCEDURE [dbo].[spHeritage_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Heritage]
	where ID = @Id;
end
