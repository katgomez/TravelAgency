CREATE DATABASE IF NOT EXISTS travelAgency;
USE travelAgency;

CREATE USER 'usuario'@'%' IDENTIFIED BY 'contraseña';
GRANT ALL PRIVILEGES ON travelAgency.* TO 'usuario'@'%';
