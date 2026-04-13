# TodoApi

A RESTful API built with ASP.NET Core 8 for managing todos. Features full CRUD operations, service layer pattern, AutoMapper, and global exception handling.

## Tech Stack

- **ASP.NET Core 8** — Web API
- **Entity Framework Core 8** — ORM with Code First migrations
- **SQL Server (LocalDB)** — Database
- **AutoMapper** — DTO to Model mapping
- **Swagger** — API documentation and testing

## Architecture

```
Controllers/        → API endpoints (receives HTTP requests)
DTOs/               → Data Transfer Objects (controls input shape)
Mappings/           → AutoMapper profiles (DTO → Model conversion)
Models/             → Database entities
Services/           → Business logic layer (interface + implementation)
Middleware/         → Global exception handler
Data/               → DbContext (Entity Framework)
Migrations/         → EF Core database migrations
```

## Data Flow

```
Client (JSON) → Controller → Service → AutoMapper → DbContext → SQL Server
SQL Server → DbContext → Service → Controller → Client (JSON)
```

## API Endpoints

| Method | Endpoint | Description | Response |
|--------|----------|-------------|----------|
| GET | `/api/todo` | Get all todos | 200 + JSON array |
| GET | `/api/todo/{id}` | Get todo by ID | 200 + JSON or 404 |
| POST | `/api/todo` | Create a new todo | 201 + JSON |
| PUT | `/api/todo/{id}` | Update a todo | 200 + JSON or 404 |
| DELETE | `/api/todo/{id}` | Delete a todo | 204 or 404 |

## Request Examples

### Create Todo (POST)
```json
{
  "title": "Learn ASP.NET Core",
  "description": "Complete the TodoApi tutorial",
  "dueDate": "2026-04-20T00:00:00",
  "priority": 5
}
```

### Update Todo (PUT)
```json
{
  "title": "Learn ASP.NET Core",
  "description": "Tutorial completed!",
  "dueDate": "2026-04-20T00:00:00",
  "priority": 5,
  "isCompleted": true
}
```

## Todo Model

| Field | Type | Validation |
|-------|------|------------|
| Id | int | Auto-generated |
| Title | string | Required, max 100 chars |
| Description | string? | Optional, max 500 chars |
| DueDate | DateTime | Required |
| Priority | int | Range 1-5 |
| IsCompleted | bool | Default: false |

## Design Patterns Used

- **Repository/Service Pattern** — Business logic separated from controllers
- **Dependency Injection** — Services registered with `AddTransient`
- **DTO Pattern** — Input validation separated from database model
- **Middleware Pattern** — Global exception handling

## Getting Started

1. Clone the repository
   ```bash
   git clone https://github.com/HOUSSAMEELBANDOUDI/TodoApi.git
   ```

2. Update the connection string in `appsettings.json`

3. Run migrations
   ```bash
   dotnet ef database update
   ```

4. Run the application
   ```bash
   dotnet run
   ```

5. Open Swagger UI at `https://localhost:7118/swagger`

## Key Concepts Learned

- **MVC vs API**: Controllers return JSON (`Ok()`, `NotFound()`) instead of HTML views (`View()`)
- **DTOs**: Control what data the client can send (no Id, no IsCompleted on create)
- **AutoMapper**: Automatically maps DTO properties to Model properties
- **Service Layer**: Keeps controllers thin, business logic in services
- **Global Exception Handler**: Catches all unhandled errors and returns clean JSON
- **Swagger**: Auto-generated API documentation for testing endpoints
