
ARG VERSION=7.0

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env

WORKDIR /app

# Agrega el código fuente al contenedor
ADD . .

# Restaura las dependencias y herramientas de los proyectos
RUN dotnet restore *.sln

# Publica la aplicación
RUN dotnet publish -c Release -o ./out --no-restore

#-----------------
# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:$VERSION AS runtime

ENV APP_HOME=/app
WORKDIR $APP_HOME

# Crea un usuario para la aplicación
RUN adduser --disabled-password --gecos "" app -u 1000

# Configura el puerto y la desactivación de diagnósticos
ENV ASPNETCORE_URLS=http://*:5000
ENV COMPlus_EnableDiagnostics=0

# Establece el entorno (Development, Staging, Production)
ARG ENV
ENV ASPNETCORE_ENVIRONMENT ${ENV:-Development}

# Copia los archivos publicados desde la etapa de compilación
COPY --from=build-env --chown=app:app /app/out $APP_HOME

# Asegúrate de copiar el directorio Configuration y su contenido, ajusta la ruta según sea necesario
COPY --from=build-env --chown=app:app /app/Configuration $APP_HOME/Configuration

# Expone el puerto en el que la aplicación escucha
EXPOSE 5000

# Cambia al usuario de la aplicación
USER 1000

# Inicia la aplicación
ENTRYPOINT ["dotnet", "Reservas-API.dll"]
