using ControlDesk.Domain.Entities;

namespace ControlDesk.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync();
        Task AddAsync(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
    }
}
