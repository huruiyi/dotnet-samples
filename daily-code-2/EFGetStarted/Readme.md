dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database

数据库系统					包
SQL Server 和 SQL Azure		Microsoft.EntityFrameworkCore.SqlServer
SQLite						Microsoft.EntityFrameworkCore.Sqlite
Azure Cosmos DB				Microsoft.EntityFrameworkCore.Cosmos
PostgreSQL					Npgsql.EntityFrameworkCore.PostgreSQL*
MySQL						Pomelo.EntityFrameworkCore.MySql*
EF Core 内存中数据库**		Microsoft.EntityFrameworkCore.InMemory