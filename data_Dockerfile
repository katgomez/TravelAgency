#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DataServices/DataServices.csproj", "DataServices/"]
RUN dotnet restore "./DataServices/./DataServices.csproj"
COPY . .
WORKDIR "/src/DataServices"
RUN dotnet build "./DataServices.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DataServices.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ConnectionStrings__AgencyTravelMysql="server=156.35.98.149;port=3306;database=travelAgency;user=root;Password=travel_root_pass;"
ENTRYPOINT ["dotnet", "DataServices.dll"]