FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PawPatrol.Api/PawPatrol.Api.csproj", "src/PawPatrol.Api/"]
COPY ["src/PawPatrol.Domain/PawPatrol.Domain.csproj", "src/PawPatrol.Domain/"]
COPY ["src/PawPatrol.Application/PawPatrol.Application.csproj", "src/PawPatrol.Application/"]
COPY ["src/PawPatrol.Infrastructure/PawPatrol.Infrastructure.csproj", "src/PawPatrol.Infrastructure/"]
RUN dotnet restore "src/PawPatrol.Api/PawPatrol.Api.csproj"
COPY . .
WORKDIR "/src/src/PawPatrol.Api"
RUN dotnet build "PawPatrol.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PawPatrol.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PawPatrol.Api.dll"]
