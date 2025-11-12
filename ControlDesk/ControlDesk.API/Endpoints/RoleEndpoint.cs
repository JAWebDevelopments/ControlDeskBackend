using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;

namespace ControlDesk.API.Endpoints
{
    public static class RoleEndpoint
    {
        public static void MapRoleEndpoints(this WebApplication app)
        {
            app.MapPost(Domain.Common.Endpoints.apiRoles, async (RoleDto dto, RoleService service) =>
            {
                int id = await service.CreateAsync(dto);
                return Results.Created($"/api/tickets/{id}", new { id });
            }).WithSummary(Constants.docCreateRoles);

            app.MapGet(Domain.Common.Endpoints.apiRoles, async (RoleService service) =>
            {
                var roles = await service.GetAllAsync();
                return Results.Ok(roles);
            }).WithSummary(Constants.docGetRoles);

            app.MapGet(Domain.Common.Endpoints.apiRoles + "/{id}", async (int id, RoleService service) =>
            {
                List<Role> roles = await service.GetAllAsync();
                Role? match = roles.FirstOrDefault(c => c.RoleId == id);
                return match is not null ? Results.Ok(match) : Results.NotFound(Constants.messageRoleNotFound);
            }).WithSummary(Constants.docGetByIdRoles);

            app.MapPut(Domain.Common.Endpoints.apiRoles + "/{id}", async (int id, RoleDto dto, RoleService service) =>
            {
                List<Role>? roles = await service.GetAllAsync();
                Role? result = roles.FirstOrDefault(c => c.RoleId == id);

                if (result != null)
                {
                    result.RoleName = result.RoleName == dto.RoleName ? result.RoleName : dto.RoleName;
                    result.CreatedDate = DateTime.Now;

                    bool resultUpdate = service.Update(result);

                    if (resultUpdate)
                    {
                        return Results.Ok(Constants.messageRoleUpdate);
                    }
                    else
                    {
                        return Results.BadRequest(Constants.messageRoleNotUpdate);
                    }
                }
                else
                {
                    return Results.NotFound(Constants.messageRoleNotFound);
                }
            }).WithSummary(Constants.docUpdateRoles);

            app.MapDelete(Domain.Common.Endpoints.apiRoles + "/{id}", async (int id, RoleService service) =>
            {
                List<Role>? roles = await service.GetAllAsync();
                Role? match = roles.FirstOrDefault(c => c.RoleId == id);

                if (match != null)
                {
                    bool resultDelete = service.Delete(match);
                    if (resultDelete)
                    {
                        return Results.Ok(Constants.messageRoleDeleted);
                    }
                    else
                    {
                        return Results.BadRequest(Constants.messageRoleNotDeleted);
                    }
                }
                else
                {
                    return Results.NotFound(Constants.messageRoleNotFound);
                }
            }).WithSummary(Constants.docDeleteRoles);
        }
    }
}
