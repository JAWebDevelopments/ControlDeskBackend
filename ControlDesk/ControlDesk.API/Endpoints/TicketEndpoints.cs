using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Entities;

namespace ControlDesk.API.Endpoints;

public static class TicketEndpoints
{
    public static void MapTicketEndpoints(this WebApplication app)
    {
        app.MapPost("/api/tickets", async (CreateTicketDto dto, TicketService service) =>
        {
            int id = await service.CreateAsync(dto);
            return Results.Created($"/api/tickets/{id}", new { id });
        });

        app.MapGet("/api/tickets", async (TicketService service) =>
        {
            var tickets = await service.GetAllAsync();
            return Results.Ok(tickets);
        });

        app.MapGet("/api/tickets/{id:int}", async (int id, TicketService service) =>
        {
            var tickets = await service.GetAllAsync();
            var match = tickets.FirstOrDefault(c => c.TicketId == id);
            return match is not null ? Results.Ok(match) : Results.NotFound();
        });

        //TODO UPDATE y DELETE
    }
}

