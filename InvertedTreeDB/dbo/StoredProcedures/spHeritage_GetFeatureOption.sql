CREATE PROCEDURE [dbo].[spHeritage_GetFeatureOption]
	@heritageID int
AS
begin
	select *
	from dbo.[Feature] left outer join 
	(select *
	from dbo.[HeritageFeatureOption]
	where HeritageId = @heritageID) as temp
	on temp.FeatureId = Id
	WHERE (temp.HeritageId IS NOT NULL)
end
