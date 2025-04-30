# Inventory Management API

A simple inventory management system built with .NET and JWT-based authentication. It provides RESTful APIs for managing Inventory Master and Inventory Items.
It uses a SQL Server database, Entity Framework Core, and Swagger for testing and documentation. JWT-based authentication is applied to secure specific endpoints.

### Features

- CRUD operations for Inventory Master and Inventory Item entities
- JWT-based authentication and authorization
- Swagger UI integration
- Filter API to search items by name

## Setup Instructions

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/)
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended)

### Database Setup

Execute the `Dbscript.sql` file to create the required database schema.

### Configuration

1. Open `appsettings.json`.
2. Update the `ConnectionStrings` section with your SQL Server connection string.


## How to Run

### In Visual Studio
1. Open the project in **Visual Studio**.
2. Build and run the application.
3. The Swagger UI will open automatically in your browser.
4. Use the Swagger UI to explore and test the API endpoints.

### In Terminal
1. Open the project directory in the terminal
2. Run the following commands
   ```
   dotnet restore
   dotnet build --no-restore
   dotnet run --project "Inventory Management/Inventory Management.csproj"
   ```
3. Open http://localhost:5079/index.html in the browser which will provide you the swagger UI to test

### Authentication

- JWT authentication is used for protected routes.
- Only the `GetAll` endpoint of the Inventory Master API is secured.
- Use the following credentials to authenticate:
			Username: *admin* 
			Password: *password*
- After logging in, copy the token and use it in the Swagger UI's Authorize dialog as Bearer {token}

## API Definition
API definition of the project can be viewed in the [swagger.yaml](swagger.yaml) file
