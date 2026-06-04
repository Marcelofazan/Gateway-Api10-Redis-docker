FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /Sistema
COPY ["Services/Pessoa/Sistema.Pessoa.API/Sistema.Pessoa.API.csproj", "Services/Pessoa/Sistema.Pessoa.API/"]
COPY ["Services/Pessoa/InfraEstrutura/InfraEstrutura.csproj", "Services/Pessoa/InfraEstrutura/"]
COPY ["Services/Pessoa/Dominio/Dominio.csproj", "Services/Pessoa/Dominio/"]
RUN dotnet restore "Services/Pessoa/Sistema.Pessoa.API/Sistema.Pessoa.API.csproj"
COPY . .
WORKDIR "/Sistema/Services/Pessoa/Sistema.Pessoa.API"
RUN dotnet build "Sistema.Pessoa.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sistema.Pessoa.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sistema.Pessoa.API.dll"]