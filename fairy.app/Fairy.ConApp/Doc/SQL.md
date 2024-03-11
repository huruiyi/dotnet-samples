```sql
IF EXISTS (SELECT name
           FROM sys.databases
           WHERE name = N'TransTestDb')
    drop database [TransTestDb]
CREATE DATABASE [TransTestDb];


--建表
use [TransTestDb]
go
IF EXISTS (SELECT *
           FROM sys.objects
           WHERE object_id = OBJECT_ID(N'[dbo].[TransTestTable]')
             AND type in (N'U'))
    drop table [TransTestTable]
CREATE TABLE [dbo].[TransTestTable]
(
    Id     int,
    [Name] varchar(16)
);


--初始值
use [TransTestDb]
go
insert into [TransTestTable]
select 1, 'a'
union
select 2, 'b'
union
select 3, 'c';


--事务测试
begin try
    begin tran
        insert into dbo.TransTestTable values (99, '66');
        update dbo.TransTestTable set [Name] = '99999999999999999999999999999999999999999999999' where [Id] = 99;
        --RAISERROR ('Error raised in TRY block.',16,1);
    commit tran
end try
begin catch
    rollback tran
end catch

```