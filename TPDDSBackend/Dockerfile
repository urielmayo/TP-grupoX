# Imagen base para la aplicación en ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Imagen para la construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar los archivos necesarios para la construcción
COPY ["TPDDSBackend.csproj", "."]
RUN dotnet restore "./TPDDSBackend.csproj"

# Copiar todo el contexto del proyecto
COPY . .

# Construir la aplicación
RUN dotnet build "./TPDDSBackend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar la aplicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TPDDSBackend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final para la ejecución
FROM base AS final
WORKDIR /app

# Copiar el archivo de contraseñas al contenedor
COPY 10-million-password-list-top-10000.txt ./10-million-password-list-top-10000.txt

# Copiar la aplicación publicada
COPY --from=publish /app/publish .

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "TPDDSBackend.dll"]
