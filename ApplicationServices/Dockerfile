#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApplicationServices/ApplicationServices.csproj", "ApplicationServices/"]
RUN dotnet restore "./ApplicationServices/./ApplicationServices.csproj"
COPY . .
WORKDIR "/src/ApplicationServices"
RUN dotnet build "./ApplicationServices.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApplicationServices.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ConnectionStrings__SecurityEndPoint="http://localhost:9060/api/tokens"

ENV ConnectionStrings__CountriesEndPoint="http://156.35.98.149:8081/travelApi/api/v1/countries"
ENV ConnectionStrings__AirportsEndPoint="http://156.35.98.149:8081/travelApi/api/v1/airports"
ENV ConnectionStrings__FlightEndPoint="http://156.35.98.149:8081/travelApi/api/v1/flights"

ENV ConnectionStrings__AppDataFlightServiceEndPoint="http://156.35.98.149:9090/FlightServices.svc"
ENV ConnectionStrings__AppDataReservationServiceEndPoint="http://156.35.98.149:9090/ReservationServices.svc"
ENV ConnectionStrings__AppDataUserServiceEndPoint="http://156.35.98.149:9090/UserServices.svc"

ENTRYPOINT ["dotnet", "ApplicationServices.dll"]