# Use the official Microsoft .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file(s) and restore dependencies
COPY ./api/*.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY ./api/ ./

# Publish the application
RUN dotnet publish -c Release -o out

# Use the official Microsoft .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory in the container
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build-env /app/out .

# Expose the port the app runs on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "api.dll"]
