This project is a playground for working with .NET Core, EF Core, and PostgreSQL.

## Prerequisites

- [.NET Core](https://www.microsoft.com/net/core)
- [Docker](https://docs.docker.com/engine/installation/)

## Process

### Initial Project Setup

1. Run the following commands:

```
dotnet new console
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet restore
```

2. Add the following to the project file (.csproj):

```
<ItemGroup>
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
</ItemGroup>
<ItemGroup>
    <None Include="appsettings.json" CopyToOutputDirectory="Always"/>
</ItemGroup>
```

### Config and Code

1. Create appsettings.json with connection string
2. Create docker-compose.yml with PostgresSQL info
3. Create classes:
    - Model/BloggingContext.cs (DbContext)
    - Model/Blog.cs
    - Model/Post.cs

### Create Database

Run the following commands:

```
docker-compose up -d
dotnet ef migrations add Initial
dotnet ef database update
dotnet run
PGPASSWORD=postgres psql -h localhost -p 5433 -U postgres -d playground -c 'SELECT * FROM "Blogs";'
```

### Create Database Migration

1. Add `public string Title { get; set; }` to Blog.cs
2. Run the following commands:

```
dotnet ef migrations add AddTitleToBlog
dotnet ef database update
PGPASSWORD=postgres psql -h localhost -p 5433 -U postgres -d playground -c 'SELECT * FROM "Blogs";'
```

## Gotchas along the way

1. I removed all `namespace` diretectives but then hit this bug: https://github.com/aspnet/EntityFramework/issues/2467; learned that namespaces are needed.
2. appsettings.json could not be found at runtime; learned that I need to add `<None Include="appsettings.json" CopyToOutputDirectory="Always"/>` to .csproj

## References

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
