ARG VERSION=6.0

FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env

WORKDIR /app

ENV PATH="${PATH}:/root/.dotnet/tools"

ADD . .

#RUN chmod 777 build.sh && ./build.sh Rotamundos.Api

RUN dotnet restore *.sln

RUN dotnet publish \
  -c Release \
  -o ./out \
  --no-restore

#-----------------
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

ENV APP_HOME=/app
WORKDIR $APP_HOME

RUN adduser --disabled-password --gecos "" app -u 1000
ENV ASPNETCORE_URLS=http://*:5131
ENV COMPlus_EnableDiagnostics=0

ARG ENV
ENV ASPNETCORE_ENVIRONMENT ${ENV:-Development}
COPY --from=build-env --chown=app:app /app/out $APP_HOME
COPY --from=build-env --chown=app:app /app/Reservas-API/Configuration $APP_HOME/Configuration
EXPOSE 5131 5131

USER 1000



# Iniciar la aplicación cuando se ejecute el contenedor
ENTRYPOINT ["dotnet", "Reservas-API.dll"]
