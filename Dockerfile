# Use official .NET image as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["spinalproject.csproj", "./"]
RUN dotnet restore "spinalproject.csproj"

COPY . .
RUN dotnet publish -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Ensure SQLite database file is available
VOLUME /app/Data
# Run database migrations before starting the app
COPY /app.db /app



ENTRYPOINT ["dotnet", "spinalproject.dll"]
