# Gestor de Libros - API REST con Entity Framework Core

API REST para gestión de libros desarrollada con ASP.NET Core 8 y Entity Framework Core con SQL Server.

## Tecnologías

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- SQL Server
- Swagger / OpenAPI

## Estructura del proyecto

```
Gestor_Libros_EF/
├── Controllers/        # Endpoints HTTP (BookController)
├── Data/               # DbContext y DbSeeder
├── DTOs/               # Objetos de transferencia de datos
├── Migrations/         # Migraciones de EF Core
├── Models/             # Entidades de base de datos
├── Repositories/       # Acceso a datos (patrón repositorio)
├── Services/           # Lógica de negocio
├── appsettings.json    # Configuración y cadena de conexión
└── Program.cs          # Configuración de servicios y pipeline
```

## Requisitos previos

- [.NET 8 SDK]
- SQL Server (local o remoto)
- [Entity Framework CLI]
```bash
dotnet tool install --global dotnet-ef
```

## Configuración

Edita la cadena de conexión en `appsettings.json` según tu instancia de SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=GestorLibrosDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

## Ejecución

```bash
# Clonar el repositorio
git clone https://github.com/Acevedo26/Gestor_Libros_EF.git
cd Gestor_Libros_EF

# Ejecutar la aplicación (aplica migraciones y seed automáticamente)
dotnet run
```

Al iniciar, el sistema:
1. Aplica las migraciones pendientes automáticamente.
2. Inserta 5 libros de prueba si la base de datos está vacía.

## Endpoints

Base URL: `https://localhost:{puerto}/api/book`

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/book` | Listar todos los libros |
| GET | `/api/book/{id}` | Obtener libro por ID |
| GET | `/api/book/search?title={titulo}` | Buscar libros por título |
| POST | `/api/book` | Agregar un nuevo libro |
| PUT | `/api/book/{id}` | Actualizar un libro existente |
| DELETE | `/api/book/{id}` | Eliminar un libro |

### Ejemplo de cuerpo JSON (POST / PUT)

```json
{
  "title": "El nombre del viento",
  "author": "Patrick Rothfuss",
  "genre": "Fantasía",
  "yearPublished": 2007,
  "description": "La historia de Kvothe narrada por él mismo."
}
```

## Documentación interactiva

Con la aplicación corriendo en modo desarrollo, accede a Swagger en:

```
https://localhost:{puerto}/swagger
```

## Migraciones

```bash
# Crear una nueva migración
dotnet ef migrations add NombreMigracion

# Aplicar migraciones
dotnet ef database update
```

## Datos de prueba

El sistema carga automáticamente los siguientes libros al iniciar por primera vez:

| Título | Autor | Género | Año |
|--------|-------|--------|-----|
| Cien años de soledad | Gabriel García Márquez | Realismo mágico | 1967 |
| Don Quijote de la Mancha | Miguel de Cervantes | Novela | 1605 |
| 1984 | George Orwell | Distopía | 1949 |
| El principito | Antoine de Saint-Exupéry | Fábula | 1943 |
| Crimen y castigo | Fiódor Dostoyevski | Novela psicológica | 1866 |
