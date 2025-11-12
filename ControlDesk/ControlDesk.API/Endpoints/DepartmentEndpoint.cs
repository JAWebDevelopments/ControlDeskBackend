using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;

namespace ControlDesk.API.Endpoints
{
    public static class DepartmentEndpoint
    {
        public static void MapDepartmentEndpoints(this WebApplication app)
        {
            app.MapPost(Domain.Common.Endpoints.apiDepartments, async (DepartmentDto dto, DepartmentService service) =>
            {
                int id = await service.CreateAsync(dto);
                return Results.Created($"/api/tickets/{id}", new { id });
            }).WithSummary(Constants.docCreateDepartments);

            app.MapGet(Domain.Common.Endpoints.apiDepartments, async (DepartmentService service) =>
            {
                List<Department> departments = await service.GetAllAsync();
                return Results.Ok(departments);
            }).WithSummary(Constants.docGetDepartments);

            app.MapGet(Domain.Common.Endpoints.apiDepartments + "/{id}", async (int id, DepartmentService service) =>
            {
                List<Department> roles = await service.GetAllAsync();
                Department? match = roles.FirstOrDefault(c => c.DepartmentId == id);
                return match is not null ? Results.Ok(match) : Results.NotFound(Constants.messageDepartmentNotFound);
            }).WithSummary(Constants.docGetByIdDepartments);

            app.MapPut(Domain.Common.Endpoints.apiDepartments + "/{id}", async (int id, DepartmentDto dto, DepartmentService service) =>
            {
                List<Department>? roles = await service.GetAllAsync();
                Department? result = roles.FirstOrDefault(c => c.DepartmentId == id);

                if (result != null)
                {
                    result.DepartmentName = result.DepartmentName == dto.DepartmentName ? result.DepartmentName : dto.DepartmentName;
                    result.DepartmentDescription = result.DepartmentDescription == dto.DepartmentDescription ? result.DepartmentDescription : dto.DepartmentDescription;
                    result.CreatedDate = DateTime.Now;

                    bool resultUpdate = service.Update(result);

                    if (resultUpdate)
                    {
                        return Results.Ok(Constants.messageDepartmentUpdate);
                    }
                    else
                    {
                        return Results.BadRequest(Constants.messageDepartmentNotUpdate);
                    }
                }
                else
                {
                    return Results.NotFound(Constants.messageDepartmentNotFound);
                }
            }).WithSummary(Constants.docUpdateDepartments);

            app.MapDelete(Domain.Common.Endpoints.apiDepartments + "/{id}", async (int id, DepartmentService service) =>
            {
                List<Department>? roles = await service.GetAllAsync();
                Department? match = roles.FirstOrDefault(c => c.DepartmentId == id);

                if (match != null)
                {
                    bool resultDelete = service.Delete(match);
                    if (resultDelete)
                    {
                        return Results.Ok(Constants.messageDepartmentDeleted);
                    }
                    else
                    {
                        return Results.BadRequest(Constants.messageDepartmentNotDeleted);
                    }
                }
                else
                {
                    return Results.NotFound(Constants.messageDepartmentNotFound);
                }
            }).WithSummary(Constants.docDeleteDepartments);
        }
    }
}
