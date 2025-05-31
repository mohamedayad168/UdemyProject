# Studify - Online Learning Platform

A comprehensive online learning platform inspired by Udemy, built with .NET Core backend and Angular frontends. The platform enables instructors to create and manage courses while providing students with an engaging learning experience.

## 🏗️ Architecture Overview

The project follows a clean architecture pattern with clear separation of concerns:

    UdemyProject/
    ├── Backend (.NET Core)
    │ ├── Udemy.Core/ # Domain entities and interfaces
    │ ├── Udemy.Infrastructure/ # Data access and repositories
    │ ├── Udemy.Service/ # Business logic layer
    │ ├── Udemy.Presentation/ # API controllers
    │ └── Udemy/ # Main API host
    ├── Frontend Applications
    │ ├── Udemy.Client/ # Main Angular SPA (Students & Instructors)
    │ └── Client.Admin/ # Admin panel Angular SPA
    └── Utilities
    └── UsersSeeder/ # Database seeding utility

## 🚀 Key Features

### For Students

- Browse and search courses by category
- Enroll in courses and track learning progress
- Interactive video lessons and quizzes
- Shopping cart and secure checkout with Stripe
- Personal learning dashboard

### For Instructors

- Create and manage courses with rich content
- Upload videos and organize lessons into sections
- Create quizzes and assessments
- View course analytics and earnings
- Student engagement tracking

### For Administrators

- User management and role assignment
- Course approval workflow
- System analytics and reporting
- Content moderation tools

## 🛠️ Technology Stack

### Backend

- **Framework**: .NET Core with ASP.NET Core Web API
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Core Identity with cookie authentication
- **Architecture**: Clean Architecture with Repository and Service patterns
- **External Services**: Cloudinary (media storage), Stripe (payments)

### Frontend

- **Framework**: Angular 19 with TypeScript
- **UI Libraries**: PrimeNG, Bootstrap, Angular Material
- **Styling**: Tailwind CSS, custom CSS
- **Video Player**: NgxVideogular for course content
- **State Management**: Angular services with RxJS

## 📋 Prerequisites

- .NET 8.0 SDK or later
- Node.js 18+ and npm
- SQL Server (LocalDB or full instance)
- Angular CLI 19+

## 🔧 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/mohamedayad168/UdemyProject.git
cd UdemyProject
```

### 2. Backend Setup

```shell
# Navigate to the main API project  
cd Udemy

# Restore NuGet packages 
dotnet restore

# Update database connection string in appsettings.json
# Run database migrations
dotnet ef database update

# Start the API server
dotnet run
```

### 3. Frontend Setup

##### Main Application (Students & Instructors)

```shell
cd Udemy.Client

# Install dependencies
npm install

# Start development server
ng serve
```

#### Admin Panel

```shell
cd Client.Admin

# Install dependencies
npm install

# Start development server
ng serve --port 4201
```

## 🌐 Application URLs

- Main Application: http://localhost:4200
- Admin Panel: http://localhost:4201
- API: http://localhost:5000 (or as configured)
- API Documentation: http://localhost:5000/swagger

## 🏛️ Project Structure

### Backend Layers

##### Udemy.Core - Domain layer containing:

- Entity models (Course, User, Quiz, etc.)
- Repository interfaces
- Business logic contracts

##### Udemy.Infrastructure - Data access layer:

- Entity Framework DbContext
- Repository implementations
- Database migrations

##### Udemy.Service - Business logic layer:

- Service implementations
- Data transfer objects (DTOs)
- AutoMapper configurations

##### Udemy.Presentation - API layer:

- REST API controllers
- Request/response models
- Authentication filters

### Frontend Architecture

##### Both Angular applications follow component-based architecture with:

- Shared Components: Reusable UI elements
- Feature Modules: Organized by business functionality
- Services: Data access and state management
- Guards: Route protection and authorization
- Interceptors: HTTP request/response processing

## 🔐 Authentication & Authorization

The system implements role-based access control with three user types:

- Students: Course consumption and learning features
- Instructors: Course creation and management tools
- Admins: Full system administration capabilities

Authentication uses ASP.NET Core Identity with cookie-based sessions.

## 🗄️ Database Schema

Key entities include:

- Users (Students, Instructors, Admins)
- Courses with Sections and Lessons
- Quizzes and Questions
- Enrollments and Progress tracking
- Orders and Payment records

## 🚀 Deployment

### Backend Deployment

- Configure production connection strings
- Set up Cloudinary and Stripe API keys
- Deploy to Azure App Service or IIS
- Run database migrations in production

### Frontend Deployment

```shell
# Build for production
ng build --configuration production

# Deploy dist/ folder to web server
```

## 📚 API Documentation

The API includes Swagger documentation available at /swagger when running in development mode. Key endpoints include:

- `/api/courses` - Course management
- `/api/account` - Authentication
- `/api/instructors` - Instructor operations
- `/api/students` - Student operations
- `/api/payments` - Payment processing

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (git checkout -b feature/amazing-feature)
3. Commit your changes (git commit -m 'Add amazing feature')
4. Push to the branch (git push origin feature/amazing-feature)
5. Open a Pull Request

---

**Note**: This is an educational project inspired by Udemy's functionality. It demonstrates modern web development practices using .NET Core and Angular.
