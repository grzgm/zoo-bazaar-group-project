# Zoo Bazaar

Zoo management system.

## Table of Contents

- [Zoo Bazaar](#zoo-bazaar)
  - [Table of Contents](#table-of-contents)
  - [About the Project](#about-the-project)
  - [Features](#features)
  - [Technologies Used](#technologies-used)
  - [Software Architecture](#software-architecture)
  - [Project Structure](#project-structure)
  - [Setup and Installation](#setup-and-installation)
  - [Contributors](#contributors)

## About the Project

**Course:** ICT & Software Engineering

**Semester:** 2

The project develops a software solution using .Net, ASP Razor Pages, Windows Forms Frameworks, and SQL Server to run an zoo management system.

## Features

- Managing zoo animals information
- Managers and animal caretakerss authentication system
- Role-Based access control
- Tracking animal metrics
- Time tables management
- Unit Tests

## Technologies Used

- **Programming Languages/Technologies:**
  - C#
  - SQL
  - HTML
  - CSS
- **Libraries/Frameworks:**
  - .NET 6.0
  - ASP.NET Core
  - Windows Forms
  - MSTest
  - Razor Pages
  - Electron
- **Tools:**
  - Visual Studio 2022
  - Git
  - GitLab
  - Microsoft SQL Server

## Software Architecture

The Synthesis Assignment System follows a 3-Tier Architecture to ensure modularity, scalability, and separation of concerns. The architecture consists of the following layers:

1. _Presentation Layer (**PL**)_: **Depends on the BLL Interfaces and <u>references DAL only for the use of Dependency Injection in Unit Tests</u>.**
   - _Web Interface (Razor Pages)_: Webpage for zoo animal caretakers.
   - _Desktop Interface (Electron Application)_: Desktop application providing zoo management functionality for managers.
2. _Business Logic Layer (**BLL**)_: Contains all the core business rules and application logic. **No dependencies.**
3. _Data Access Layer (**DAL**)_: This layer interacts directly with the database. It handles all CRUD operations and converts data into DTO's. **Depends on the BLL Interfaces**

```
+---------------------------------------+
|           Presentation Layer          |
|---------------------------------------|
|                                       |
|       Display generated content       |
|                                       |
+---------------------------------------+
                    |
                    |   Dependency Inversion
                    ▼
+---------------------------------------+
|         Business Logic Layer          |
|---------------------------------------|
|                                       |
|    Handles core application rules     |
|                                       |
+---------------------------------------+
                    ▲
                    |   Dependency Inversion
                    |
+---------------------------------------+
|          Data Access Layer            |
|---------------------------------------|
|                                       |
|    CRUD operations on SQL database    |
|                                       |
+---------------------------------------+

```

## Project Structure

```
synthesis-assignment/
├── ZooBazaar_Solution
│   ├── ZooBazaar_Desktop_App/                      # PL Electron Application Source Code
|   |
│   ├── ZooBazaar_ASP_NET/                          # PL Razor Pages Source Code
|   |
│   ├── ZooBazaar_Windows_Forms_Application/        # PL Windows Forms Source Code
|   |
│   ├── ZooBazaar_ClassLibrary/                     # BLL Source Code
│   |   └── Interfaces/                             # Interfaces for Dependency Inversion
|   |
│   ├── DomainModels/                               # BLL Models
|   |
│   ├── ZooBazaar_Interfaces/                       # DTO Interfaces
|   |
│   ├── ZooBazaar_Repositories/                     # DAL Source Code
|   |
│   └── UnitTests/                                  # Unit Tests
|
└── README.md
```

## Setup and Installation

Follow the instructions below to set up the project on your local machine.

1. **Clone the Repository**
   ```
   git clone https://github.com/your-username/project-repo-name.git
   cd project-repo-name
   ```
2. **Install Dependencies**
   ```
   dotnet restore
   ```
3. **Compile/Build the Project**
   ```
   dotnet build
   ```
4. **Run Unit Tests**
   ```
   dotnet test
   ```
5. **Run the Project**
   ```
   dotnet run
   ```

## Contributors

- [Grzegorz Malisz](https://github.com/grzgm): PL, BLL.
- [Michał Raczkowski](https://github.com/michal-raczkowski): BLL, DAL.
- [Ryan Bakeroot](https://github.com/): DAL.
- [Jesper Seipenbusch](https://github.com/): PL.
