# Multi-stage build for .NET 10 application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers for better caching
COPY ["EmployeeManagementPortal/EmployeeManagementPortal.csproj", "EmployeeManagementPortal/"]
RUN dotnet restore "EmployeeManagementPortal/EmployeeManagementPortal.csproj"

# copy everything and build
COPY . .
WORKDIR /src/EmployeeManagementPortal
RUN dotnet publish "EmployeeManagementPortal.csproj" -c Release -o /app/publish

# runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "EmployeeManagementPortal.dll"]
