# CLAUDE.md - Backend

This file provides guidance to Claude Code for working with the ASP.NET Core backend.

## 🚨 MANDATORY: Read AI Coding Instructions First
**BEFORE writing ANY code**, read and follow `../docs/ai-coding-instructions.md`. These are non-negotiable directives.

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

## 🚨 CRITICAL: Architecture Rules (NO EXCEPTIONS)
- **ALWAYS** group by features, **NEVER** by technical layers
- **ALWAYS** put controller, service, models, tests for same feature in same folder
- **FORBIDDEN:** Repository pattern until specific documented need
- **REQUIRED:** Use business domain names, not technical names
- **REQUIRED:** Code reads like business language

**Feature-Based Vertical Slice Architecture:**
```
Authentication.Api/
├── Features/                    # Complete vertical slices
│   └── Authentication/
│       ├── Login/              # Complete feature slice
│       │   ├── LoginRequest.cs     # Request/Response (business language)
│       │   ├── LoginHandler.cs     # Business logic (MediatR)
│       │   ├── LoginController.cs  # API endpoint
│       │   └── LoginTests.cs       # Tests in same folder (REQUIRED)
│       ├── UserRegistration/   # Business-named feature
│       ├── TokenRefresh/       # Business-named feature
│       └── ...
├── Shared/                     # ONLY truly shared utilities
│   ├── Entities/              # Domain entities
│   ├── Exceptions/            # Custom business exceptions (REQUIRED)
│   └── Data/                  # DbContext (direct usage, no repository)
└── Program.cs
```

**Database Entities:**
- `User` - User accounts with authentication data
- `ActiveSession` - JWT refresh token sessions
- `AuditLog` - Security event logging

## 🚨 MANDATORY: Development Patterns

**Adding New Features (STRICT PROCESS):**
1. Create feature directory under `Features/Authentication/` with BUSINESS NAME
2. Add Request/Response models with FluentValidation (REQUIRED)
3. Create MediatR handler with business logic (MAX 30 lines per method)
4. Add API controller endpoint with [Authorize] by default
5. Add XML documentation for ALL public classes/methods (REQUIRED)
6. Add OpenAPI annotations to ALL endpoints (REQUIRED)
7. Create tests in SAME folder as feature code (REQUIRED)
8. Use business domain terminology throughout (REQUIRED)

**Class Design Rules (ENFORCE):**
- **EXACTLY** one primary responsibility per class
- **MAXIMUM** 30 lines per method unless single atomic operation  
- **TARGET** ~200 lines per class, logical cohesion overrides size
- **REQUIRED** business domain names expressing intent clearly

**Error Handling (MANDATORY):**
- **ALWAYS** create specific exception types for business scenarios
- **REQUIRED** Custom exceptions: `NotFoundException`, `ValidationException`, `BusinessRuleException`
- **ALWAYS** include user-friendly messages in exception constructor
- **FORBIDDEN** Generic exceptions for business logic

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

## 📋 MANDATORY: Documentation Requirements
- **XML Documentation**: REQUIRED for ALL public classes, methods, properties
- **OpenAPI Annotations**: REQUIRED for ALL endpoints with examples
- **Error Response Documentation**: REQUIRED for all failure scenarios
- **Authentication Requirements**: REQUIRED clearly stated per endpoint

## 🔒 Security Requirements (ISO 27001 Compliant)
- **Input Validation**: ALWAYS validate with FluentValidation
- **Authorization**: [Authorize] by default, document any [AllowAnonymous]
- **Audit Logging**: ALL authentication events with correlation IDs
- **Rate Limiting**: 5 attempts per username per 15 minutes
- **Password Hashing**: bcrypt with 12+ rounds (configurable to 15)
- **Token Security**: RS256 signing, 15min access/60min refresh
- **Security Headers**: HSTS, CSP, X-Frame-Options enforcement

## API Endpoints (All require OpenAPI documentation)
- `POST /api/auth/login` - User authentication ✅
- `POST /api/auth/refresh` - Token refresh (planned)
- `POST /api/auth/logout` - User logout (planned)
- `POST /api/auth/logout-all` - Logout from all devices (planned)
- `GET /api/auth/verify` - Token validation (planned)
- `POST /api/auth/mfa/setup` - MFA configuration (planned)
- `POST /api/auth/mfa/verify` - MFA verification (planned)
- `GET /swagger` - API documentation (development)