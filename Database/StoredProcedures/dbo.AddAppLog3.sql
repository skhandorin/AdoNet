IF ( EXISTS ( SELECT [id] FROM sys.SYSOBJECTS WHERE [name]='AddAppLog3' AND type='P' ) )
  DROP PROCEDURE AddAppLog3
GO
create procedure dbo.AddAppLog3
  @comment nvarchar(max),
  @outid int output
as
  set nocount on

  insert into ApplicationLog(date_added, comment, application_name)
    values (default, @comment, APP_NAME())

  set @outid = SCOPE_IDENTITY()
--
GO
/*
declare @out int
exec dbo.AddAppLog3 'sample message', @out output
select @out
select * from ApplicationLog

*/