CREATE PROCEDURE [dbo].[spCharacteristic_Get]
	@Id int
AS
begin
	select *
	from dbo.[Characteristic]
	where ID = @Id;
end
