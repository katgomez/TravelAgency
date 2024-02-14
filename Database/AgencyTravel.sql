-- Singular Names
CREATE TABLE IF NOT EXISTS user (
    id INTEGER PRIMARY KEY,
    username TEXT NOT NULL,
    email TEXT UNIQUE NOT NULL,
    password TEXT NOT NULL,
    firstName TEXT,
    lastName TEXT
);

CREATE TABLE IF NOT EXISTS reservation (
    id INTEGER PRIMARY KEY,
    userID INTEGER,
    reservationDate DATE,
    numberOfClients INTEGER,
    reservationStatus TEXT,
    price DECIMAL(10, 2),
    FOREIGN KEY (userID) REFERENCES user(id)
);

CREATE TABLE IF NOT EXISTS flight (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    flightId TEXT NOT NULL,
    airline TEXT,
    destinationAirport TEXT,
    destinationDate DATE,
    departureAirport TEXT,
    departureDate DATE,
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservation(id)
);

CREATE TABLE IF NOT EXISTS hotel (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    hotelId TEXT NOT NULL,
    hotelName TEXT,
    checkInDate DATE,
    checkOutDate DATE,
    location TEXT,
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservation(id)
);

CREATE TABLE IF NOT EXISTS activity (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    activityId TEXT NOT NULL,
    activityName TEXT,
    activityDate DATE,
    location TEXT,
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservation(id)
);

-- Plural Names
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY,
    username TEXT NOT NULL,
    email TEXT UNIQUE NOT NULL,
    password TEXT NOT NULL,
    firstName TEXT,
    lastName TEXT
);

CREATE TABLE IF NOT EXISTS reservations (
    id INTEGER PRIMARY KEY,
    userID INTEGER,
    reservationDate DATE,
    numberOfClients INTEGER,
    reservationStatus TEXT,
    price DECIMAL(10, 2),
    FOREIGN KEY (userID) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS flights (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    flightId TEXT NOT NULL,
    airline TEXT,
    destinationAirport TEXT,
    destinationDate DATE,
    departureAirport TEXT,
    departureDate DATE,
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservations(id)
);

CREATE TABLE IF NOT EXISTS hotels (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    hotelId TEXT NOT NULL,
    hotelName TEXT,
    checkInDate DATE,
    checkOutDate DATE,
    location TEXT,
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservations(id)
);

CREATE TABLE IF NOT EXISTS activities (
    id INTEGER PRIMARY KEY,
    reservationID INTEGER,
    activityId TEXT NOT NULL,
    activityName TEXT,
    activityDate DATE,
    location TEXT,
    price DECIMAL(10, 2),
    FOREIGN KEY (reservationID) REFERENCES reservations(id)
);
