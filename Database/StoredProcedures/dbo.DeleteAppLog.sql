IF ( EXISTS ( SELECT [id] FROM sys.SYSOBJECTS WHERE [name]='AddAppLog4' AND type='P' ) )
  DROP PROCEDURE AddAppLog4
GO
create procedure dbo.AddAppLog4
  @comment nvarchar(max)
as
  set nocount on

  insert into ApplicationLog(date_added, comment, application_name)
    values (default, @comment, APP_NAME())

  return SCOPE_IDENTITY()
--
GO
/*
declare @out int
exec @out = dbo.AddAppLog4 'sample message'
select @out
select * from ApplicationLog

*/