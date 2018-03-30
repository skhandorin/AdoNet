IF ( EXISTS ( SELECT [id] FROM sys.SYSOBJECTS WHERE [name]='UpdateDepartmentName' AND type='P' ) )
  DROP PROCEDURE UpdateDepartmentName
GO
create procedure dbo.UpdateDepartmentName
  @id int,
  @name nvarchar(100)
as
  --set nocount on

  if (@name = 'test')
  begin;
    throw 50001, 'invalid department name', 1;
    --raiserror('invalid department name', 16, 1)
    --return
  end;

  update HumanResources.Department
    set Name = @name
    where DepartmentID = @id
--
GO
/*
declare @out int
exec @out = dbo.UpdateDepartmentName 16, 'Executive'
select @out
select * from HumanResources.Department

*/