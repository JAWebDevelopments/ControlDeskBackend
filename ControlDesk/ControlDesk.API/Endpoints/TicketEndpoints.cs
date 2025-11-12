using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;

namespace ControlDesk.API.Endpoints;

public static class TicketEndpoints
{
    public static void MapTicketEndpoints(this WebApplication app)
    {
        app.MapPost(Domain.Common.Endpoints.apiTickets, async (CreateTicketDto dto, TicketService service) =>
        {
            int id = await service.CreateAsync(dto);
            return Results.Created($"/api/tickets/{id}", new { id });
        }).WithSummary(Constants.docCreateTickets);

        app.MapGet(Domain.Common.Endpoints.apiTickets, async ([AsParameters] PaginationFilter filter, TicketService service) =>
        {
            List<ResultTicketQuery> ticketsTotal = await service.GetAllPagAsync(filter);
            int totalRecords = ticketsTotal.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / filter.PageSize);

            return Results.Ok(new
            {
                Tickets = ticketsTotal,
                filter.PageNumber,
                filter.PageSize,
                TotalCount = totalRecords,
                TotalPages = totalPages,
                HasPreviousPage = filter.PageNumber > 1,
                HasNextPage = filter.PageNumber < totalPages
            });
        }).WithSummary(Constants.docGetTickets);

        app.MapGet(Domain.Common.Endpoints.apiTickets + "/{id}", async (int id, TicketService service) =>
        {
            List<Ticket> tickets = await service.GetAllAsync();
            Ticket? match = tickets.FirstOrDefault(c => c.TicketId == id);
            return match is not null ? Results.Ok(match) : Results.NotFound(Constants.messageTicketNotFound);
        }).WithSummary(Constants.docGetByIdTickets);

        app.MapPut(Domain.Common.Endpoints.apiTickets + "/{id}", async (int id, UpdateTicketDto dto, TicketService service) =>
        {
            List<Ticket>? tickets = await service.GetAllAsync();
            Ticket? result = tickets.FirstOrDefault(c => c.TicketId == id);

            if (result != null)
            {
                result.Title = result.Title == dto.Title ? result.Title : dto.Title;
                result.Description = result.Description == dto.Description ? result.Description : dto.Description;
                result.IsOpen = result.IsOpen == dto.State ? result.IsOpen : dto.State;
                result.UserIdAssigned = result.UserIdAssigned == dto.UserIdAssigned ? result.UserIdAssigned : dto.UserIdAssigned;
                result.UserIdUpdate = result.UserIdUpdate == dto.UserIdUpdate ? result.UserIdUpdate : dto.UserIdUpdate;
                result.ModifiedDate = DateTime.Now;

                bool resultUpdate = service.Update(result);

                if (resultUpdate)
                {
                    return Results.Ok(Constants.messageTicketUpdate);
                }
                else
                {
                    return Results.BadRequest(Constants.messageTicketNotUpdate);
                }
            }
            else
            {
                return Results.NotFound(Constants.messageTicketNotFound);
            }
        }).WithSummary(Constants.docUpdateTickets);

        app.MapDelete(Domain.Common.Endpoints.apiTickets + "/{id}", async (int id, TicketService service) =>
        {
            List<Ticket>? tickets = await service.GetAllAsync();
            Ticket? match = tickets.FirstOrDefault(c => c.TicketId == id);

            if (match != null)
            {
                bool resultDelete = service.Delete(match);
                if (resultDelete)
                {
                    return Results.Ok(Constants.messageTicketDeleted);
                }
                else
                {
                    return Results.BadRequest(Constants.messageTicketNotDeleted);
                }
            }
            else
            {
                return Results.NotFound(Constants.messageTicketNotFound);
            }
        }).WithSummary(Constants.docDeleteTickets);
    }
}

