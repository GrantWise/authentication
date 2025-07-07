# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Structure

This is a full-stack authentication system with:
- `frontend/` - Next.js 15 application
- `backend/` - ASP.NET Core 8 Web API with vertical slice architecture
- `docs/` - Project documentation

## Common Commands

**Frontend Development (run from `frontend/` directory):**
- `npm run dev` - Start development server with Turbopack (opens http://localhost:3000)
- `npm run build` - Build production application
- `npm run start` - Start production server
- `npm run lint` - Run ESLint to check code quality
- `npm install` - Install dependencies

**Backend Development (run from `backend/Authentication.Api/` directory):**
- `dotnet run` - Start the API server (opens https://localhost:7157)
- `dotnet build` - Build the C# application
- `dotnet restore` - Restore NuGet packages
- `dotnet ef database update` - Apply database migrations

## Architecture Overview

### Frontend: Next.js 15 Application
This is a Next.js 15 application using the App Router architecture with TypeScript and Tailwind CSS.

### Backend: ASP.NET Core 8 with Vertical Slice Architecture
JWT-based authentication API following vertical slice architecture patterns.

**Frontend Technologies:**
- Next.js 15 with App Router
- TypeScript with strict mode
- Tailwind CSS v4 for styling
- shadcn/ui components (configured via components.json)
- ESLint with Next.js rules
- Turbopack for fast development builds

**Backend Technologies:**
- ASP.NET Core 8.0 Web API
- Entity Framework Core with SQL Server
- JWT authentication with RS256 signing
- MediatR for CQRS pattern
- FluentValidation for request validation
- Serilog for structured logging
- BCrypt for password hashing

## Project Structure

**Frontend (`frontend/` directory):**
- `app/` - Next.js App Router pages and layouts
  - `layout.tsx` - Root layout with Geist fonts
  - `page.tsx` - Homepage component
  - `globals.css` - Global styles
- `lib/` - Utility functions
  - `utils.ts` - Contains `cn()` utility for class merging
- `components.json` - shadcn/ui configuration with New York style
- `public/` - Static assets (SVG icons, images)

**Backend (`backend/Authentication.Api/` directory):**
- `Features/` - Vertical slices (Login, Register, etc.)
  - Each feature contains: Request/Response models, Handlers, Controllers, Validators
- `Common/` - Shared infrastructure
  - `Entities/` - Domain entities (User, Session, AuditLog)
  - `Interfaces/` - Service contracts
  - `Services/` - Shared service implementations
  - `Data/` - Entity Framework DbContext
- `Program.cs` - Application startup and configuration

## Frontend Component System
- Uses shadcn/ui component library with "new-york" style
- Configured with Lucide icons
- Path aliases: `@/components`, `@/lib/utils`, `@/components/ui`
- CSS variables enabled for theming

## Backend Architecture
- **Vertical Slice Architecture**: Each feature is a complete vertical slice
- **CQRS Pattern**: Using MediatR for request/response handling
- **JWT Authentication**: RS256 asymmetric signing for security
- **Session Management**: Active session tracking and management
- **Audit Logging**: Comprehensive security event logging

## Development Notes

**Frontend:**
- Uses Turbopack for development builds (faster than Webpack)
- ESLint configured with Next.js TypeScript rules
- Ready for shadcn/ui component additions
- Font optimization handled by Next.js font system

**Backend:**
- Database is created automatically on application start
- CORS configured for `http://localhost:3000` (frontend)
- Logs written to both console and file (`logs/authentication-.log`)
- Account lockout: 30-minute lockout after 5 failed login attempts

## Security Features
- JWT tokens with 15-minute access tokens and 60-minute refresh tokens
- RSA 2048-bit key pairs for JWT signing
- BCrypt password hashing with 12 rounds
- Account lockout protection
- Comprehensive audit logging
- CORS configuration for secure frontend communication