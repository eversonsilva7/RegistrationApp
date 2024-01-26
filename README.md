# RegistrationApp
 The "Registration App" project is an application developed in C# using a microservices architecture. The main purpose is to manage information related to the registration of personal data and integration with external services.

# Microservices System

## Main Microservices

1. **Client Microservice:**
   - Responsible for managing information related to customers, including registration, update, and removal.
   - Provides HTTP services through controllers.

2. **Partner System Microservice(not finished):**
   - Integrates customer registrations.
   - Provides HTTP services through controllers.

## Design Patterns Used

- **Repository Pattern with Unit of Work:**
  - Used to manage database operations cohesively in each microservice.
  - Allows grouping database operations into a single transaction, ensuring data consistency.

## Language

- C# (.Net 6)

## Architecture

### Domain-Driven Design (DDD)

- Structures the code around the problem domain.
- Entities, aggregates, domain services, and value objects are modeled according to the specific context of each microservice.

### Clean Architecture

- Organizes the code in a way that dependency layers decrease as we approach the core of the application.
- External layers (such as the user interface and infrastructure details) depend only on internal layers, maintaining flexibility and facilitating maintenance.

## Additional Patterns

- **Unit of Work:**
  - Pattern used to manage transactions and database operations cohesively in each microservice.
  - Groups database operations into a single transaction, ensuring data consistency.

- **Dependency Injection:**
  - Facilitates maintenance and testing of each component.
  - Services and dependencies are injected through a DI container, promoting inversion of control and decoupling of components.

## Background Jobs

- **Hangfire for Background Jobs:**
  - Utilized Hangfire for managing background jobs, enhancing the system's ability to handle asynchronous tasks efficiently.
