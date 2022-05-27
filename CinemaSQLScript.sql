create database CinemaProject
go

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
SpectatorID INT NOT NULL REFERENCES Spectators,
FilmID INT NOT NULL REFERENCES Films,
IsValid NVARCHAR(10)
)

create table Cinemas(
CinemaID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name NVARCHAR(50),
Location NVARCHAR(100),
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
CinemaID INT NOT NULL REFERENCES Cinemas,
MaxSeatings INT NOT NULL,
FilmID INT NOT NULL REFERENCES  Films, 
Seatings INT Default 0
)

--INSERT INTO Cinemas VALUES ('Kinemax','Mofalcone')

--INSERT INTO Spectators VALUES ('Mario','Rossi','1950-10-04')
--INSERT INTO Spectators VALUES ('Valentina','Rossi','2000-10-06')
--INSERT INTO Spectators VALUES ('Giovanni','Binachi','1990-10-10')
--INSERT INTO Spectators VALUES ('Claudia','Bianchi','2018-01-01')

--INSERT INTO Films VALUES ('Avenger','Fantascentific', 'Marvel','Marvel Studios',120)
--INSERT INTO Films VALUES ('Avenger End Games','Fantascentific', 'Marvel','Marvel Studios',140)
--INSERT INTO Films VALUES ('Spiderman','Fantascentific', 'Marvel','Marvel Studios',240)
--INSERT INTO Films VALUES ('Saw','Horror', 'Billy Pupazzo','Horror Studios',120)
--INSERT INTO Films VALUES ('Loney Tunes','Cartoon', 'Bucs Bunny','Warner Bros',90)

--INSERT INTO MovieRooms VALUES (1,200,1,0)
--INSERT INTO MovieRooms VALUES (1,250,2,0)

--INSERT INTO Tickets VALUES (5,0, 1,1,'true')
--INSERT INTO Tickets VALUES (5,10, 3,1,'true')
--INSERT INTO Tickets VALUES (6,0, 4,4,'true')



select * from Spectators
select * from MovieRooms
select * from Cinemas
select * from Films
select * from Tickets

select t.TicketID, t.Price, t.Discount
from Tickets T
Join Films f On f.FilmID = t.FilmID
Join Spectators s On s.SpectatorID = t.SpectatorID

select MR.RoomID, MR.CinemaID, f.*, s.Name, s.Surname, s.BirthDate
from MovieRooms MR
Join Films F ON F.FilmID = MR.FilmID
Join Tickets t ON t.FilmID = MR.FilmID
Join Spectators s On s.SpectatorID = t.SpectatorID
where MR.RoomID = 2


select f.FilmID, f.(t.Price)As Total from Tickets t
join Films f on f.FilmID = t.FilmID
where t.FilmID = 1

