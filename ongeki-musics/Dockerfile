#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ongeki-musics/ongeki-musics.csproj", "ongeki-musics/"]
RUN dotnet restore "ongeki-musics/ongeki-musics.csproj"
COPY . .
WORKDIR "/src/ongeki-musics"
RUN dotnet build "ongeki-musics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ongeki-musics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ongeki-musics.dll"]