CREATE PROCEDURE [dbo].[spMaterial_Get]
	@Id int
AS
begin
	select *
	from dbo.[Material]
	where ID = @Id;
end
