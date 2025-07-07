# Authentication System

A full-stack authentication system with JWT tokens, featuring a Next.js frontend and ASP.NET Core backend using vertical slice architecture.

## Project Structure

```
authentication/
├── frontend/           # Next.js 15 frontend application
├── backend/            # ASP.NET Core 8 Web API
├── docs/              # Documentation (PRD, etc.)
└── README.md          # This file
```

## Features

### 🎯 Authentication Features (Backend)
- JWT-based authentication with RS256 signing
- Account lockout protection (5 failed attempts = 30min lockout)
- Session management and tracking
- Audit logging for security events
- BCrypt password hashing
- Multi-factor authentication (planned)

### 🎨 Frontend Features
- Next.js 15 with App Router
- TypeScript and Tailwind CSS
- shadcn/ui component library
- Responsive design for mobile and desktop

## Quick Start

### Prerequisites
- Node.js 18+ (for frontend)
- .NET 8.0 SDK (for backend)
- SQL Server (LocalDB or full instance)

### Frontend Development
```bash
cd frontend
npm install
npm run dev
# Opens at http://localhost:3000
```

### Backend Development
```bash
cd backend/Authentication.Api
dotnet restore
dotnet run
# API available at https://localhost:7157
```

## Development Workflow

1. **Frontend**: Run `npm run dev` in the `frontend/` directory
2. **Backend**: Run `dotnet run` in the `backend/Authentication.Api/` directory
3. **Database**: Will be created automatically on first backend run

## Security Features

- **RS256 JWT Signing**: Asymmetric cryptography for token security
- **Account Protection**: Automatic lockout after failed login attempts
- **Session Management**: Active session tracking and management
- **Audit Logging**: Comprehensive security event logging
- **CORS Configuration**: Secure frontend-backend communication

## Documentation

- [Product Requirements Document](docs/prd.md) - Complete feature specifications
- [Backend README](backend/README.md) - Detailed backend documentation
- [Frontend Setup Guide](frontend/README.md) - Next.js application guide

## Architecture

This project follows:
- **Frontend**: Component-based architecture with Next.js App Router
- **Backend**: Vertical slice architecture with MediatR CQRS pattern
- **Database**: Entity Framework Core with SQL Server
- **Authentication**: JWT tokens with refresh token rotation

## Tech Stack

### Frontend
- Next.js 15
- TypeScript
- Tailwind CSS
- shadcn/ui components

### Backend
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- MediatR (CQRS)
- FluentValidation
- Serilog

## Getting Started

See individual README files in the `frontend/` and `backend/` directories for detailed setup instructions.