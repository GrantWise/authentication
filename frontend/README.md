# Authentication Frontend

## Overview

This Next.js 15 frontend provides the user interface for the JWT-based authentication system as specified in the PRD. Built with modern React patterns, TypeScript, and Tailwind CSS, it delivers a responsive, accessible authentication experience for both mobile and desktop users.

### Implementation Status

**✅ Basic Development Setup:**
- Next.js 15 with App Router architecture  
- TypeScript strict mode configuration for type safety
- Tailwind CSS v4 with modern styling capabilities
- shadcn/ui configuration file ready (New York style)
- Build system with Turbopack for fast development
- ESLint configuration for code quality
- Font optimization with Geist Sans and Geist Mono
- Basic project structure following Next.js conventions

**❌ Authentication Infrastructure Missing:**
- No authentication dependencies installed (TanStack Query, Zustand, React Hook Form, Zod)
- No shadcn/ui components installed (button, form, input, etc.)
- No backend API integration code
- No JWT token handling or session storage
- No authentication-specific routing or guards
- No form validation setup

**❌ Authentication UI Components (All Need Implementation):**
- Login page with username/password form
- User registration interface
- MFA setup and verification flows
- Session timeout warnings and countdown
- Active sessions management interface
- Password reset flow
- Protected dashboard and profile pages
- Error handling and user feedback components

**Current State**: This is a default Next.js starter project with Tailwind CSS and shadcn/ui configuration. All authentication functionality needs to be built from scratch, starting with installing the required dependencies.

## Quick Start

```bash
npm install
npm run dev
```

Open [http://localhost:3000](http://localhost:3000) to view the application.

## Current Features (Basic Setup Only)

- **Next.js 15** with App Router architecture
- **TypeScript** with strict mode for type safety  
- **Tailwind CSS v4** for modern styling
- **shadcn/ui** configuration ready (no components installed yet)
- **Turbopack** for fast development builds
- **ESLint** configured for Next.js best practices

## Missing Required Dependencies

Authentication functionality requires installing:
```bash
npm install @tanstack/react-query @tanstack/react-query-devtools
npm install zustand
npm install react-hook-form @hookform/resolvers  
npm install zod
```

Plus shadcn/ui components:
```bash
npx shadcn@latest add button form input card label alert badge dialog dropdown-menu
```

## Project Structure

```
frontend/
├── app/                    # Next.js App Router
│   ├── layout.tsx         # Root layout with fonts
│   ├── page.tsx           # Homepage
│   └── globals.css        # Global styles
├── lib/
│   └── utils.ts           # Utility functions (cn helper)
├── components.json        # shadcn/ui configuration
└── public/                # Static assets
```

## Development

- **Dev Server**: `npm run dev` (uses Turbopack)
- **Build**: `npm run build`
- **Lint**: `npm run lint`
- **Production**: `npm run start`

## Backend Integration (Not Implemented)

The backend API is available at http://localhost:7157, but frontend integration needs to be built:
- **API Client**: No HTTP client configured
- **Authentication**: No JWT token handling implemented  
- **Session Storage**: No token storage implementation
- **CORS**: Backend configured for this frontend, but no client code exists

## Component System

This project uses [shadcn/ui](https://ui.shadcn.com/) with:
- **Style**: New York variant
- **Icons**: Lucide React
- **Theme**: CSS variables with dark mode support
- **Path aliases**: `@/components`, `@/lib/utils`, `@/components/ui`

## Adding Components

```bash
npx shadcn@latest add button
npx shadcn@latest add form
npx shadcn@latest add input
```

## Styling

- **Tailwind CSS v4** with PostCSS
- **Custom utility**: `cn()` function for conditional classes
- **Fonts**: Geist Sans and Geist Mono (optimized by Next.js)
- **Dark mode**: Built-in support via CSS variables

## Authentication Pages (All Need Implementation)

Currently showing default Next.js homepage. Need to create:
- `/login` - User authentication page and form
- `/register` - User registration page and form
- `/dashboard` - Protected dashboard with session management
- `/profile` - User profile management
- Route guards and authentication middleware

## TypeScript Configuration

- **Strict mode** enabled
- **Path mapping**: `@/*` points to project root
- **ES2017 target** with ESNext modules
- **Next.js plugin** for App Router support
