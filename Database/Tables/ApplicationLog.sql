create table dbo.ApplicationLog(
  id int identity(1,1) primary key,
  date_added datetime not null default(getutcdate()),
  comment nvarchar(max) not null,
  application_name nvarchar(100)
)

/*
select * from ApplicationLog

*/

alter table dbo.ApplicationLog add last_updates_on timestamp