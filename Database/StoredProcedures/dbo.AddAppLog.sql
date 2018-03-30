IF ( EXISTS ( SELECT [id] FROM sys.SYSOBJECTS WHERE [name]='AddAppLog' AND type='P' ) )
  DROP PROCEDURE AddAppLog
GO
create procedure dbo.AddAppLog
  @comment nvarchar(max)
as
  set nocount on

  insert into ApplicationLog(date_added, comment, application_name)
    values (default, @comment, APP_NAME())

--
GO
/*
exec dbo.AddAppLog 'sample message'
select * from ApplicationLog

*/