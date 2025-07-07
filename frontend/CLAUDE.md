# CLAUDE.md - Frontend

This file provides guidance to Claude Code for working with the Next.js frontend.

## 🚨 MANDATORY: Read AI Coding Instructions First
**BEFORE writing ANY code**, read and follow `../docs/ai-coding-instructions.md`. These are non-negotiable directives.

## Quick Commands

- `npm run dev` - Start development server with Turbopack (http://localhost:3000)
- `npm run build` - Build production application
- `npm run start` - Start production server
- `npm run lint` - Run ESLint to check code quality
- `npm install` - Install dependencies

## Architecture

## 🚨 CRITICAL: Technology Stack (FIXED - NO SUBSTITUTIONS)
- **ONLY** React with TypeScript (strict mode, no exceptions)
- **ONLY** Tailwind CSS for styling
- **ONLY** shadcn/ui for components
- **REQUIRED** TanStack Query for server state (NO other data fetching)
- **REQUIRED** Zustand for global UI state (NO Redux, Context, etc.)
- **REQUIRED** React Hook Form + Zod for forms (NO other form libraries)
- **FORBIDDEN** Any other state management libraries

**Architecture Rules:**
- **ALWAYS** place React components with related backend code by feature
- **MAXIMUM** one primary responsibility per component
- **REQUIRED** TypeScript strict mode, no exceptions
- **REQUIRED** Explicit types for all props and API payloads

**Project Structure:**
- `app/` - Next.js App Router pages and layouts
  - `layout.tsx` - Root layout with Geist fonts
  - `page.tsx` - Homepage component
  - `globals.css` - Global styles
- `lib/` - Utility functions
  - `utils.ts` - Contains `cn()` utility for class merging
- `components.json` - shadcn/ui configuration with New York style
- `public/` - Static assets (SVG icons, images)

**Component System:**
- Uses shadcn/ui component library with "new-york" style
- Configured with Lucide icons
- Path aliases: `@/components`, `@/lib/utils`, `@/components/ui`
- CSS variables enabled for theming

**TypeScript Configuration:**
- Strict mode enabled
- Path mapping: `@/*` points to project root
- ES2017 target with ESNext modules
- Next.js plugin configured

## Backend Integration

- API Base URL: `http://localhost:7157` (ASP.NET Core backend)
- Authentication: JWT tokens stored in sessionStorage
- CORS: Backend configured for `http://localhost:3000`

## Development Notes

- Uses Turbopack for development builds (faster than Webpack)
- ESLint configured with Next.js TypeScript rules
- Ready for shadcn/ui component additions
- Font optimization handled by Next.js font system
- Dark mode support built into default template
- Geist font family (sans and mono variants)

## 🔒 MANDATORY: Security Requirements
- **Form Validation**: ALWAYS validate all forms with Zod (REQUIRED)
- **Input Sanitization**: ALWAYS treat external input as untrusted
- **Token Storage**: JWT tokens in sessionStorage (per PRD requirements)
- **Error Handling**: User-friendly messages, NO internal system details
- **HTTPS Only**: All API calls must use HTTPS in production

## 📋 MANDATORY: Documentation Requirements  
- **JSDoc Comments**: REQUIRED for complex business logic
- **Component Documentation**: REQUIRED for all component interfaces and props
- **State Management**: REQUIRED documentation for complex state patterns
- **Business Purpose**: REQUIRED explanation of component business purpose

## Authentication Flow (Business Requirements)
1. **User Authentication**: Login form posts to `POST /api/auth/login`
2. **Token Management**: Store JWT tokens in sessionStorage (PRD requirement)
3. **API Authorization**: Use access token in Authorization header
4. **Token Refresh**: Implement sliding expiration (60-minute sessions)
5. **Session Timeout**: 5-minute and 1-minute warnings with countdown
6. **Multi-device Support**: Session management UI for active sessions
7. **Secure Logout**: Token invalidation and redirect to login