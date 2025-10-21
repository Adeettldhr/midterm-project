# Documentation for Library Management System

## Overview
The Library Management System is a web application designed to facilitate the management of library operations. It allows users to interact with various entities such as books, authors, customers, and more, providing both user and admin functionalities.

## Features
- **User Features:**
    - Browse books and authors
    - Register as customers
    - Borrow and return books
    - Submit reviews for books

- **Admin Features:**
    - Manage books, authors, categories, and library branches
    - Manage librarian accounts
    - View borrow records and customer details

## Technologies Used
- **Backend:** ASP.NET Core MVC (.NET 8)
- **Database:** SQLite (EF Core ORM)
- **Frontend:** Razor Views, Bootstrap 5
- **Tools:** Visual Studio / Visual Studio Code

## Project Structure
The project is organized into several directories:
- **Controllers:** Contains the logic for handling requests and responses.
- **Models:** Defines the data structures used in the application.
- **Views:** Contains the UI components of the application.
- **Data:** Manages database context and seeding.
- **wwwroot:** Contains static files such as CSS and JavaScript.

## Getting Started
### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 / VS Code
- SQLite

### Installation Steps
1. Clone the repository:
     git clone https://github.com/Adeettldhr/midterm-project
     cd midterm_project

2. Create a new database:
        dotnet ef database update

3. Run the application:
        dotnet run

4. Open your web browser and navigate to `http://localhost:5204` to access the Library Management System.

