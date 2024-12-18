# Covid Vaccination System

This is the API documentation for the Covid Vaccination System.

![Swagger Image](https://raw.githubusercontent.com/Hossam-abdelmonem/CovidVaccinationSystem/main/assets/Swagger.png)

## Features

### Patient Management
- Add, update, delete, and retrieve patient information.
- Track vaccination status.

### Vaccination Entry Management
- Add, update, and delete vaccination entries.
- Retrieve vaccination history for a specific patient.

### Validation
- DTO-based validation with FluentValidation for API requests.

### Scalable Architecture
- Implements Repository and Service patterns for clean separation of concerns.
- Uses AutoMapper for mapping entities to DTOs.

### API Documentation
- Integrated with Swagger UI for interactive API testing.

## Technologies

### Frameworks & Libraries
- ASP.NET Core 7.0
- Entity Framework Core
- FluentValidation
- AutoMapper
- Swashbuckle (Swagger)

### Database
- SQL Server (configured with EF Core)

## Prerequisites
- .NET SDK 7.0 or later
- SQL Server (LocalDB or full installation)
- Visual Studio 2022 or any compatible IDE
- Git (for version control)

## Getting Started


### 1. Clone the Repository
```bash
git clone https://github.com/Hossam-abdelmonem/CovidVaccinationSystem.git

### 2. Configure the Database Connection
Open appsettings.json and update the DefaultConnection

"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=CovidVaccinationSystem;Trusted_Connection=True;MultipleActiveResultSets=true"
}
 ---Update database

## Folder Structure
CovidVaccinationSystem/
│
├── CovidVaccinationSystem.Core/
│   ├── Entities/
│   ├── DTOs/
│   └── Interfaces/
│
├── CovidVaccinationSystem.Data/
│   ├── Contexts/
│   ├── Migrations/
│   ├── Repositories/
│   
│
├── CovidVaccinationSystem.Services/
│   ├── Interfaces/
│   ├── Implementations/
│   └── MappingProfile/  (AutoMapper Profiles)
│   └── Validation / (Fluent Validation)
│
├── CovidVaccinationSystem / StartUp Project
│   ├── Controllers/
│   └── Program.cs


## Conclusion

This project demonstrates my ability to design and implement a full-fledged REST API using best practices. I’ve prioritized scalability, maintainability, and clean code, which are essential for any production-grade application. I’m confident this solution can be expanded further based on the needs of the business.

Thank you for reviewing my work. I look forward to discussing how this solution aligns with your company's goals.




