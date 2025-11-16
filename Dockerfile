# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./ProductsAPIForTechGig.csproj"
RUN dotnet publish "./ProductsAPIForTechGig.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Create directory for SQLite database file
RUN mkdir -p /app/data

COPY --from=build /app/publish .

# Expose port
EXPOSE 7151

# Set environment variables
ENV ASPNETCORE_URLS=http://+:7151
ENV USE_SQLITE=true

ENTRYPOINT ["dotnet", "ProductsAPIForTechGig.dll"]
