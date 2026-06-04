FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /Sistema
COPY ["ApiGateways/Base/Sistema.ApiGateway/Sistema.ApiGateway.csproj", "ApiGateways/Base/Sistema.ApiGateway/"]
RUN dotnet restore "ApiGateways/Base/Sistema.ApiGateway/Sistema.ApiGateway.csproj"
COPY . .
WORKDIR "/Sistema/ApiGateways/Base/Sistema.ApiGateway"
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sistema.ApiGateway.dll"]