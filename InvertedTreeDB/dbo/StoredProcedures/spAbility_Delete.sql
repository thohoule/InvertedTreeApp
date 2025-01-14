CREATE PROCEDURE [dbo].[spAbility_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Ability]
	where ID = @Id;
end
