# Authentication Frontend

Next.js 15 frontend for the authentication system, featuring modern React patterns and Tailwind CSS styling.

## Quick Start

```bash
npm install
npm run dev
```

Open [http://localhost:3000](http://localhost:3000) to view the application.

## Features

- **Next.js 15** with App Router architecture
- **TypeScript** with strict mode for type safety
- **Tailwind CSS v4** for modern styling
- **shadcn/ui** component library (New York style)
- **Turbopack** for fast development builds
- **ESLint** configured for Next.js best practices

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

## Backend Integration

- **API URL**: http://localhost:7157
- **Authentication**: JWT tokens via sessionStorage
- **CORS**: Pre-configured for this frontend

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

## Authentication Pages (To Implement)

- `/login` - User authentication
- `/register` - User registration  
- `/dashboard` - Protected dashboard
- `/profile` - User profile management

## TypeScript Configuration

- **Strict mode** enabled
- **Path mapping**: `@/*` points to project root
- **ES2017 target** with ESNext modules
- **Next.js plugin** for App Router support
