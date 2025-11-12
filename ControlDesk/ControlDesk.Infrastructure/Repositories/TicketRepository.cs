using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Enums;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class TicketRepository(ControlDeskContext context) : ITicketRepository
    {
        /// <summary>
        /// Metodo para obtener lista de tickets paginados
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<List<ResultTicketQuery>> GetAllPagAsync(int pageNumber, int pageSize)
        {
            var query = (from t in context.Tickets
                        join u in context.Users on t.UserIdAssigned equals u.UserId
                        join d in context.Departments on u.DepartmentId equals d.DepartmentId
                        join r in context.Roles on u.RoleId equals r.RoleId
                        select new ResultTicketQuery
                        {
                            TicketID = t.TicketId,
                            Title = t.Title,
                            Description = t.Description,
                            IsOpen = t.IsOpen == (int)StateTicket.IsOpen ? "Abierto" : "Cerrado",
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            RoleName = r.RoleName,
                            CreatedDate = t.CreatedDate
                        })
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return query;
        }

        /// <summary>
        /// Metodo para obtener tickets por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Ticket?> GetByIdAsync(int id) => context.Tickets.FindAsync(id).AsTask();

        /// <summary>
        /// Metodo para agregar un ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public Task AddAsync(Ticket ticket) => context.Tickets.AddAsync(ticket).AsTask();

        /// <summary>
        /// Metodo para actualizar un ticket
        /// </summary>
        /// <param name="ticket"></param>
        public void Update(Ticket ticket) => context.Tickets.Update(ticket);

        /// <summary>
        /// Metodo para eliminar un ticket
        /// </summary>
        /// <param name="ticket"></param>
        public void Delete(Ticket ticket) => context.Tickets.Remove(ticket);

        /// <summary>
        /// Metodo para agregar todos los ticket sin paginar
        /// </summary>
        /// <returns></returns>
        public Task<List<Ticket>> GetAllAsync() => context.Tickets.ToListAsync();
    }
}
