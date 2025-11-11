using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ControlDesk.Application.Services
{

    public class TicketService(ITicketRepository repository, IUnitOfWork unitOfWork)
    {
        public async Task<int> CreateAsync(CreateTicketDto dto)
        {
            try
            {
                Ticket ticket = new()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    State = dto.State,
                    Priority = dto.Priority,
                    CreatedDate = dto.CreatedDate,
                    UserIdCreated = dto.UserIdCreated,
                    UserIdAssigned = dto.UserIdAssigned
                };
                await repository.AddAsync(ticket);
                await unitOfWork.SaveChangesAsync();
                return ticket.TicketId;
            }
            catch (TicketException ex)
            {
                throw new TicketException("Exception: ", ex);
            }
        }

        public async Task<List<Ticket>> GetAllAsync() => await repository.GetAllAsync();
    }
}
