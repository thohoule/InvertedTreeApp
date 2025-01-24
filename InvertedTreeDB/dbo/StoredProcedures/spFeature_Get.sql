CREATE PROCEDURE [dbo].[spFeature_Get]
	@Id int
AS
begin
	select *
	from dbo.[Feature]
	where ID = @Id;
end
