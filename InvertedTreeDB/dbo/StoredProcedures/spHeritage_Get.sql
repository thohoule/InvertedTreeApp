CREATE PROCEDURE [dbo].[spHeritage_Get]
	@Id int
AS
begin
	select *
	from dbo.[Heritage]
	where ID = @Id;
end
