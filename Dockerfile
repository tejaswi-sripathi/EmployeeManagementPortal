# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY EmployeeManagementPortal.csproj .
RUN dotnet restore EmployeeManagementPortal.csproj

# Copy the remaining source code
COPY . .

# Publish the application
RUN dotnet publish EmployeeManagementPortal.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Render provides the PORT environment variable
ENV ASPNETCORE_URLS=http://+:10000

COPY --from=build /app/publish .

EXPOSE 10000

ENTRYPOINT ["dotnet", "EmployeeManagementPortal.dll"]