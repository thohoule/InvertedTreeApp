CREATE PROCEDURE [dbo].[spFeature_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Feature]
	where ID = @Id;
end
