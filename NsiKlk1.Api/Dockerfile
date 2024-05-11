FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NsiKlk1.Api/NsiKlk1.Api.csproj", "NsiKlk1.Api/"]
COPY ["NsiKlk1.Infrastructure/NsiKlk1.Infrastructure.csproj", "NsiKlk1.Infrastructure/"]
COPY ["NsiKlk1.Application/NsiKlk1.Application.csproj", "NsiKlk1.Application/"]
COPY ["NsiKlk1.Domain/NsiKlk1.Domain.csproj", "NsiKlk1.Domain/"]
RUN dotnet restore "NsiKlk1.Api/NsiKlk1.Api.csproj"
COPY . .
WORKDIR "/src/NsiKlk1.Api"
RUN dotnet build "NsiKlk1.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NsiKlk1.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NsiKlk1.Api.dll"]
