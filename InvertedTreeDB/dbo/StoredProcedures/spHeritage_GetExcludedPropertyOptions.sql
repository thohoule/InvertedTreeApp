CREATE PROCEDURE [dbo].[spHeritage_GetExcludedPropertyOptions]
	@heritageId int
AS
begin
	select *
	from dbo.[Property] left outer join
	(select *
	from dbo.[HeritagePropertyOption]
	where HeritageId = @heritageId) as temp 
	on temp.PropertyId = Id
	where temp.PropertyId is null
end
