# Lead Manager API

A .NET 9 Web API for managing sales leads. Built with ASP.NET Core and Entity Framework Core, featuring a RESTful interface for lead tracking, status management, and data generation capabilities.

## How to run

### Docker (Recommended)

Make sure you have Docker with Docker Compose installed on your machine.

```bash
#dev
docker compose --profile dev up

#prod
docker compose --profile prod up --build
```

The API will be available at `http://localhost:8080` by default.

### Local Development

1. Make sure you have .NET 9 SDK installed
2. Update the connection string in `appsettings.json` if needed
3. Make sure you have a SQL Server instance running and the connection string is correct
4. Run the following commands:

```bash
dotnet restore
dotnet run
```

The API will be available at `http://localhost:5034` by default.

## Documentation

A Swagger documentation interface is available at `/swagger` when running the application. You can use it to explore and test all available endpoints.

## Test Data

You can generate fake test data by making a POST request to:

```
POST /api/leads/fake
{
    "quantity": {number}
}
```

Where `{number}` is the amount of fake leads you want to generate. This is useful for testing and development purposes.
