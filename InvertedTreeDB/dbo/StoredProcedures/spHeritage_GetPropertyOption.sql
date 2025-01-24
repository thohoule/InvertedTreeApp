CREATE PROCEDURE [dbo].[spHeritage_GetPropertyOption]
	@heritageID int
AS
begin
	select *
	from dbo.[Property] left outer join 
	(select *
	from dbo.[HeritagePropertyOption]
	where HeritageId = @heritageID) as temp
	on temp.PropertyId = Id
	WHERE (temp.HeritageId IS NOT NULL)
end