CREATE PROCEDURE [dbo].[spTrait_Get]
	@Id int
AS
begin
	select *
	from dbo.[Trait]
	where ID = @Id;
end
