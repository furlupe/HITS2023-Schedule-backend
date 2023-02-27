# Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./Schedule.csproj" --disable-parallel
RUN dotnet publish "./Schedule.csproj" -c release -o /app --no-restore

# Serve
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS serve
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Schedule.dll"]