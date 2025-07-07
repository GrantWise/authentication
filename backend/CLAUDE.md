# CLAUDE.md - Backend

This file provides guidance to Claude Code for working with the ASP.NET Core backend.

## Quick Commands (run from `Authentication.Api/` directory)

- `dotnet run` - Start the API server (https://localhost:7157)
- `dotnet build` - Build the C# application
- `dotnet restore` - Restore NuGet packages
- `dotnet ef database update` - Apply database migrations
- `dotnet ef migrations add <name>` - Create new migration

## Architecture

**Stack:**
- ASP.NET Core 8.0 Web API
- Entity Framework Core with SQL Server
- JWT authentication with RS256 signing
- MediatR for CQRS pattern
- FluentValidation for request validation
- Serilog for structured logging
- BCrypt for password hashing

**Vertical Slice Architecture:**
```
Authentication.Api/
├── Features/                    # Vertical slices
│   └── Authentication/
│       ├── Login/              # Complete feature slice
│       │   ├── LoginRequest.cs     # Request/Response models
│       │   ├── LoginHandler.cs     # Business logic (MediatR)
│       │   └── LoginController.cs  # API endpoint
│       ├── Register/           # Future feature slice
│       ├── Refresh/            # Future feature slice
│       └── ...
├── Common/                     # Shared infrastructure
│   ├── Entities/              # Domain entities (User, Session, etc.)
│   ├── Interfaces/            # Service contracts
│   ├── Services/              # Service implementations
│   └── Data/                  # Entity Framework DbContext
└── Program.cs                 # Application startup
```

**Database Entities:**
- `User` - User accounts with authentication data
- `ActiveSession` - JWT refresh token sessions
- `AuditLog` - Security event logging

## Development Patterns

**Adding New Features:**
1. Create feature directory under `Features/Authentication/`
2. Add Request/Response models with FluentValidation
3. Create MediatR handler with business logic
4. Add API controller endpoint
5. Register services in `Program.cs` if needed

**Security Features:**
- JWT tokens: 15-minute access tokens, 60-minute refresh tokens
- Account lockout: 30-minute lockout after 5 failed attempts
- Password hashing: BCrypt with 12 rounds
- Audit logging: All authentication events logged
- CORS: Configured for `http://localhost:3000` (frontend)

## Database Configuration

- **Connection String**: Set in `appsettings.json`
- **Auto-Creation**: Database created automatically on startup
- **Migrations**: Use EF Core commands for schema changes

## JWT Configuration

Required in `appsettings.json`:
```json
"JwtSettings": {
  "Issuer": "AuthenticationApi",
  "Audience": "AuthenticationClients", 
  "PrivateKey": "-----BEGIN RSA PRIVATE KEY-----...",
  "PublicKey": "-----BEGIN PUBLIC KEY-----...",
  "AccessTokenExpiryMinutes": 15,
  "RefreshTokenExpiryMinutes": 60
}
```

## Logging

- **Console**: Development logging
- **File**: `logs/authentication-.log` (daily rotation)
- **Structured**: JSON format with Serilog
- **Events**: All authentication events audited to database

## API Endpoints

- `POST /api/auth/login` - User authentication ✅
- `POST /api/auth/refresh` - Token refresh (planned)
- `POST /api/auth/logout` - User logout (planned)
- `GET /api/auth/verify` - Token validation (planned)
- `GET /swagger` - API documentation (development)