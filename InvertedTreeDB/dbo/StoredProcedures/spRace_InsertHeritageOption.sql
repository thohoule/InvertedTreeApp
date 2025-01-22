CREATE PROCEDURE [dbo].[spRace_InsertHeritageOption]
	@RaceID int,
	@HeritageID int
AS
begin
	if not exists (select * from dbo.[HeritageOption]
					where RaceId = @RaceID
					and HeritageId = @HeritageID)
	begin
		insert into dbo.[HeritageOption] (RaceId, HeritageId)
		values (@RaceID, @HeritageID)
	end
end
