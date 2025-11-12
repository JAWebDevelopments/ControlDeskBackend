using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;

namespace ControlDesk.API.Endpoints
{
    public static class UserEndpoint
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapPost(Domain.Common.Endpoints.apiUsers, async (UserDto dto, UserService service) =>
            {
                int id = await service.CreateAsync(dto);
                return Results.Created($"/api/tickets/{id}", new { id });
            }).WithSummary(Constants.docCreateUsers);

            app.MapGet(Domain.Common.Endpoints.apiUsers, async (UserService service) =>
            {
                var users = await service.GetAllAsync();
                return Results.Ok(users);
            }).WithSummary(Constants.docGetUsers);

            app.MapGet(Domain.Common.Endpoints.apiUsers + "/{id}", async (int id, UserService service) =>
            {
                List<User> users = await service.GetAllAsync();
                User? match = users.FirstOrDefault(c => c.UserId == id);
                return match is not null ? Results.Ok(match) : Results.NotFound(Constants.messageUserNotFound);
            }).WithSummary(Constants.docGetByIdUsers);

            app.MapPut(Domain.Common.Endpoints.apiUsers + "/{id}", async (int id, UserDto dto, UserService service) =>
            {
                List<User>? users = await service.GetAllAsync();
                User? result = users.FirstOrDefault(c => c.UserId == id);

                if (result != null)
                {
                    result.FirstName = result.FirstName == dto.FirstName ? result.FirstName : dto.FirstName;
                    result.LastName = result.LastName == dto.LastName ? result.LastName : dto.LastName;
                    result.Email = result.Email == dto.Email ? result.Email : dto.Email;
                    result.Login = result.Login == dto.Login ? result.Login : dto.Login;
                    result.Password = result.Password == Base64Helper.Encrypt(dto.Password) ? result.Password : Base64Helper.Encrypt(dto.Password);
                    result.RoleId = result.RoleId == dto.RoleID ? result.RoleId : dto.RoleID;
                    result.DepartmentId = result.DepartmentId == dto.DepartmentID ? result.DepartmentId : dto.DepartmentID;
                    result.ModifiedDate = DateTime.Now;

                    bool resultUpdate = service.Update(result);

                    if (resultUpdate)
                    {
                        return Results.Ok(Constants.messageUserUpdate);
                    }
                    else
                    {
                        return Results.BadRequest(Constants.messageUserNotUpdate);
                    }
                }
                else
                {
                    return Results.NotFound(Constants.messageTicketNotFound);
                }
            }).WithSummary(Constants.docUpdateUsers);

            app.MapDelete(Domain.Common.Endpoints.apiUsers + "/{id}", async (int id, UserService service) =>
            {
                List<User>? users = await service.GetAllAsync();
                User? match = users.FirstOrDefault(c => c.UserId == id);

                if (match != null)
                {
                    bool resultDelete = service.Delete(match);
                    if (resultDelete)
                    {
                        return Results.Ok(Constants.messageUserDeleted);
                    }
                    else
                    {
                        return Results.BadRequest(Constants.messageUserNotDeleted);
                    }
                }
                else
                {
                    return Results.NotFound(Constants.messageUserNotFound);
                }
            }).WithSummary(Constants.docDeleteUsers);
        }
    }
}
