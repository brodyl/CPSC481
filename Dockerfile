# Use the .NET 6.0 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o /app/publish --no-restore

# Use the Nginx image for the final image
FROM nginx:stable

# Copy the published application from the build stage
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Expose the default port for Nginx
EXPOSE 80

# Start the Nginx server
CMD ["nginx", "-g", "daemon off;"]
