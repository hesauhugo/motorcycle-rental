#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["MotorcycleRental.API/MotorcycleRental.API.csproj", "MotorcycleRental.API/"]
COPY ["MotorcycleRental.Application/MotorcycleRental.Application.csproj", "MotorcycleRental.Application/"]
COPY ["MotorcycleRental.Core/MotorcycleRental.Core.csproj", "MotorcycleRental.Core/"]
COPY ["MotorcycleRental.Infrastructure/MotorcycleRental.Infrastructure.csproj", "MotorcycleRental.Infrastructure/"]
RUN dotnet restore "./MotorcycleRental.API/./MotorcycleRental.API.csproj"
COPY . .
WORKDIR "/src/MotorcycleRental.API"
RUN dotnet build "./MotorcycleRental.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MotorcycleRental.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MotorcycleRental.API.dll"]