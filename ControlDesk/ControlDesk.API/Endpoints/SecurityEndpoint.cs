using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;

namespace ControlDesk.API.Endpoints;

public static class SecurityEndpoint
{
    public static void MapSecurity(this WebApplication app)
    {
        app.MapPost("/api/login", async (LoginDto dto, SecurityService service) =>
        {
            if (!string.IsNullOrEmpty(dto.UserName) || !string.IsNullOrEmpty(dto.Password))
            {
                List<User> users = await service.GetAllAsync();
                var match = users.FirstOrDefault(c => c.Login == dto.UserName && Base64Helper.Decrypt(c.Password) == dto.Password);
                return match is not null ? Results.Ok(match) : Results.NotFound();
            }
            else
            {
                return Results.BadRequest("UserName o Password vacio");
            }

        });
    }
}

