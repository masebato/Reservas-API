
FROM mcr.microsoft.com/dotnet/sdk:7.0.302 AS build
WORKDIR /source



# Asumiendo que tu solución puede contener varios proyectos, ajusta los siguientes pasos según tu estructura exacta.
# Primero, copia solo los archivos de solución y proyecto para restaurar las dependencias.
COPY *.sln .
COPY Reservas-API/*.csproj Reservas-API/
COPY Reservas-DOMAIN/*.csproj Reservas-DOMAIN/
COPY Reservas-INFRASTRUCTURE/*.csproj Reservas-INFRASTRUCTURE/
RUN dotnet restore

# Ahora, copia el resto de los archivos de tu solución y publica el proyecto específico.
COPY . .
# Asegúrate de especificar el proyecto específico que quieres publicar.
RUN dotnet publish Reservas-API/Reservas-API.csproj -c Release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Reservas-API.dll"]
