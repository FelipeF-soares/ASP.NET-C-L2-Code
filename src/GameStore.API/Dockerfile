# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas os arquivos de projeto (.csproj) primeiro
COPY GameStore.API/GameStore.API.csproj GameStore.API/
COPY GameStore.Application/GameStore.Application.csproj GameStore.Application/
COPY GameStore.Domain/GameStore.Domain.csproj GameStore.Domain/
COPY GameStore.Infrastructure/GameStore.Infrastructure.csproj GameStore.Infrastructure/

# Restaura as dependências
RUN dotnet restore GameStore.API/GameStore.API.csproj

# Copia o restante dos arquivos da solução
COPY . .

WORKDIR /src/GameStore.API
RUN dotnet build GameStore.API.csproj -c Release -o /app/build

# Publicação
FROM build AS publish
RUN dotnet publish GameStore.API.csproj -c Release -o /app/publish

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameStore.API.dll"]
