#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /Sistema
COPY ["Services/Produto/Sistema.Produto.API/Sistema.Produto.API.csproj", "Services/Produto/Sistema.Produto.API/"]
COPY ["Services/Produto/InfraEstrutura/InfraEstrutura.csproj", "Services/Produto/InfraEstrutura/"]
COPY ["Services/Produto/Dominio/Dominio.csproj", "Services/Produto/Dominio/"]
RUN dotnet restore "Services/Produto/Sistema.Produto.API/Sistema.Produto.API.csproj"
COPY . .
WORKDIR "/Sistema/Services/Produto/Sistema.Produto.API"
RUN dotnet build "Sistema.Produto.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sistema.Produto.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sistema.Produto.API.dll"]