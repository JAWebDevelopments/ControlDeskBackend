namespace ControlDesk.Domain.Common
{
    public class Constants
    {
        //Mensajes Tickets
        public static readonly string messageTicketCreated = "Ticket fue creado correctamente";
        public static readonly string messageTicketUpdate = "Ticket fue actualizado correctamente";
        public static readonly string messageTicketDeleted = "Ticket fue eliminado correctamente";
        public static readonly string messageTicketNotFound = "Ticket no fue encontrado";
        public static readonly string messageTicketNotCreated = "Ticket no fue creado";
        public static readonly string messageTicketNotUpdate = "Ticket no fue actualizado";
        public static readonly string messageTicketNotDeleted = "Ticket no fue eliminado"; 
        public static readonly string messageLoginEmpty = "UserName o Password vacio";

        //Mensajes Usuarios
        public static readonly string messageUserCreated = "Usuario fue creado correctamente";
        public static readonly string messageUserUpdate = "Usuario fue actualizado correctamente";
        public static readonly string messageUserDeleted = "Usuario fue eliminado correctamente";
        public static readonly string messageUserNotFound = "Usuario no fue encontrado";
        public static readonly string messageUserNotCreated = "Usuario no fue creado";
        public static readonly string messageUserNotUpdate = "Usuario no fue actualizado";
        public static readonly string messageUserNotDeleted = "Usuario no fue eliminado";

        //Mensajes Roles
        public static readonly string messageRoleCreated = "Rol fue creado correctamente";
        public static readonly string messageRoleUpdate = "Rol fue actualizado correctamente";
        public static readonly string messageRoleDeleted = "Rol fue eliminado correctamente";
        public static readonly string messageRoleNotFound = "Rol no fue encontrado";
        public static readonly string messageRoleNotCreated = "Rol no fue creado";
        public static readonly string messageRoleNotUpdate = "Rol no fue actualizado";
        public static readonly string messageRoleNotDeleted = "Rol no fue eliminado";

        //Mensajes Departamentos
        public static readonly string messageDepartmentCreated = "Departamento fue creado correctamente";
        public static readonly string messageDepartmentUpdate = "Departamento fue actualizado correctamente";
        public static readonly string messageDepartmentDeleted = "Departamento fue eliminado correctamente";
        public static readonly string messageDepartmentNotFound = "Departamento no fue encontrado";
        public static readonly string messageDepartmentNotCreated = "Departamento no fue creado";
        public static readonly string messageDepartmentNotUpdate = "Departamento no fue actualizado";
        public static readonly string messageDepartmentNotDeleted = "Departamento no fue eliminado";

        //Mensajes Login
        public static readonly string messageSesionUserNotFound = "Usuario de sesión no fue encontrado";

        //Documentación API
        public static readonly string docCreateTickets = "Endpoint para crear tickets";
        public static readonly string docGetTickets = "Endpoint para obtener todos los tickets de forma paginada";
        public static readonly string docGetByIdTickets = "Endpoint para obtener tickets por Id";
        public static readonly string docUpdateTickets = "Endpoint para actualizar los tickets";
        public static readonly string docDeleteTickets = "Endpoint para eliminar los tickets por Id";

        public static readonly string docCreateUsers = "Endpoint para crear usuarios";
        public static readonly string docGetUsers = "Endpoint para obtener todos los usuarios";
        public static readonly string docGetByIdUsers = "Endpoint para obtener usuarios por Id";
        public static readonly string docUpdateUsers = "Endpoint para actualizar los usuarios";
        public static readonly string docDeleteUsers = "Endpoint para eliminar los usuarios por Id";

        public static readonly string docCreateRoles = "Endpoint para crear roles";
        public static readonly string docGetRoles = "Endpoint para obtener todos los roles";
        public static readonly string docGetByIdRoles = "Endpoint para obtener roles por Id";
        public static readonly string docUpdateRoles = "Endpoint para actualizar los roles";
        public static readonly string docDeleteRoles = "Endpoint para eliminar los roles por Id";

        public static readonly string docCreateDepartments = "Endpoint para crear departamentos";
        public static readonly string docGetDepartments = "Endpoint para obtener todos los departamentos";
        public static readonly string docGetByIdDepartments = "Endpoint para obtener departamentos por Id";
        public static readonly string docUpdateDepartments = "Endpoint para actualizar los departamentos";
        public static readonly string docDeleteDepartments = "Endpoint para eliminar los departamentos por Id";

        public static readonly string docLogin = "Endpoint para iniciar sesion o login";

    }
}
