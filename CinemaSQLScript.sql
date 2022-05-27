--create database CinemaProject
--go

create table Spectators(
SpectatorID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
Surname NVARCHAR(50),
BirthDate DATE NOT NULL,
)

create table Tickets(
TicketID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Price DECIMAL NOT NULL,
Discount DECIMAL NOT NULL,
SpectatorID INT NOT NULL REFERENCES  Spectators,
)

create table Cinemas(
CinemaID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name NVARCHAR(50),
)

create table Films(
FilmID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Title NVARCHAR(50) NOT NULL,
Genre NVARCHAR(50) NOT NULL,
Author NVARCHAR(50),
Producer NVARCHAR(50),
Duration NUMERIC,
)

create table MovieRooms(
RoomID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CinemaID INT NOT NULL REFERENCES Cinema,
Seatings INT NOT NULL,
FilmID INT NOT NULL REFERENCES  Films, 
)


