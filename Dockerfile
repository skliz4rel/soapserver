FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ConsumeSoap.RestApi/ConsumeSoap.RestApi.csproj", "ConsumeSoap.RestApi/"]
RUN dotnet restore "ConsumeSoap.RestApi/ConsumeSoap.RestApi.csproj"
COPY . .
WORKDIR "/src/ConsumeSoap.RestApi"
RUN dotnet build "ConsumeSoap.RestApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ConsumeSoap.RestApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ConsumeSoap.RestApi.dll"]