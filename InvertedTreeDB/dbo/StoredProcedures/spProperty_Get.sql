CREATE PROCEDURE [dbo].[spProperty_Get]
	@Id int
AS
begin
	select *
	from dbo.[Property]
	where ID = @Id;
end
