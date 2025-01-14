CREATE PROCEDURE [dbo].[spElementType_GetByDataName]
	@dataName nvarchar(50)
AS
begin
	select *
	from dbo.[ElementType]
	where DataName = @dataName
end
