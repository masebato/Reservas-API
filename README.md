# Ejecución de Reservas-API con Docker

Esta guía rápida cubre los pasos para ejecutar el proyecto `Reservas-API` utilizando Docker y Docker Compose.

## Requisitos Previos

Asegúrate de tener Docker y Docker Compose instalados en tu sistema.

## Pasos para Ejecutar

1. **Clonar el Repositorio (Opcional)**

   Si el proyecto está en un repositorio remoto, clónalo en tu máquina local. De lo contrario, asegúrate de estar en el directorio del proyecto.

    ```bash
    git clone <url-del-repositorio>
    cd Reservas-API
    ```

2. **Configurar la Cadena de Conexión**

   Verifica que `appsettings.json` contenga la cadena de conexión correcta para Docker:

    ```json
    {
      "ConnectionStrings": {
        "postgrestDB": "Host=db;Port=5432;Database=postgres;Username=postgres;Password=postgres;Timeout=30"
      }
    }
    ```

3. **Ejecutar Docker Compose**

   Desde el directorio raíz del proyecto, ejecuta:

    ```bash
    docker-compose up --build
    ```

   Este comando construirá la imagen de tu aplicación (si es necesario) y levantará los contenedores para tu aplicación y la base de datos PostgreSQL.

4. **Acceder a la Aplicación**

   Una vez que los contenedores estén en ejecución, tu aplicación debería estar accesible en `[http://localhost:5000](https://localhost:7197/swagger/index.html)` o el puerto que hayas especificado en `docker-compose.yml`.

