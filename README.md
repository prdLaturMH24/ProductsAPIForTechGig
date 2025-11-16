# Product API for CI/CD Assignment

This repository contains a .NET 8 Web API for managing products. The project already includes an EF Core initial migration. The steps below show how to set up the project and create the database from that initial migration.

## Prerequisites
- .NET 8 SDK (dotnet --version should report 8.x)
- SQL Server or LocalDB (or change to another provider in `appsettings.json`)
- Optional: Visual Studio 2022 or later

## Quick setup and run

1. Clone the repository
git clone https://github.com/prdLaturMH24/ProductsAPIForTechGig

2. Navigate to the project directory

3. Restore packages

4. Ensure the EF Core CLI tool is available (install or update if needed)

5. Configure the database connection
- Open `appsettings.json` and set your connection string under the appropriate key (commonly `ConnectionStrings:DefaultConnection`).
- Example using LocalDB:
  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductsDb;Trusted_Connection=True;"
    }
  }
  ```
- Or a SQL Server instance:
  ```
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ProductsDb;User Id=sa;Password=YourPassword;"
  ```

6. Apply the existing migrations to create the database
- Using dotnet CLI (from the project root where the .csproj is located):
  ```
  dotnet ef database update
  ```
  If your solution has multiple projects or a separate startup project, add `--project` and `--startup-project` as needed:
  ```
  dotnet ef database update --project Repository --startup-project .
  ```

- Or using Visual Studio's __Tools > NuGet Package Manager > Package Manager Console__:
  ```
  Update-Database -Context ProductDbContext
  ```

- To apply a specific migration (the included initial migration file name is `20220930073639_InitialMigration`), run:
  ```
  dotnet ef database update 20220930073639_InitialMigration
  ```

7. Run the API
- From CLI:
  ```
  dotnet run
  ```
- Or open the solution in Visual Studio and start via __Debug > Start Debugging__ (F5) or __Debug > Start Without Debugging__ (Ctrl+F5).

8. Verify the API
- Open a browser or use curl/postman to call an endpoint, e.g.:
  ```
  curl http://localhost:5000/api/products
  ```
  (adjust host/port according to the application output)

## Troubleshooting
- "dotnet ef not found": ensure `dotnet-ef` is installed globally and its path is available, or use the CLI as a local tool.
- Connection errors: verify the connection string and that the SQL Server instance is running and reachable.
- Migration errors: confirm the `ProductDbContext` is the context used by migrations and that the startup project is correct when running `dotnet ef`.

## Notes
- Project targets .NET 8.
- The repository already contains an initial migration in the `Migrations` folder. Running `dotnet ef database update` will create the database schema defined by those migrations.
