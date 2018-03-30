IF ( EXISTS ( SELECT [id] FROM sys.SYSOBJECTS WHERE [name]='AddAppLog2' AND type='P' ) )
  DROP PROCEDURE AddAppLog2
GO
create procedure dbo.AddAppLog2
  @comment nvarchar(max)
as
  set nocount on

  insert into ApplicationLog(date_added, comment, application_name)
    values (default, @comment, APP_NAME())

  select SCOPE_IDENTITY()
--
GO
/*
exec dbo.AddAppLog2 'sample message'
select * from ApplicationLog

*/