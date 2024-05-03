#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["bt.rent.car.api/bt.rent.car.api.csproj", "bt.rent.car.api/"]
COPY ["bt.rent.car.db/bt.rent.car.db.csproj", "bt.rent.car.db/"]
COPY ["bt.rent.car.model/bt.rent.car.model.csproj", "bt.rent.car.model/"]
COPY ["bt.rent.car.services/bt.rent.car.services.csproj", "bt.rent.car.services/"]
COPY ["bt.rent.car.exceptions/bt.rent.car.exceptions.csproj", "bt.rent.car.exceptions/"]
RUN dotnet restore "./bt.rent.car.api/bt.rent.car.api.csproj"
COPY . .
WORKDIR "/src/bt.rent.car.api"
RUN dotnet build "./bt.rent.car.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./bt.rent.car.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bt.rent.car.api.dll"]