CREATE PROCEDURE [dbo].[spRace_GetHeritageOption]
	@raceID int
AS
begin
	select *
	from dbo.[Heritage] left outer join 
	(select *
	from dbo.[HeritageOption]
	where RaceId = @raceID) as temp
	on temp.HeritageId = Id
	WHERE (temp.RaceId IS NOT NULL)
end
