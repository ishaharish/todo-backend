# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY TodoApi.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build and publish the application
RUN dotnet publish -c Release -o /app/publish

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the published artifacts from the build stage
COPY --from=build /app/publish ./

# Expose port 5240, which matches what the frontend is expecting
EXPOSE 5240

# Configure ASP.NET Core to listen on the exposed port
ENV ASPNETCORE_URLS=http://+:5240

# Start the application
ENTRYPOINT ["dotnet", "TodoApi.dll"]
