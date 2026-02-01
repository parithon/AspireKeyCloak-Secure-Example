# Aspire Keycloak Example

A .NET 10 example application demonstrating integration of **Keycloak** identity provider with **.NET Aspire** for distributed application development.

## Overview

This solution showcases how to set up and use Keycloak for authentication in a .NET Aspire-based application with multiple services:
- **AppHost**: Orchestrates the distributed application using .NET Aspire
- **Web**: A Razor-based frontend application
- **API**: A backend service (referenced by Web)
- **Keycloak**: Identity and access management provider

## Prerequisites

- .NET 10 SDK or later
- Docker (for Keycloak container)
- Visual Studio 2026 or Visual Studio Code

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd AspireKeycloakExample
```

### 2. Configure Parameters

The solution uses secure parameters for sensitive information:
- `keycloak-username`: Keycloak admin username
- `keycloak-password`: Keycloak admin password (secret)
- `keycloak-postman-secret`: Client secret for Postman (secret)
- `keycloak-weatherweb-secret`: Client secret for Web application (secret)

These can be configured via user secrets or environment variables during development.

### 3. Run the Application

```bash
dotnet run --project AspireKeycloakExample.AppHost
```

This will:
- Start Keycloak on port 8080
- Import configured realms from `./Keycloak-Realms`
- Start the API service
- Start the Web application

### 4. Access the Application

- **Web Application**: https://localhost:5001
- **Keycloak Admin**: http://localhost:8080 (use configured credentials)

## Project Structure

```
AspireKeycloakExample/
??? AspireKeycloakExample.AppHost/    # Aspire orchestration layer
?   ??? AppHost.cs                    # Distributed app configuration
??? AspireKeycloakExample.Web/        # Web application (Razor components)
?   ??? Program.cs                    # Startup configuration
??? AspireKeycloakExample.Api/        # API service
??? Keycloak-Realms/                  # Keycloak realm configuration
??? README.md
```

## Architecture

The application follows a distributed architecture pattern:

1. **AppHost** orchestrates all services using .NET Aspire
2. **Keycloak** provides centralized authentication
3. **Web** frontend consumes the API with Keycloak integration
4. **API** backend handles business logic with secured endpoints

## Configuration

### Keycloak Setup

Keycloak is configured with:
- Persistent container lifetime
- Realm import from `./Keycloak-Realms`
- Environment variables for client secrets
- Service dependencies managed by Aspire

### Service Dependencies

Services wait for their dependencies:
- Web waits for Keycloak and API
- API waits for Keycloak

This ensures proper startup order and service availability.

## Features

- ? Keycloak integration with .NET Aspire
- ? Secure parameter management
- ? Multi-service orchestration
- ? Razor-based UI components
- ? Containerized Keycloak instance

## Contributing

Contributions are welcome. Please follow the project's coding standards and submit pull requests for review.

## License

[Specify your license here]

## Support

For issues and questions, please [specify how to report issues].