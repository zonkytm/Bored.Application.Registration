FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Bored.Application.Registration.Migrations/Bored.Application.Registration.Migrations.csproj", "Bored.Application.Registration.Migrations/"]
RUN dotnet restore "src/Bored.Application.Registration.Migrations/Bored.Application.Registration.Migrations.csproj"
COPY . .
WORKDIR "/src/Bored.Application.Registration.Migrations"
RUN dotnet build "Bored.Application.Registration.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bored.Application.Registration.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bored.Application.Registration.Migrations.dll"]
