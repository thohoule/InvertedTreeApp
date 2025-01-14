CREATE PROCEDURE [dbo].[spRace_Get]
	@Id int
AS
begin
	select *
	from dbo.[Race]
	where ID = @Id;
end
