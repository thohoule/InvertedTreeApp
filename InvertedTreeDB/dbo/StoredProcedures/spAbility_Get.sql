CREATE PROCEDURE [dbo].[spAbility_Get]
	@Id int
AS
begin
	select *
	from dbo.[Ability]
	where ID = @Id;
end
