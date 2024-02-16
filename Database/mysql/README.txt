Arrancar en docker

docker build -t travel_agency_mysql .
docker run -d -p 3306:3306 -v mysql_data:/var/lib/mysql travel_agency_mysql


---------------------
Para generar el esquema de base de datos desde Visual

Herramientas -> paquetes nuget -> consola

Asegurarse de seleccionar el proyecto DataService

correr el siguiente comando 

	Add-Migration Initial

Cuando finalice, lanzar

	Update-Database

--------------------------


