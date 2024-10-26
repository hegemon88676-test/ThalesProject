# Coding Challenge: Real-Time Soldier Movement Tracking

## Overview
This document outlines the solution for a coding challenge aimed at developing a WPF application that provides real-time updates on soldier movements based on sensor data. The application dynamically updates soldier positions on a map and saves them to a database. Users can click on markers to access supplementary details about soldiers. The solution emphasizes performance optimization, especially when handling a large number of markers and frequent updates.

## Requirements
- **Environment**: Visual Studio, WPF, MVVM, Entity Framework, MSSQL Server

## Problem Statement
Develop a system that provides evaluators with real-time updates on soldier movements based on sensor data. The system should:
- Dynamically update soldier positions on a map based on GPS coordinates.
- Save soldier positions to a database.
- Allow users to click on markers to access supplementary details about soldiers, including their current position, rank, country, and training information.
- Optimize performance for handling a substantial volume of markers and frequent updates.

## Tasks
- [x] Draw architecture and ERD diagrams of the solution.
- [ ] Implement application structure and write functions to show the current position of soldiers on a map based on sensor data.
- [ ] Write functions that show the movement of soldiers using markers with animation effects.
- [ ] Write unit tests for the code.
- [ ] Write end-to-end integration tests for the movement of soldiers.

## Solution

### 1. Architecture and ERD Diagrams
- **Architecture Diagram**: Illustrates the overall structure of the application, including the interaction between the WPF client, services, and the database.
- **ERD Diagram**: Shows the relationships between the `Soldier` and `Position` entities.


#### Architecture Diagram
The architecture of the WPF application for real-time soldier movement tracking can be visualized as follows:
```
+---------------------+       +---------------------+       +---------------------+       +---------------------+
|  Presentation Layer |       |     Service Layer   |       |  Data Access Layer  |       |       Database      |
|  (WPF Views, MVVM)  |       |  (Business Logic)   |       |  (Entity Framework) |       |   (MSSQL Server)    |
+---------------------+       +---------------------+       +---------------------+       +---------------------+
|                     |       |                     |       |                     |       |                     |
| +-----------------+ |       | +-----------------+ |       | +-----------------+ |       | +-----------------+ |
| | MainWindow.xaml |<------->| | SoldierService  |<------->| | MilitaryContext |<------->| | Soldiers Table  | |
| +-----------------+ |       | +-----------------+ |       | +-----------------+ |       | +-----------------+ |
|                     |       |                     |       |                     |       |                     |
| +-----------------+ |       | +-----------------+ |       | +-----------------+ |       | +-----------------+ |
| | MapView.xaml    |<------->| | PositionService |<------->| | Soldier Model   |<------->| | Positions Table | |
| +-----------------+ |       | +-----------------+ |       | +-----------------+ |       | +-----------------+ |
|                     |       |                     |       |                     |       |                     |
| +-----------------+ |       |                     |       | +-----------------+ |       |                     |
| | ViewModel       |<------->|                     |       | | Position Model  |<------->|                     |
| +-----------------+ |       |                     |       | +-----------------+ |       |                     |
+---------------------+       +---------------------+       +---------------------+       +---------------------+
```
#### Entity-Relationship Diagram (ERD)
The ERD for the `Soldier` and `Position` models can be visualized as follows:
```
+-----------------+       +-----------------+
|    Soldier      |       |    Position     |
+-----------------+       +-----------------+
| SoldierID (PK)  |<----->| PositionID (PK) |
| Name            |       | SoldierID (FK)  |
| Rank            |       | Latitude        |
| Country         |       | Longitude       |
| TrainingInfo    |       | Timestamp       |
+-----------------+       +-----------------+
```

### 2. Set Up the Environment
- Create a new WPF App (.NET Core) project in Visual Studio.
- Install the necessary packages using NuGet Package Manager:
  ```bash
  Install-Package Microsoft.EntityFrameworkCore
  Install-Package Microsoft.EntityFrameworkCore.SqlServer
  Install-Package Microsoft.EntityFrameworkCore.InMemory
  Install-Package Microsoft.EntityFrameworkCore.Tools
  Install-Package xunit
  Install-Package xunit.runner.visualstudio
  Install-Package Moq
  ```

### 3. Define the Models
- **Soldier Model**: Represents a soldier with properties such as `SoldierID`, `Name`, `Rank`, `Country`, `TrainingInfo`, and a navigation property for `Positions`.
- **Position Model**: Represents a position with properties such as `PositionID`, `SoldierID`, `Latitude`, `Longitude`, `Timestamp`, and a navigation property for `Soldier`.

### 4. Create the DbContext
- **MilitaryContext**: Inherits from `DbContext` and includes `DbSet<Soldier>` and `DbSet<Position>`. Configures the database connection string and model relationships.

### 5. Configure the Connection String
- Add a connection string to `appsettings.json` for the SQL Server database.

### 6. Register Services in the Dependency Injection Container
- In `Startup.cs`, register the `MilitaryContext` and service interfaces with their implementations.

### 7. Implement the Services
- **ISoldierService**: Interface for soldier data access.
- **IPositionService**: Interface for position data access.

### 8. Implement the ViewModel
- **SoldierViewModel**: Handles data and logic for soldier data.

### 9. Implement the Map View
- **MapView**: User control to display soldier positions on a map.

### 10. Implement the Main Window
- **MainWindow**: Hosts the `MapView` and other UI elements.

### 11. Configure Dependency Injection
- Ensure that all services and DbContext are properly configured for dependency injection in `Startup.cs`.

### 12. Run Migrations
- Use Entity Framework Core tools to create and apply migrations to set up the database schema.

### 13. Write Unit and Integration Tests
- Use xUnit and Moq to write unit and integration tests for the application.

### 14. Optimize Performance
- Implement strategies to handle large volumes of markers and frequent updates efficiently.

## Conclusion
This guide provides a comprehensive overview of setting up and developing a WPF application for real-time soldier movement tracking. Follow the steps outlined to build and optimize your application.
