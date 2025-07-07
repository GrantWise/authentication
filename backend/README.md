# Authentication Backend

ASP.NET Core Web API implementing JWT-based authentication with vertical slice architecture.

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

### Implemented
- ✅ JWT Token-based authentication (RS256)
- ✅ User login with password validation
- ✅ Session management
- ✅ Audit logging
- ✅ Account lockout after failed attempts
- ✅ Password hashing with BCrypt
- ✅ Entity Framework Core with SQL Server
- ✅ MediatR for CQRS pattern
- ✅ FluentValidation for request validation
- ✅ Serilog for structured logging

### Planned
- ⏳ Token refresh endpoint
- ⏳ User registration
- ⏳ Multi-factor authentication (MFA)
- ⏳ Password reset functionality
- ⏳ Logout endpoints
- ⏳ Token verification endpoint

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