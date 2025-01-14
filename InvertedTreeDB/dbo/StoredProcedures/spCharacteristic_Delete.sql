CREATE PROCEDURE [dbo].[spCharacteristic_Delete]
	@Id int
AS
begin
	delete 
	from dbo.[Characteristic]
	where ID = @Id;
end
