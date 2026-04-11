# dotnet_core_api_template

My go to setup for backends circa apr 2026

## Projects

| Project | Description |
|---------|-------------|
| **Api** | ASP.NET Core Web API with Swagger, health checks, and Dapper/PostgreSQL |
| **Ui** | Blazor Web App (Server) that consumes the API |
| **Database** | DbUp migrations runner for PostgreSQL |
| **Api.Tests** | xUnit tests for the API |

## Quick start

```bash
# Start PostgreSQL and API with Docker Compose
docker compose up -d

# Run database migrations
cd Database && dotnet run

# Run the API (if not using Docker)
cd Api && dotnet run

# Run the Blazor UI
cd Ui && dotnet run

# Run tests
dotnet test
```

## URLs

| Service | URL |
|---------|-----|
| API (Swagger) | http://localhost:60000 |
| Blazor UI | http://localhost:5100 |
| Health check | http://localhost:60000/health |

## Tech stack

- .NET 10 (LTS)
- ASP.NET Core Web API + Blazor Server
- PostgreSQL + Dapper
- DbUp for migrations
- Swashbuckle for OpenAPI/Swagger
- xUnit + Moq for testing
- Docker + Docker Compose
- GitHub Actions CI
