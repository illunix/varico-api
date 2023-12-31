#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Varico.Api/Varico.Api.csproj", "src/Varico.Api/"]
COPY ["src/Varico.Application/Varico.Application.csproj", "src/Varico.Application/"]
COPY ["src/Varico.Core/Varico.Core.csproj", "src/Varico.Core/"]
COPY ["src/Varico.Infrastructure/Varico.Infrastructure.csproj", "src/Varico.Infrastructure/"]
RUN dotnet restore "./src/Varico.Api/./Varico.Api.csproj"
COPY . .
WORKDIR "/src/src/Varico.Api"
RUN dotnet build "./Varico.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Varico.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Varico.Api.dll"]