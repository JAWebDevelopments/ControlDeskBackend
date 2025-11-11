using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using ControlDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDesk.Infrastructure.Repositories
{
    public class TicketRepository(ControlDeskContext context) : ITicketRepository
    {
        public Task<List<Ticket>> GetAllAsync() => context.Tickets.ToListAsync();
        public Task<Ticket?> GetByIdAsync(int id) => context.Tickets.FindAsync(id).AsTask();
        public Task AddAsync(Ticket ticket) => context.Tickets.AddAsync(ticket).AsTask();
        public void Update(Ticket ticket) => context.Tickets.Update(ticket);
        public void Delete(Ticket ticket) => context.Tickets.Remove(ticket);
    }
}
