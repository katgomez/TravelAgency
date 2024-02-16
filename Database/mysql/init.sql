CREATE DATABASE IF NOT EXISTS travelAgency;
USE travelAgency;

CREATE USER 'usuario'@'%' IDENTIFIED BY 'contraseña';
GRANT ALL PRIVILEGES ON travelAgency.* TO 'usuario'@'%';

use travelAgency;

-- Singular Names
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    firstName VARCHAR(255),
    lastName VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS reservations (
    id INTEGER PRIMARY KEY,
    userID INTEGER,
    reservationDate DATE,
    numberOfClients INTEGER,
    reservationStatus VARCHAR(255),
    price DECIMAL(10, 2),
    FOREIGN KEY (userID) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS flights (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    flightId VARCHAR(255) NOT NULL,
    airline VARCHAR(255),
    destinationAirport VARCHAR(255),
    destinationDate DATE,
    departureAirport VARCHAR(255),
    departureDate DATE,
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservations(id)
);

CREATE TABLE IF NOT EXISTS hotels (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    hotelId VARCHAR(255) NOT NULL,
    hotelName VARCHAR(255),
    checkInDate DATE,
    checkOutDate DATE,
    location VARCHAR(255),
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservations(id)
);

CREATE TABLE IF NOT EXISTS activities (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    activityId VARCHAR(255) NOT NULL,
    activityName VARCHAR(255),
    activityDate DATE,
    location VARCHAR(255),
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservations(id)
);

