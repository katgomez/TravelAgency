FROM tomcat:10.1.18-jre17

# Copiamos el archivo WAR a la carpeta webapps de Tomcat
COPY travelApi.war /usr/local/tomcat/webapps/

ENV AMADEUS_CLIENT_ID=GOAxlG2ufTnqTTA0e8yzSOGUh7LA8EeA
ENV AMADEUS_CLIENT_SECRET=VhG6GJWyz4DL0NtF

# Exponemos el puerto 8080 en el contenedor
EXPOSE 8080

# Comando para iniciar Tomcat cuando se inicie el contenedor
CMD ["catalina.sh", "run"]
