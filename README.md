# TP-grupoX

Proyecto de aplicacion web con 3 servicios. Frontend, Backend y Motor de BBDD.

## Instalacion y ejecucion

1. Crear variable de entorno `.env` dentro de directorio `/frontend` con la variable `VITE_DOTNET_URL=<url_backend>` incluir diagonal (/) al final de la url
2. Levantar los contenedores
3. Instalar sdk de dotnet
4. correr los siguientes comando en dotnet:

   ```sh
    dotnet tool install --global dotnet-ef
    dotnet ef database update
    dotnet run --launch-profile "https"
   ```
