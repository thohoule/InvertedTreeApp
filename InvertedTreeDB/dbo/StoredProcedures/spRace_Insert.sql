﻿CREATE PROCEDURE [dbo].[spRace_Insert]
	@Name nvarchar(50),
	@Description nvarchar(max),
	@State int
AS
begin
	insert into dbo.[Race] (Name, Description, State)
	values (@Name, @Description, @State)
end
