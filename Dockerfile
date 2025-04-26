# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia a solução e restaura as dependências
COPY ./*.sln ./
COPY ./src/maschion.API/*.csproj ./src/maschion.API/
RUN dotnet restore ./src/maschion.API/maschion.API.csproj

# Copia o restante do código e faz o build
COPY ./src/maschion.API/. ./src/maschion.API/
WORKDIR /app/src/maschion.API
RUN dotnet publish -c Release -o /publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "maschion.API.dll"]
