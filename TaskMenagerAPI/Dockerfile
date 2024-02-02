# Użyj obrazu SDK .NET Core do zbudowania aplikacji
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Skopiuj csproj i przywróć zależności
COPY *.csproj ./
RUN dotnet restore

# Skopiuj resztę plików i zbuduj aplikację
COPY . ./
RUN dotnet publish -c Release -o out

# Użyj obrazu runtime .NET Core do uruchomienia aplikacji
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TaskMenagerAPI.dll"] 