# CLAUDE.md - Frontend

This file provides guidance to Claude Code for working with the Next.js frontend.

## Quick Commands

- `npm run dev` - Start development server with Turbopack (http://localhost:3000)
- `npm run build` - Build production application
- `npm run start` - Start production server
- `npm run lint` - Run ESLint to check code quality
- `npm install` - Install dependencies

## Architecture

**Stack:**
- Next.js 15 with App Router
- TypeScript with strict mode
- Tailwind CSS v4 for styling
- shadcn/ui components (New York style)
- ESLint with Next.js rules
- Turbopack for fast development builds

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

## Authentication Flow

When implementing authentication pages:
1. Login form posts to `POST /api/auth/login`
2. Store JWT tokens in sessionStorage
3. Use access token in Authorization header
4. Implement token refresh logic with refresh token
5. Handle session timeout and redirects