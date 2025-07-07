# Authentication Backend

## Overview

This ASP.NET Core Web API implements a comprehensive JWT-based authentication system as specified in the PRD. The backend provides secure, stateless authentication suitable for both mobile and web applications, designed to meet ISO 27001 compliance requirements.

### Implementation Status

**✅ Core Infrastructure Completed:**
- Complete vertical slice architecture implementation
- Entity Framework Core with SQL Server integration
- JWT token system with RS256 asymmetric signing
- Comprehensive security middleware and services
- Database schema with Users, ActiveSessions, and AuditLog tables
- BCrypt password hashing with 12-round security
- Account lockout and rate limiting protection
- Structured logging with Serilog
- CORS configuration for frontend integration

**✅ Authentication Features Implemented:**
- **Complete Login Flow**: User authentication with username/password validation
- **JWT Token System**: Access token (15-min) and refresh token (60-min) generation  
- **Session Management**: Active session tracking in database
- **Security Controls**: Failed login monitoring, account lockout (5 attempts/30-min duration)
- **Audit Logging**: Comprehensive event logging (LOGIN_SUCCESS, LOGIN_FAILED, ACCOUNT_LOCKED)
- **Password Security**: BCrypt hashing with 12 rounds
- **MFA Preparation**: Login handler detects MFA-enabled accounts (implementation pending)

**⏳ Features with Infrastructure Ready (Need Implementation):**
- Token refresh endpoint (handler and controller needed)
- User registration (validation and endpoint needed)
- Multi-factor authentication setup/verification (TOTP, SMS, Email)
- Password reset self-service functionality  
- Logout endpoints with session invalidation
- Token verification endpoint

**⚠️ Current Limitations:**
- Architecture mixing vertical slices with technical layers (needs refactoring)
- No XML documentation or unit tests
- Error handling uses generic exceptions instead of business-specific ones
- Some methods exceed recommended length limits

The core authentication infrastructure is functional but requires code quality improvements and feature completion for production readiness.

## Architecture

This project follows **Vertical Slice Architecture** where each feature is organized as a complete vertical slice containing:
- Request/Response models
- Handlers (business logic)
- Controllers (API endpoints)
- Validators

### Project Structure

```
Authentication.Api/
├── Features/
│   └── Authentication/
│       ├── Login/           # Login feature slice
│       ├── Register/        # User registration slice
│       ├── Refresh/         # Token refresh slice
│       ├── Logout/          # Logout slice
│       ├── Verify/          # Token verification slice
│       └── MFA/             # Multi-factor authentication slice
├── Common/
│   ├── Entities/           # Domain entities (User, Session, etc.)
│   ├── Interfaces/         # Service contracts
│   ├── Services/           # Shared service implementations
│   ├── Data/               # Entity Framework DbContext
│   ├── Extensions/         # Extension methods
│   └── Middleware/         # Custom middleware
```

## Features

### Currently Implemented
- ✅ **Login Feature Complete**: LoginController, LoginHandler, LoginRequest/Response, Validation
- ✅ JWT Token-based authentication (RS256) with access/refresh tokens
- ✅ User password validation with BCrypt (12 rounds)
- ✅ Session management with database tracking
- ✅ Comprehensive audit logging (LOGIN_SUCCESS, LOGIN_FAILED, ACCOUNT_LOCKED)
- ✅ Account lockout after 5 failed attempts (30-minute duration)
- ✅ Entity Framework Core with SQL Server (Users, ActiveSessions, AuditLog)
- ✅ MediatR for CQRS pattern implementation
- ✅ FluentValidation for LoginRequest validation
- ✅ Serilog for structured logging

### Feature Folders Created (Implementation Needed)
- ⏳ **Token Refresh**: `/Features/Authentication/Refresh/` (empty)
- ⏳ **User Registration**: `/Features/Authentication/Register/` (empty)  
- ⏳ **Multi-factor Authentication**: `/Features/Authentication/MFA/` (empty)
- ⏳ **Logout Functionality**: `/Features/Authentication/Logout/` (empty)
- ⏳ **Token Verification**: `/Features/Authentication/Verify/` (empty)

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT with RS256 signing
- **Logging**: Serilog
- **Validation**: FluentValidation
- **CQRS**: MediatR
- **Password Hashing**: BCrypt.Net

## Configuration

### Database Connection
Update the connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AuthenticationDb;Trusted_Connection=true;TrustServerCertificate=true;"
}
```

### JWT Configuration
Configure JWT settings in `appsettings.json`:
```json
"JwtSettings": {
  "Issuer": "AuthenticationApi",
  "Audience": "AuthenticationClients",
  "PrivateKey": "-----BEGIN RSA PRIVATE KEY-----\n...\n-----END RSA PRIVATE KEY-----",
  "PublicKey": "-----BEGIN PUBLIC KEY-----\n...\n-----END PUBLIC KEY-----",
  "AccessTokenExpiryMinutes": 15,
  "RefreshTokenExpiryMinutes": 60
}
```

## Getting Started

1. **Prerequisites**
   - .NET 8.0 SDK
   - SQL Server (LocalDB or full instance)

2. **Setup**
   ```bash
   cd Authentication.Api
   dotnet restore
   ```

3. **Database Setup**
   - The application will automatically create the database on first run
   - Or use Entity Framework migrations:
   ```bash
   dotnet ef database update
   ```

4. **Generate RSA Keys** (for JWT signing)
   ```bash
   # Generate private key
   openssl genrsa -out private.pem 2048
   
   # Generate public key
   openssl rsa -in private.pem -pubout -out public.pem
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

## API Endpoints

### Authentication
- `POST /api/auth/login` - User authentication
- `POST /api/auth/refresh` - Token refresh (planned)
- `POST /api/auth/logout` - User logout (planned)
- `POST /api/auth/logout-all` - Logout from all devices (planned)
- `GET /api/auth/verify` - Token validation (planned)

### Development
- `GET /swagger` - API documentation (development only)

## Security Features

- **JWT RS256 Signing**: Asymmetric key signing for enhanced security
- **Account Lockout**: 30-minute lockout after 5 failed login attempts
- **Password Hashing**: BCrypt with 12 rounds
- **Audit Logging**: All authentication events are logged
- **Session Management**: Active session tracking and management
- **CORS**: Configured for frontend integration

## Development Notes

- Database is created automatically on application start
- Logs are written to both console and file (`logs/authentication-.log`)
- CORS is configured for `http://localhost:3000` (Next.js frontend)
- All authentication events are audited in the database