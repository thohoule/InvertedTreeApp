CREATE PROCEDURE [dbo].[spHeritage_InsertPropertyOption]
	@HeritageID int,
	@PropertyID int
AS
begin
	if not exists (select * from dbo.[HeritagePropertyOption]
					where HeritageId = @HeritageID
					and PropertyId = @PropertyID)
	begin
		insert into dbo.[HeritagePropertyOption] (HeritageId, PropertyId)
		values (@HeritageID, @PropertyID)
	end
end
