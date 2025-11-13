# ControlDeskBackend
Rest API en C# NET Core 9+ en arquitectura limpia DDD y Entity Framework para gestión de tickets

## Proceso de instalación

## Base de datos

SQL Server 2014+

Modelo ER:
<div align="center" style="display: flex;">
<img src="./assets/modeloERBD.png" alt="Modelo Entidad Relación" title="Modelo Entidad Relación" width=620 height=450/>
</div>

Archivo para restarua o Backup:

. Adjunto archivo backup para restaurar en caso de ser necesario. Se encuentra en la raiz del repositorio:

ControlDesk.bak

Consulta Ejemplo para validar Ticket, Estado, Fecha de creación, usuario Asignado

## Consulta SQL 

SELECT        dbo.Ticket.TicketID, dbo.Ticket.Title, dbo.Ticket.Description, dbo.Ticket.IsOpen, dbo.Ticket.CreatedDate, dbo.[User].FirstName, dbo.[User].LastName, dbo.[User].Email, dbo.Role.RoleName, 
                         dbo.Department.DepartmentName
FROM            dbo.Department INNER JOIN
                         dbo.[User] ON dbo.Department.DepartmentID = dbo.[User].DepartmentID INNER JOIN
                         dbo.Role ON dbo.[User].RoleID = dbo.Role.RoleID INNER JOIN
                         dbo.Ticket ON dbo.[User].UserID = dbo.Ticket.UserIdAssigned

## Proyecto 

1. Descargar SDK Net Core 9.0
https://dotnet.microsoft.com/es-es/download/dotnet/9.0

2. Guia de instalación
https://learn.microsoft.com/es-es/dotnet/core/install/windows

Arquitectura del proyecto

Capa API - Capa Application - Capa Domain - Capa Infraestructura

<div align="center" style="display: flex;">
<img src="./assets/arquitecturaProyecto.png" alt="Arquitectura" title="Arquitectura" width=450 height=250/>
</div>


3. Cambiar String de conexión en el archivo appsettings.json ubicado en la capa o proyecto ControlDesk.API: DefaultConnection

<div align="center" style="display: flex;">
<img src="./assets/stringConn.png" alt="Conexion" title="Conexion" width=1020 height=550/>
</div>

4. Migrar Base de datos mediante comendo EF, En caso de no restaurar o no existir la base de datos (opcional)

Pasos para la migración

. Definir modelos: Crea tus clases de C# que representarán las tablas de la base de datos.

. Configurar el DbContext: Crea una clase que herede de DbContext y configura la conexión a tu base de datos SQL Server.

. Generar la primera migración:
Abre la Consola del Administrador de Paquetes o la Terminal en Visual Studio.

Ejecuta el comando: Add-Migration InitialCreate(puedes usar otro nombre en lugar deInitialCreate`).

Esto generará una carpeta Migrations con dos archivos: uno para la configuración y otro con los métodos Up (para aplicar los cambios) y Down (para revertirlos).

. Aplicar la migración a la base de datos:

Ejecuta el comando: Update-Database.

Este comando ejecutará el método Up del archivo de migración para crear la base de datos y sus tablas en tu instancia de SQL Server.

. Realizar cambios y migrar nuevamente:

Modifica tus clases de modelo C# o agrega nuevas clases.

Genera una nueva migración con Add-Migration <NombreDeLaMigracion>.

Aplica los cambios a la base de datos con Update-Database nuevamente. 

5. Ejecutar Proyecto

. Ejecución Local:

Seleccioanr en Visual Studio la opción de IIS Express:

<div align="center" style="display: flex;">
<img src="./assets/ejecutarLocal.png" alt="Ejecución local" title="Ejecución local" width=1280 height=520/>
</div>

. Ejecución Docker:

Seleccioanr en Visual Studio la opción de Container DockerFile:

<div align="center" style="display: flex;">
<img src="./assets/ejecutarDocker.png" alt="Ejecución Docker" title="Ejecución Docker" width=1280 height=520/>
</div>

Docker

<div align="center" style="display: flex;">
<img src="./assets/dockerRunning.png" alt="Docker en ejecución" title="Docker en ejecución" width=1280 height=550/>
</div>


## Consumo de APIs

URL:

Puerto Seguro

https://ipservidor:port/swagger/index.html

Puerto No seguro

https://ipservidor:port/swagger/index.html

OpenAPI

<div align="center" style="display: flex;">
<img src="./assets/openAPI.png" alt="openAPI" title="openAPI" width=1280 height=580/>
</div>

## 🏢 Departamentos

1. Crear Departamentos

. request

URL: https://localhost:32769/api/departments

TIPO: POST

JSON:
```
{
  "departmentName": "Finance",
  "departmentDescription": "Executive General and Administration"
}
```

. response
```
{
  "id": 4
}
```

2. Listar Departamentos

. request

URL: https://localhost:32769/api/departments

TIPO: GET

. response
```
[
  {
    "departmentId": 1,
    "departmentName": "Engineering",
    "departmentDescription": "Research and Development",
    "createdDate": "2025-11-11T00:00:00",
    "users": []
  },
  {
    "departmentId": 2,
    "departmentName": "Tool Design",
    "departmentDescription": "Research and Development",
    "createdDate": "2025-11-11T00:00:00",
    "users": []
  },
  {
    "departmentId": 3,
    "departmentName": "Information Services",
    "departmentDescription": "Executive General and Administration",
    "createdDate": "2025-11-11T00:00:00",
    "users": []
  },
  {
    "departmentId": 4,
    "departmentName": "Finance",
    "departmentDescription": "Executive General and Administration",
    "createdDate": "2025-11-13T01:32:05.047",
    "users": []
  }
]
```

3. Consulta Departamentos por Id

. request

URL: https://localhost:32769/api/departments/1

TIPO: GET

. response
```
{
  "departmentId": 1,
  "departmentName": "Engineering",
  "departmentDescription": "Research and Development",
  "createdDate": "2025-11-11T00:00:00",
  "users": []
}
```

4. Actualizar Departamentos

. request

URL: https://localhost:32769/api/departments/4

TIPO: PUT

JSON: 

```
{
  "departmentName": "Document Control",
  "departmentDescription": "Quality Assurance"
}
```

. response

"Departamento fue actualizado correctamente"

5. Eliminar Departamentos

. request

URL: https://localhost:32769/api/departments/4

TIPO: DELETE

. response

"Departamento fue eliminado correctamente"

## 📊 Roles

1. Crear Roles

. request

URL: https://localhost:32769/api/roles

TIPO: POST

JSON:
```
{
  "roleName": "customer"
}
```
. response
```
{
  "id": 3
}
```

2. Listar Roles

. request

URL: https://localhost:32769/api/roles

TIPO: GET

. response
```
[
  {
    "roleId": 1,
    "roleName": "Administrator",
    "createdDate": "2025-11-11T00:00:00",
    "users": []
  },
  {
    "roleId": 2,
    "roleName": "Support",
    "createdDate": "2025-11-11T00:00:00",
    "users": []
  },
  {
    "roleId": 3,
    "roleName": "customer",
    "createdDate": "2025-11-13T01:11:54.97",
    "users": []
  }
]
```

3. Consulta Roles por Id

. request

URL: https://localhost:32769/api/roles/1

TIPO: GET

. response
```
{
  "roleId": 1,
  "roleName": "Administrator",
  "createdDate": "2025-11-11T00:00:00",
  "users": []
}
```

4. Actualizar Roles

. request

URL: https://localhost:32769/api/roles/3

TIPO: PUT

JSON:
```
{
  "roleName": "Customer"
}
```
. response

"Rol fue actualizado correctamente"

5. Eliminar Roles

. request

URL: https://localhost:32769/api/roles/3

TIPO: DELETE

. response

"Rol fue eliminado correctamente"

## 👯 Usuarios

1. Crear Usuarios - El password se encripta Base 64

. request

URL: https://localhost:32769/api/users

TIPO: POST

JSON:
```
{
  "firstName": "Usuario",
  "lastName": "Prueba Uno",
  "email": "Usuario1@correo.com",
  "login": "Usuario1",
  "password": "Usuario1.*",
  "roleID": 2,
  "departmentID": 3
}
```

. response
```
{
  "id": 6
}
```

2. Listar Usuarios

. request

URL: https://localhost:32769/api/users

TIPO: GET

. response
```
[
  {
    "userId": 2,
    "firstName": "Terri",
    "lastName": "Duffy",
    "email": "d.duffy@email.com",
    "login": "d.duffy",
    "password": "UGFzc3cwcmQx",
    "roleId": 1,
    "departmentId": 1,
    "createdDate": "2025-11-11T00:00:00",
    "modifiedDate": "2025-11-11T00:00:00",
    "department": null,
    "role": null,
    "tickets": []
  },
  {
    "userId": 3,
    "firstName": "Nancy",
    "lastName": "Anderson",
    "email": "n.anderson@email.com",
    "login": "n.anderson",
    "password": "UGFzc3cwcmQy",
    "roleId": 2,
    "departmentId": 3,
    "createdDate": "2025-11-11T00:00:00",
    "modifiedDate": "2025-11-11T00:00:00",
    "department": null,
    "role": null,
    "tickets": []
  },
  {
    "userId": 4,
    "firstName": "Barry",
    "lastName": "Johnson",
    "email": "b.johnson@email.com",
    "login": "b.johnson",
    "password": "UGFzc3cwcmQz",
    "roleId": 2,
    "departmentId": 3,
    "createdDate": "2025-11-11T00:00:00",
    "modifiedDate": "2025-11-11T00:00:00",
    "department": null,
    "role": null,
    "tickets": []
  },
  {
    "userId": 5,
    "firstName": "Michael",
    "lastName": "Raheem",
    "email": "m.Raheem@email.com",
    "login": "m.Raheem",
    "password": "MTIzNDU2Nzg5MA==",
    "roleId": 2,
    "departmentId": 3,
    "createdDate": "2025-11-11T23:42:49.84",
    "modifiedDate": "2025-11-11T23:50:11.417",
    "department": null,
    "role": null,
    "tickets": []
  },
  {
    "userId": 6,
    "firstName": "Usuario",
    "lastName": "Prueba Uno",
    "email": "Usuario1@correo.com",
    "login": "Usuario1",
    "password": "VXN1YXJpbzEuKg==",
    "roleId": 2,
    "departmentId": 3,
    "createdDate": "2025-11-13T01:47:23.237",
    "modifiedDate": "2025-11-13T01:47:23.237",
    "department": null,
    "role": null,
    "tickets": []
  }
]
```

3. Consulta Usuarios por Id

. request

URL: https://localhost:32769/api/users/6

TIPO: GET

. response

```
{
  "userId": 6,
  "firstName": "Usuario",
  "lastName": "Prueba Uno",
  "email": "Usuario1@correo.com",
  "login": "Usuario1",
  "password": "VXN1YXJpbzEuKg==",
  "roleId": 2,
  "departmentId": 3,
  "createdDate": "2025-11-13T01:47:23.237",
  "modifiedDate": "2025-11-13T01:47:23.237",
  "department": null,
  "role": null,
  "tickets": []
}
```

4. Actualizar Usuarios

. request

URL: https://localhost:32769/api/users/6

TIPO: PUT

JSON:

```
{
  "firstName": "Usuario",
  "lastName": "Prueba Dos",
  "email": "Usuario2@correo.com",
  "login": "Usuario2",
  "password": "Usuario2.*",
  "roleID": 2,
  "departmentID": 4
}
```

. response

"Usuario fue actualizado correctamente"

5. Eliminar Usuarios

. request

URL: https://localhost:32769/api/users/6

TIPO: DELETE

. response

"Usuario fue eliminado correctamente"

## ⚡ Tickets

### Estado de tickets

1 = Abierto - 2 = Cerrado - Si se intenta guardar otro valor, no actualiza el estado ni ningun otro dato debido a excepcion controlada de base de datos.

1. Crear Tickets

. request

URL: https://localhost:32769/api/tickets

TIPO: POST

JSON:

```
{
  "title": "Ticket 1000",
  "description": "Este es un ticket de preuba. Generar Reporte",
  "userIdCreated": 2,
  "userIdAssigned": 5,
  "userIdUpdate": 2
}
```

. response

{
  "id": 36
}

2. Listar Tickets de forma paginada

. request

URL: https://localhost:32769/api/tickets?PageNumber=2&PageSize=5

TIPO: GET

. response

```
{
  "tickets": [
    {
      "ticketID": 11,
      "title": "Prueba 2",
      "description": "Prueba 2 ticket",
      "isOpen": "Abierto",
      "firstName": "Nancy",
      "lastName": "Anderson",
      "email": "n.anderson@email.com",
      "roleName": "Support",
      "departmentName": null,
      "createdDate": "2025-11-11T20:44:07.857"
    },
    {
      "ticketID": 12,
      "title": "Prueba 2",
      "description": "Prueba 2 ticket",
      "isOpen": "Abierto",
      "firstName": "Nancy",
      "lastName": "Anderson",
      "email": "n.anderson@email.com",
      "roleName": "Support",
      "departmentName": null,
      "createdDate": "2025-11-11T20:44:08.413"
    },
    {
      "ticketID": 13,
      "title": "Prueba 2",
      "description": "Prueba 2 ticket",
      "isOpen": "Abierto",
      "firstName": "Nancy",
      "lastName": "Anderson",
      "email": "n.anderson@email.com",
      "roleName": "Support",
      "departmentName": null,
      "createdDate": "2025-11-11T20:44:09.103"
    },
    {
      "ticketID": 14,
      "title": "Prueba 2",
      "description": "Prueba 2 ticket",
      "isOpen": "Abierto",
      "firstName": "Nancy",
      "lastName": "Anderson",
      "email": "n.anderson@email.com",
      "roleName": "Support",
      "departmentName": null,
      "createdDate": "2025-11-11T20:44:09.487"
    },
    {
      "ticketID": 15,
      "title": "Prueba 2",
      "description": "Prueba 2 ticket",
      "isOpen": "Abierto",
      "firstName": "Nancy",
      "lastName": "Anderson",
      "email": "n.anderson@email.com",
      "roleName": "Support",
      "departmentName": null,
      "createdDate": "2025-11-11T20:44:09.92"
    }
  ],
  "pageNumber": 2,
  "pageSize": 5,
  "totalCount": 5,
  "totalPages": 1,
  "hasPreviousPage": true,
  "hasNextPage": false
}
```

3. Consulta Tickets por Id

. request

URL: https://localhost:32769/api/tickets/36

TIPO: GET

. response

```
{
  "ticketId": 36,
  "title": "Ticket 1000",
  "description": "Este es un ticket de preuba. Generar Reporte",
  "isOpen": 1,
  "createdDate": "2025-11-13T02:01:36.587",
  "userIdCreated": 2,
  "userIdAssigned": 5,
  "userIdUpdate": 2,
  "modifiedDate": "2025-11-13T02:01:36.587",
  "userIdCreatedNavigation": null
}
```

4. Actualizar Tickets

. request

URL: https://localhost:32769/api/tickets/36

TIPO: PUT

JSON:

```
{
  "title": "Ticket 1000",
  "description": "Este es un ticket de prueba. Cerrar Ticket",
  "state": 2,
  "userIdCreated": 2,
  "userIdAssigned": 5,
  "userIdUpdate": 2
}
```

. response

"Ticket fue actualizado correctamente"

5. Eliminar Tickets

. request

URL: https://localhost:32769/api/tickets/36

TIPO: DELETE

. response

"Ticket fue eliminado correctamente"

## ☕ Login

1. Realizar login con el dato de login y password original (sin encriptar). Esto retorna un token.

. request

URL: https://localhost:32769/api/login

TIPO: POST

JSON:

```
{
  "userName": "d.duffy",
  "password": "Passw0rd1"
}
```

. response

```
{
  "token": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkLmR1ZmZ5IiwianRpIjoiNjBlMDZhYjQtODM1Mi00MDZlLWI2YjMtYzAyNzhlNzMwMzRlIiwiaWF0IjoxNzYyOTk4OTYxLCJyb2xlcyI6WyJTdXBwb3J0IiwiQWRtaW5pc3RyYXRvciJdLCJuYmYiOjE3NjI5OTg5NjEsImV4cCI6MTc2MzAxNjk2MSwiaXNzIjoiUGV0aWNpb25hcmlvIiwiYXVkIjoiUHVibGljIn0.UXuUeQogn2bROqSbQs1aefpcASE_fO5khT_ibNX3JUo",
  "expireAt": "2025-11-13T06:56:01.9307403Z"
}
```