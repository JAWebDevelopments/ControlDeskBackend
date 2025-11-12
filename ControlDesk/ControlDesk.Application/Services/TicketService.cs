using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Common;
using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Enums;
using ControlDesk.Domain.Exceptions;
using ControlDesk.Domain.Interfaces;

namespace ControlDesk.Application.Services
{
    public class TicketService(ITicketRepository repository, IUnitOfWork unitOfWork)
    {
        /// <summary>
        /// Servicio para crear ticket
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
        public async Task<int> CreateAsync(CreateTicketDto dto)
        {
            try
            {
                Ticket ticket = new()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    IsOpen = (int)StateTicket.IsOpen,
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

        /// <summary>
        /// servicio para obtener todos los tickets
        /// </summary>
        /// <returns></returns>
        public async Task<List<Ticket>> GetAllAsync() => await repository.GetAllAsync();

        /// <summary>
        /// servicio para obtener todos los tickets de forma paginada
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<ResultTicketQuery>> GetAllPagAsync(PaginationFilter filter) => await repository.GetAllPagAsync(filter.PageNumber, filter.PageSize);

        /// <summary>
        /// Servicio para actualizar datos de un ticket
        /// </summary>
        /// <param name="ticketObject"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
        public bool Update(Ticket? ticketObject)
        {
            try
            {
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

        /// <summary>
        /// Servicio para eliminar un ticket
        /// </summary>
        /// <param name="ticketObject"></param>
        /// <returns></returns>
        /// <exception cref="GenericException"></exception>
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
