Backend (ASP.NET Core)

The project uses ASP.NET Core as the backend framework.
It has a database ( likely SQL Server) with two tables: Users and UserActivity.
The Users table has columns for Id, Username, and possibly other fields.
The UserActivity table has columns for Id, UserId (foreign key referencing the Users table), IsActive, and UpdatedAt.
There is a stored procedure UpdateUserActivitiesBulk that updates the UserActivity table in bulk.
The backend has services for user management (_userService) and user activity management (_userActivityService).
The services are used to retrieve users and user activities from the database.
Frontend (Vue.js)

The project uses Vue.js as the frontend framework.
The frontend has a WelcomePage component that displays a welcome message to authenticated users.
The project uses Vuex for state management and Vue Router for client-side routing.
API

The backend exposes an API that returns a list of users with their corresponding user activities.
The API is likely used by the frontend to retrieve data and display it to the user.
Database Setup

The project uses a docker-compose file to set up a database container.
The database is created using a SQL script that creates the Users and UserActivity tables, as well as the UpdateUserActivitiesBulk stored procedure.
Overall, this project appears to be a simple web application that manages user data and user activities, with a backend API and a frontend UI built using Vue.js.

Setup
1. run project mssql
    docker-compose up

2. run script for creating database

CREATE DATABASE evalution
ON PRIMARY (
    NAME = evalution_data,
    FILENAME = '/var/opt/mssql/data/evalution.mdf',
    SIZE = 10MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 5MB
)
LOG ON (
    NAME = evalution_log,
    FILENAME = '/var/opt/mssql/data/evalution.ldf',
    SIZE = 5MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 5MB
);

USE evalution;
GO
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
);

CREATE TABLE UserActivities (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    IsActive BIT NOT NULL,
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_UserActivity_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);

4. add table type and prcedure  UpdateUserActivitiesBulk 

CREATE TYPE UsersTableType AS TABLE
(
    Id INT,
    IsActive BIT
);

USE evalution;
GO
CREATE PROCEDURE UpdateUserActivitiesBulk
    @Users UsersTableType READONLY
AS
BEGIN
    UPDATE u
    SET u.IsActive = us.IsActive
    FROM UserActivities u
    INNER JOIN @Users us ON u.Id = us.Id
END




3. run 
 dotnet watch run --project EvaluationApp.csproj --build Debug --launch EvaluationApp.dll
 cd app  @@ npm run serve









