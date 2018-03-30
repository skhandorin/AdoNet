IF ( EXISTS ( SELECT [id] FROM sys.SYSOBJECTS WHERE [name]='UpdateDepartmentName' AND type='P' ) )
  DROP PROCEDURE UpdateDepartmentName
GO
create procedure dbo.UpdateDepartmentName
  @id int,
  @name nvarchar(100)
as
  --set nocount on

  update HumanResources.Department
    set Name = @name
    where DepartmentID = @id
--
GO
/*
declare @out int
exec @out = dbo.UpdateDepartmentName 16, 'UPD-Executive'
select @out
select * from HumanResources.Department

*/