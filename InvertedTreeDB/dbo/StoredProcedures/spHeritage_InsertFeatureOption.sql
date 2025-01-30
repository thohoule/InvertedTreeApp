CREATE PROCEDURE [dbo].[spHeritage_InsertFeatureOption]
	@HeritageID int,
	@FeatureID int
AS
begin
	if not exists (select * from dbo.[HeritageFeatureOption]
					where HeritageId = @HeritageID
					and FeatureId = @FeatureID)
	begin
		insert into dbo.[HeritageFeatureOption] (HeritageId, FeatureId)
		values (@HeritageID, @FeatureID)
	end
end
