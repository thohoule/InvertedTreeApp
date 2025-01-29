CREATE PROCEDURE [dbo].[spTrait_GetRequirements]
	@traitId int
AS
begin
	select *
	from dbo.[TraitRequirement]
	where TraitId = @traitId
end
