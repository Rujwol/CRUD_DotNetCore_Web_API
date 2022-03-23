# CRUD_DotNetCore_Web_API
This project is basic implementation of CRUD operation using DotNet Core Web API. It is a back-end application which performs server side processes.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Language used: C#
DB used: SQL Server
Framework: Dotnet Core web API

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**Basic Points in DotNet Core application**
 - Program.cs: Entry point of an application
 - Startup.cs: Central Hub of dotnet project  |  in here Configure() method is where request pipeline is setup
 - launchSettings.json: We can manage Starting URL and also can change the environment
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**Dependency Injection

(It hepls in decoupling of the project and also minimize the changes)
DI in dootnetcore are added in startup.ConfigureServices also known as service container.

Three way we can register service/DI in service container
1. AddSingleton: Same object for every request
2. AddScoped: Created once per client request
3. Transient: New Instance created every time

_we have used AddScoped in this project_
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**Important command for Migrations
_Entity framework was used_

1. dotnet ef migrations add <migration name>
2. dotnet ef migration remove //if migration not run yet
3. dotnet ef database update //running migration
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
**DTO(data transfer object)

Implemented DTO with the help of
_AutoMapper.Extentions.Microsoft.DependencyInjection_ Library
  -> To implement it we should add another service within Startup.cs -> ConfigureService()
