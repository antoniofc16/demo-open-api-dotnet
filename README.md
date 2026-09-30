# demo-open-api-dotnet

Proyecto de demostración que implementa una API REST con .NET y genera automáticamente un cliente .NET tipado a partir de la especificación OpenAPI.

## Descripción de la Solucion

Este repositorio muestra cómo:
- Web API REST con .NET (v10.0) y documentada con OpenAPI (Swagger)
- Generar automáticamente un cliente .NET tipado desde la especificación OpenAPI
- Documentar y probar la API usando Swagger UI

### Estructura del Proyecto

```
demo-open-api-dotnet/
├── Configuration/          # Configuración de la API (Autenticacion, Middlewares)
├── Controllers/          # Endpoints de la API
├── Data/				# Acceso a datos (repositorios, contextos)
├── Domain/            # Entidades del dominio
├── DTO/            # Modelos de datos
├── Program.cs           # Configuración de la aplicación
├── README.md            # Este archivo
└── demo-open-api-dotnet.csproj
```

---

## Pasos para Ejecutar el Proyecto

### Requisitos Previos
- **.NET SDK** 10.0 o instalado
- **Git** para clonar el repositorio
- Un navegador web para acceder a Swagger UI

### Instrucciones de Ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/antoniofc16/demo-open-api-dotnet.git
   cd demo-open-api-dotnet
   ```

2. **Restaurar dependencias:**
   ```bash
   dotnet restore
   ```

3. **Ejecutar el proyecto:**
   ```bash
   dotnet run --launch-profile https
   ```

4. **Acceder a la aplicación:**
   - La API estará disponible en `https://localhost:7257` (o el puerto configurado)
   - Swagger UI estará disponible en `https://localhost:7257/swagger` o `https://localhost:7257/swagger/index.html`

---

## Acceso a Swagger UI

### ¿Qué es Swagger UI?

Swagger UI es una interfaz web interactiva que permite visualizar, explorar e interactuar con los endpoints de la API RESTful.

### Cómo Acceder

1. Con la aplicación ejecutándose, abre tu navegador web
2. Navega a: `https://localhost:7257/swagger/index.html`
3. Verás una lista de todos los endpoints disponibles organizados por controladores

### Características de Swagger UI

- **Visualizar endpoints:** Todos los métodos HTTP disponibles (GET, POST, PUT, DELETE, etc.)
- **Explorar parámetros:** Consulta los parámetros requeridos y opcionales
- **Probar la API:** Haz clic en "Try it out" para ejecutar peticiones directamente desde la interfaz
- **Ver respuestas:** Observa los códigos de estado HTTP y ejemplos de respuestas
- **Descargar especificación:** La especificación OpenAPI en formato JSON está disponible en `/swagger/v1/swagger.json`

---

## Generación del Cliente .NET

### ¿Cómo se Generó el Cliente .NET?

El cliente .NET tipado se generó automáticamente a partir de la implementacion de Swagger en el proyecto, se puede ingresar a ella mediante el siguiente link: `https://localhost:7257/swagger/v1/swagger.json`.
