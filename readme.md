1. run project
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
    Password NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE UserActivity (
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









