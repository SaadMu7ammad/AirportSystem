create database airline

use airline
DELETE FROM Passenger;

DELETE FROM Ticket;
DELETE FROM Passenger;
DELETE FROM Flight;


create table Flight(


flight_code int IDENTITY,
from_country varchar (255),
destination varchar (255),
date_flight date ,
price int  ,

);



create table Passenger(


id_passenger int IDENTITY,
name_passenger varchar (255),
nationality varchar (255),
phone_num varchar (255) ,

img varbinary(max)
);


Alter table Ticket alter column flight_code varchar (255) 
Alter table Ticket alter column price varchar (255) 

create table Ticket(


flight_code varchar ,
from_country varchar (255),
destination varchar (255),
date_flight date ,
price varchar   ,

name_passenger varchar (255),
nationality varchar (255),
phone_num varchar (255) ,
img varbinary(max)


);
