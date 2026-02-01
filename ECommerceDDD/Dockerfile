# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia solution e csproj primeiro (cache eficiente)
COPY ECommerceDDD.sln ./

COPY ECommerceDDD.Services.Api/ECommerceDDD.Services.Api.csproj ECommerceDDD.Services.Api/
COPY ECommerceDDD.Application/ECommerceDDD.Application.csproj ECommerceDDD.Application/
COPY ECommerceDDD.Domain/ECommerceDDD.Domain.csproj ECommerceDDD.Domain/
COPY ECommerceDDD.Infra.Data/ECommerceDDD.Infra.Data.csproj ECommerceDDD.Infra.Data/
COPY ECommerceDDD.Infra.IoC/ECommerceDDD.Infra.IoC.csproj ECommerceDDD.Infra.IoC/

# Restore APENAS da API (ela puxa as dependências)
RUN dotnet restore ECommerceDDD.Services.Api/ECommerceDDD.Services.Api.csproj

# Agora copia o resto do código
COPY . .

# Publish
RUN dotnet publish ECommerceDDD.Services.Api/ECommerceDDD.Services.Api.csproj -c Release -o /app/publish

# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ECommerceDDD.Services.Api.dll"]
