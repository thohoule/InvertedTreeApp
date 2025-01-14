CREATE PROCEDURE [dbo].[spMaterial_GetAll]
AS
begin
	select *
	from dbo.[Material]
end