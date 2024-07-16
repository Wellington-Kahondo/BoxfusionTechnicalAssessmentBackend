# Employee Management Web API

## Overview

This project is an Employee Management Web API built using the ABP (Asp.Net Boilerplate) framework. The API provides a set of endpoints to manage employees, including creating, reading, updating, and deleting employee records.

## Features

- **CRUD Operations**: Create, read, update, and delete employee records.
- **Authentication and Authorization**: Secure API endpoints using JWT tokens.
- **Entity Framework Core**: Utilize EF Core for database interactions.
- **Modular Architecture**: Built with ABP's modular architecture for scalability and maintainability.
- **Swagger Integration**: API documentation and testing using Swagger UI.

## Prerequisites

- .NET SDK (version X.X.X or higher)
- SQL Server (or any other compatible database)
- Visual Studio or any other IDE supporting .NET development

## Getting Started

### Clone the Repository
```git clone https://github.com/Wellington-Kahondo/BoxfusionTechnicalAssessmentBackend```


## Setup the Database
 - Open the solution in Visual Studio.

 - Open the Package Manager Console (PMC) from Tools -> NuGet Package Manager -> Package Manager Console.

 - Set the default project to the EntityFrameworkCore project.

 - Run the following command to apply migrations and create the database:
```update-database```

## Run the Application
 - Set the *.Web project as the startup project.
 - Press F5 or run the application. This will start the web server and host the API.
