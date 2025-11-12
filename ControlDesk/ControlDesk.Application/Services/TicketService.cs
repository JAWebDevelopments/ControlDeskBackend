using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

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
                    CreatedDate = DateTime.Now,
                    UserIdCreated = dto.UserIdCreated,
                    UserIdAssigned = dto.UserIdAssigned,
                    UserIdUpdate = dto.UserIdCreated,
                    ModifiedDate = DateTime.Now,
                };
                await repository.AddAsync(ticket);
                await unitOfWork.SaveChangesAsync();
                return ticket.TicketId;
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }

        public async Task<List<Ticket>> GetAllAsync() => await repository.GetAllAsync();

        public async Task<List<Ticket>> GetAllPagAsync(PaginationFilter filter) => await repository.GetAllPagAsync(filter.PageNumber, filter.PageSize);

        public bool Update(Ticket? ticketObject)
        {
            try
            {
                /*Ticket ticket = new()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    State = dto.State,
                    Priority = dto.Priority,
                    CreatedDate = dto.CreatedDate,
                    UserIdCreated = dto.UserIdCreated,
                    UserIdAssigned = dto.UserIdAssigned
                };*/

                if (ticketObject != null)
                {
                    repository.Update(ticketObject);
                    unitOfWork.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }

        public bool Delete(Ticket? ticketObject)
        {
            try
            {
                if(ticketObject != null)
                {
                    repository.Delete(ticketObject);
                    unitOfWork.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (GenericException ex)
            {
                throw new GenericException("Exception: ", ex);
            }
        }
    }
}
