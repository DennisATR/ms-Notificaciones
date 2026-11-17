# ms-Notificaciones

## Descripción

Microservicio encargado de centralizar el envío de notificaciones por correo electrónico para las aplicaciones del sistema. Recibe los datos del destinatario y del mensaje, y gestiona el envío mediante SendGrid.

## Funcionalidades

- Envío de correos electrónicos mediante una API REST.
- Recepción de destinatario, nombre, asunto y contenido HTML.
- Integración con SendGrid para la entrega de correos.
- Respuestas HTTP de éxito o error.
- Documentación de la API mediante Swagger/OpenAPI.
- Configuración de credenciales mediante variables de entorno.

## Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- C#
- SendGrid
- Swagger/OpenAPI mediante Swashbuckle
- DotNetEnv

## Ejecución

Configura la variable de entorno `SENGRID_API_KEY` con la clave de SendGrid y ejecuta:

```bash
dotnet restore
dotnet run
