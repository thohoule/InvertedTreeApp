CREATE PROCEDURE [dbo].[spHeritage_GetExcludedFeatureOptions]
	@heritageId int
AS
begin
	select *
	from dbo.[Feature] left outer join
	(select *
	from dbo.[HeritageFeatureOption]
	where HeritageId = @heritageId) as temp 
	on temp.FeatureId = Id
	where temp.FeatureId is null
end
