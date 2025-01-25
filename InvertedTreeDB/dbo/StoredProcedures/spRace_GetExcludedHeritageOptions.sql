CREATE PROCEDURE [dbo].[spRace_GetExcludedHeritageOptions]
	@raceId int
AS
begin
	select *
	from dbo.[Heritage] left outer join
	(select *
	from dbo.[HeritageOption]
	where RaceId = @raceId) as temp 
	on temp.HeritageId = Id
	where temp.HeritageId is null
end
