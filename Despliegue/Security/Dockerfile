#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Security/Security.csproj", "Security/"]
RUN dotnet restore "./Security/./Security.csproj"
COPY . .
WORKDIR "/src/Security"
RUN dotnet build "./Security.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Security.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

#COPY ./Security/certificate.pfx /app/publish/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS="https://+;http://+"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="secreto"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="certificate.pfx"
ENTRYPOINT ["dotnet", "Security.dll"]