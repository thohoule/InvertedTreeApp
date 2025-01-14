CREATE PROCEDURE [dbo].[spTrait_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Trait]
	where ID = @Id;
end
