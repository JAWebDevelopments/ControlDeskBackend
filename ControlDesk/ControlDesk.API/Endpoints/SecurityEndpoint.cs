using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;

namespace ControlDesk.API.Endpoints;

public static class SecurityEndpoint
{
    public static void MapSecurityEndpoint(this WebApplication app)
    {
        app.MapPost(Domain.Common.Endpoints.apiLogin, async (LoginDto dto, SecurityService service, AuthService authService) =>
        {
            if (!string.IsNullOrEmpty(dto.UserName) || !string.IsNullOrEmpty(dto.Password))
            {
                List<User> users = await service.GetAllAsync();
                var match = users.FirstOrDefault(c => c.Login == dto.UserName && Base64Helper.Decrypt(c.Password) == dto.Password);

                var fechaActual = DateTime.UtcNow;
                var validez = TimeSpan.FromHours(5);
                var fechaExpiracion = fechaActual.Add(validez);

                var token = authService.GenerateToken(fechaActual, dto.UserName, validez);

                return match is not null ? Results.Ok(new
                {
                    Token = token,
                    ExpireAt = fechaExpiracion
                }) : Results.NotFound(Constants.messageSesionUserNotFound);
            }
            else
            {
                return Results.BadRequest(Constants.messageLoginEmpty);
            }
        }).WithSummary(Constants.docLogin);
    }
}

