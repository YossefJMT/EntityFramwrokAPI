Aquí tienes la versión actualizada del README con las mejoras sugeridas:

# API con Entity Framework en C# - Documentación

## Índice

- [Introducción](#introducción)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Uso de la API](#uso-de-la-api)
  - [Operaciones Básicas](#operaciones-básicas)
  - [Solicitudes Adicionales](#solicitudes-adicionales)
    - [Cálculo del Costo Total del Proyecto](#cálculo-del-costo-total-del-proyecto)
    - [Cálculo del Salario Total del Departamento](#cálculo-del-salario-total-del-departamento)
- [Esquema de la Base de Datos](#esquema-de-la-base-de-datos)
- [Configuración de la Base de Datos](#configuración-de-la-base-de-datos)
- [Ejecución del Proyecto](#ejecución-del-proyecto)
- [Contribución](#contribución)
- [Licencia](#licencia)

## Introducción

Este proyecto proporciona una API desarrollada en C# utilizando Entity Framework para interactuar con una base de datos SQL Server. La API está diseñada para manejar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en entidades como Employee, Department, Project y Dependent.

## Tecnologías Utilizadas

- **Entity Framework**: Framework de mapeo objeto-relacional (ORM) para .NET que simplifica el acceso y manipulación de datos en bases de datos relacionales.
- **C#**: Lenguaje de programación orientado a objetos ampliamente utilizado en el desarrollo de aplicaciones .NET.
- **SQL Server**: Sistema de gestión de bases de datos relacional desarrollado por Microsoft.

## Uso de la API

### Operaciones Básicas

La API proporciona los siguientes endpoints para realizar operaciones básicas:

- `GET /api/employees`: Obtener todos los empleados.
- `GET /api/departments`: Obtener todos los departamentos.
- `POST /api/projects`: Crear un nuevo proyecto.
- `PUT /api/dependents/{id}`: Actualizar la información de un dependiente.

### Solicitudes Adicionales

#### Cálculo del Costo Total del Proyecto

Esta API REST proporciona un punto final para calcular el costo total de un proyecto. El costo total se calcula sumando los salarios de todos los empleados asignados al proyecto.

- **Método HTTP y Ruta**:
  - Método: GET
  - Ruta: `/api/Projects/{projectName}/{projectNumber}/totalCost`
- **Parámetros de la Ruta**:
  - `{projectName}`: El nombre del proyecto.
  - `{projectNumber}`: El número del proyecto.
- **Respuesta Exitosa**:
  - Código de estado 200 (OK) y el costo total del proyecto en formato decimal.
- **Respuestas de Error**:
  - Código de estado 404 (Not Found) si no se encuentra el proyecto especificado en la base de datos.

#### Cálculo del Salario Total del Departamento

Esta API REST proporciona un punto final para calcular el salario total de un departamento. El salario total se calcula sumando los salarios de todos los empleados asociados al departamento.

- **Método HTTP y Ruta**:
  - Método: GET
  - Ruta: `/api/Departments/{departmentName}/{departmentNumber}/TotalSalary`
- **Parámetros de la Ruta**:
  - `{departmentName}`: El nombre del departamento.
  - `{departmentNumber}`: El número del departamento.
- **Respuesta Exitosa**:
  - Código de estado 200 (OK) y el salario total del departamento en formato decimal.
- **Respuestas de Error**:
  - Código de estado 404 (Not Found) si no se encuentra el departamento especificado en la base de datos.

## Esquema de la Base de Datos

La base de datos sigue el siguiente esquema:

![Entidad Relacion](Entidad-Relacion.png)
![DBeaver Schema](/EmployeeManagerAPI/Database/DbSchema.png)

### Entidades y Relaciones

Detalles sobre las entidades y relaciones se pueden encontrar en la imagen del esquema o en la documentación del código.

## Configuración de la Base de Datos

La configuración de la base de datos se realiza en el archivo `appsettings.json`, donde se especifican los parámetros de conexión a la base de datos SQL Server.

## Ejecución del Proyecto

Para ejecutar el proyecto, se puede utilizar Visual Studio o la línea de comandos. Si se utiliza la línea de comandos, se pueden ejecutar los siguientes comandos:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

## Contribución

¡Se aceptan contribuciones! Si deseas contribuir al proyecto, por favor abre un issue o envía una solicitud de extracción.

## Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).

¡Bienvenido a la documentación de tu API con Entity Framework y C#! Este README proporciona una guía completa sobre cómo comenzar con el desarrollo de tu proyecto! Si necesitas más detalles sobre alguna parte en particular, no dudes en consultar la documentación oficial de las tecnologías utilizadas o hacerme cualquier pregunta adicional. ¡Buena suerte con tu proyecto!