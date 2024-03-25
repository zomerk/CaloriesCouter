# Use an official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CaloriesCouter/CaloriesCouter.csproj", "CaloriesCounter/"]
RUN dotnet restore "CaloriesCounter/CaloriesCounter.csproj"
COPY . .
WORKDIR "/src/CaloriesCounter"
RUN dotnet build "CaloriesCounter.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CaloriesCounter.csproj" -c Release -o /app/publish

# Create the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaloriesCounter.dll"]
