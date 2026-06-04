#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /Sistema
COPY ["Services/Agrupador/Sistema.Agrupador.API/Sistema.Agrupador.API.csproj", "Services/Agrupador/Sistema.Agrupador.API/"]
COPY ["Infra/Sistema.Infra.Redis/Sistema.Infra.Redis.csproj", "Infra/Sistema.Infra.Redis/"]
RUN dotnet restore "Services/Agrupador/Sistema.Agrupador.API/Sistema.Agrupador.API.csproj"
COPY . .
WORKDIR "/Sistema/Services/Agrupador/Sistema.Agrupador.API"
RUN dotnet build "Sistema.Agrupador.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sistema.Agrupador.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sistema.Agrupador.API.dll"]