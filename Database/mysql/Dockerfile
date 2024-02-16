FROM mysql:latest

# Variables de entorno para configurar la base de datos
ENV MYSQL_DATABASE=travelAgency \
    MYSQL_USER=travel_agency \
    MYSQL_PASSWORD=travel_agency_pass \
    MYSQL_ROOT_PASSWORD=travel_root_pass

EXPOSE 3306

# Script de inicialización para crear la base de datos y el usuario
COPY init.sql /docker-entrypoint-initdb.d/