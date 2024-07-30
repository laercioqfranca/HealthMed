#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HealthMed.Web/HealthMed.Web.csproj", "HealthMed.Web/"]
COPY ["HealthMed.Application/HealthMed.Application.csproj", "HealthMed.Application/"]
COPY ["HealthMed.Core/HealthMed.Core.csproj", "HealthMed.Core/"]
COPY ["HealthMed.Domain/HealthMed.Domain.csproj", "HealthMed.Domain/"]
COPY ["HealthMed.Infra.IoC/HealthMed.Infra.IoC.csproj", "HealthMed.Infra.IoC/"]
COPY ["HealthMed.Infra.Bus/HealthMed.Infra.Bus.csproj", "HealthMed.Infra.Bus/"]
COPY ["HealthMed.Infra.Data/HealthMed.Infra.Data.csproj", "HealthMed.Infra.Data/"]
RUN dotnet restore "./HealthMed.Web/./HealthMed.Web.csproj"
COPY . .
WORKDIR "/src/HealthMed.Web"
RUN dotnet build "./HealthMed.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HealthMed.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthMed.Web.dll"]